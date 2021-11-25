using Microsoft.EntityFrameworkCore;
using PersonalCards.Connection;
using PersonalCards.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PersonalCards
{
    class Program
    {
        static void Main(string[] args)
        {
            FillDbMockDate();
            PrintCardIdAndPurchaseSum();
        }

        static PersonalConsumersCardsContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonalConsumersCardsContext>();
            var options = optionsBuilder
                .UseSqlServer(new ConnectionStringConfig().ConnectionString)
                .Options;

            return new PersonalConsumersCardsContext(options);
        }

        static void FillDbMockDate(int seed = 0)
        {
            using var context = CreateContext();
            {
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    var random = new Random(seed);

                    for (int i = 0; i < 3; i++)
                    {
                        context.PersonalCards.Add(GetPersonalCard(random.Next()));
                    }

                    context.SaveChanges();

                    foreach (var card in context.PersonalCards)
                    {
                        context.UserProfiles.Add(GetUserProfile(card.Id));
                    }

                    context.SaveChanges();

                    foreach (var card in context.PersonalCards)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            context.Purchases.Add(GetPurchase(random.Next(), card.Id, random.Next(1000)));
                        }
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        static void PrintCardIdAndPurchaseSum()
        {
            using var context = CreateContext();
            {
                var cards = context.PersonalCards
                    .Select(c => c.Id)
                    .ToList();

                foreach (var purchase in context.Purchases)
                {
                    Console.WriteLine("Номер карты: {0}\nСкидка по карте: {1}", cards.Find(c => c == purchase.CardId), purchase.PurchaseSum);
                    Console.WriteLine();
                }
            }
        }

        static PersonalCard GetPersonalCard(int id)
        {
            return new PersonalCard() {
                Id = id
            };
        }

        static UserProfile GetUserProfile(int id)
        {
            return new UserProfile() { 
                UserId = id,
                Email = "sth@gmail.com"
            };
        }

        static Purchase GetPurchase(int id, int cardId, int sum)
        {
            return new Purchase() {
                Id = id,
                CardId = cardId,
                PurchaseSum = (uint)sum
            };
        }
    }
}

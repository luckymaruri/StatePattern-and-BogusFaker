﻿using Bogus;
using System.Text.Json;
using Xunit;

namespace BogusFaker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {           
            await GenerateRandomData();            
        }
        static async Task GenerateRandomData()
        {
            Randomizer.Seed=new Random(1000);
            var billingDetailsFaker = new Faker<BillingDetails>()
                .RuleFor(x => x.CustomerName, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.Phone, x => x.Person.Phone)
                .RuleFor(x => x.AddressLine, x => x.Address.StreetAddress())
                .RuleFor(x => x.City, x => x.Address.City())
                .RuleFor(x => x.Country, x => x.Address.Country())
                .RuleFor(x => x.PostalCode, x => x.Address.ZipCode());

            var orderFaker = new Faker<Order>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                .RuleFor(x => x.Currency, x => x.Finance.Currency().Code)
                .RuleFor(x => x.Price, x => x.Finance.Amount(5,100))
                .RuleFor(x => x.BillingDetails, x => billingDetailsFaker);


            foreach (var order in orderFaker.GenerateForever())
            {
                var text = JsonSerializer.Serialize(order);
                Console.WriteLine(text +"\n");
                await Task.Delay(1000);
            }
            
            Console.Read();
        }
    }
}

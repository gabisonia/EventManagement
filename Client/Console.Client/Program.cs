﻿using EventManagement.Application.UseCases.CreateNewConcert;
using EventManagement.Application.UseCases.CreateSeatType;
using EventManagement.ConcertAggregate;
using EventManagement.Infrastructure;
using EventManagement.Infrastructure.Persistence;
using EventManagement.SeatTypeAggregate;
using EventStore.ClientAPI;
using Infrastructure.EventStore;
using OrderManagement.Domain.OrderAggregate;
using OrderManagement.Domain.Services;
using OrderManagement.OrderAggregate;
using Shared.Json;
using Shared.Models.Money;
using Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleTesting
{

    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<OrderItem>
            {
                new OrderItem("",12),
                new OrderItem("",11)
            };

            var order = new Order(new OrderId(), "123", items, new DefaultPriceCalculator());

            var orders = new EventStoreRepository<Order>();

            //orders.Store(order);

            var order1 = orders.Load("22be8707-b381-4e42-81ea-398419268ea5");

            IConcertRepository concerts = new JsonConcertRepository(
               new JsonParser<Concert>(),
               new StorageOptions("ConcertsJson")
               );

            var createConcertCommandResult = new CreateNewConcertCommand(concerts,
                "Geo Title",
                "Eng Title",
                "Descirption",
                DateTime.Now.AddDays(12)
                ).Execute();


            ISeatTypeRepository seatTypes = new JsonSeatTypeRepository(
                new JsonParser<SeatType>(),
                new StorageOptions("SeatTypesJson")
                );

            var efRepo = new EFConcertRepository(new EventContext());

            var createSeatTypeCommanResult = new CreateSeatTypeCommand(seatTypes,
                createConcertCommandResult.CreatedAggregateRootId.Value,
                "first Sector",
                100,
                new Money("GEL", 20)
                ).Execute();

            


        }
    }
}

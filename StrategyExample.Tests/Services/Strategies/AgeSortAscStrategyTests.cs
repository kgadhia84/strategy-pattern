﻿using FizzWare.NBuilder;
using FluentAssertions;
using StrategyExample.Data;
using StrategyExample.Models;
using StrategyExample.Services.Strategies;
using Xunit;

namespace StrategyExample.Tests.Services.Strategies
{
    public class AgeSortAscStrategyTests
    {
        [InlineData(ExampleSortOrder.AgeAsc, true)]
        [InlineData(ExampleSortOrder.AgeDesc, false)]
        [InlineData(ExampleSortOrder.NameAsc, false)]
        [InlineData(ExampleSortOrder.NameDesc, false)]
        [Theory]
        public void Accepts_Valid(ExampleSortOrder sortOrder, bool expected)
        {
            var sut = CreateSut();

            var result = sut.Accepts(sortOrder);

            result.Should().Be(expected);
        }

        [Fact]
        public void Process_SortsByAgeAsc_Valid()
        {
            var sut = CreateSut();

            var data = Builder<ExampleData>.CreateListOfSize(10).Build();

            var result = sut.Process(data);

            result.Should().BeInAscendingOrder(x => x.Age);
        }

        private static IExampleSortStrategy CreateSut()
        {
            return new AgeSortAscStrategy();
        }
    }
}

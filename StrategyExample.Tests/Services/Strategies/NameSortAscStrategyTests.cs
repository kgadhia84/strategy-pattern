using FizzWare.NBuilder;
using FluentAssertions;
using StrategyExample.Data;
using StrategyExample.Models;
using StrategyExample.Services.Strategies;
using Xunit;

namespace StrategyExample.Tests.Services.Strategies
{
    public class NameSortAscStrategyTests
    {
        [InlineData(ExampleSortOrder.NameAsc, true)]
        [InlineData(ExampleSortOrder.AgeDesc, false)]
        [InlineData(ExampleSortOrder.AgeAsc, false)]
        [InlineData(ExampleSortOrder.NameDesc, false)]
        [Theory]
        public void Accepts_Valid(ExampleSortOrder sortOrder, bool expected)
        {
            var sut = CreateSut();

            var result = sut.Accepts(sortOrder);

            result.Should().Be(expected);
        }

        [Fact]
        public void Process_SortsByNameAsc_Valid()
        {
            var sut = CreateSut();

            var data = Builder<ExampleData>.CreateListOfSize(10).Build();

            var result = sut.Process(data);

            result.Should().BeInAscendingOrder(x => x.Name);
        }

        private static IExampleSortStrategy CreateSut()
        {
            return new NameSortAscStrategy();
        }
    }
}
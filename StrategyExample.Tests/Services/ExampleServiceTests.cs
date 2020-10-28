using FluentAssertions;
using Moq;
using StrategyExample.Data;
using StrategyExample.Models;
using StrategyExample.Services;
using StrategyExample.Services.Strategies;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using Xunit;

namespace StrategyExample.Tests.Services
{
    public class ExampleServiceTests
    {
        private readonly Mock<IEnumerable<IExampleSortStrategy>> _strategies = new Mock<IEnumerable<IExampleSortStrategy>>();

        [Fact]
        public void Process_Returns_EmptyCollection_Success()
        {
            var sut = CreateSut();

            var strategy = new Mock<IExampleSortStrategy>();
            strategy.Setup(x => x.Accepts(It.IsAny<ExampleSortOrder>()))
                .Returns(() => false);

            _strategies.Setup(strategies => strategies.GetEnumerator())
                .Returns(() => new List<IExampleSortStrategy>
                {
                    strategy.Object
                }.GetEnumerator());

            var result = sut.Process(new ExampleRequest());

            result.Should().BeEquivalentTo(Enumerable.Empty<ExampleResponse>());
            strategy.Verify(x => x.Accepts(It.IsAny<ExampleSortOrder>()), Times.Once);
            strategy.Verify(x => x.Process(It.IsAny<IEnumerable<ExampleData>>()), Times.Never);
        }

        [Fact]
        public void Process_Returns_SortedCollection_Success()
        {
            var sut = CreateSut();

            var data = Builder<ExampleData>.CreateListOfSize(10).Build();

            var strategy = new Mock<IExampleSortStrategy>();
            strategy.Setup(x => x.Accepts(It.IsAny<ExampleSortOrder>()))
                .Returns(() => true);

            strategy.Setup(x => x.Process(It.IsAny<IEnumerable<ExampleData>>()))
                .Returns(() => data);

            _strategies.Setup(strategies => strategies.GetEnumerator())
                .Returns(() => new List<IExampleSortStrategy>
                {
                    strategy.Object
                }.GetEnumerator());

            var result = sut.Process(new ExampleRequest
            {
                SortOrder = ExampleSortOrder.AgeAsc
            });

            result.Should()
                .BeEquivalentTo(data)
                .And
                .HaveCount(10);
            strategy.Verify(x => x.Accepts(It.IsAny<ExampleSortOrder>()), Times.Once);
            strategy.Verify(x => x.Process(It.IsAny<IEnumerable<ExampleData>>()), Times.Once);
        }

        private IExampleService CreateSut()
        {
            return new ExampleService(_strategies.Object);
        }
    }
}
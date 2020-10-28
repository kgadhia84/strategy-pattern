using StrategyExample.Data;
using StrategyExample.Models;
using StrategyExample.Services.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace StrategyExample.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IEnumerable<IExampleSortStrategy> _sortStrategies;
        private readonly List<ExampleData> _data;

        public ExampleService(IEnumerable<IExampleSortStrategy> sortStrategies)
        {
            _sortStrategies = sortStrategies;
            _data = new List<ExampleData>
            {
                new ExampleData
                {
                    Name = "Test 1",
                    Age = 18
                },
                new ExampleData
                {
                    Name = "Test 2",
                    Age = 19
                },
                new ExampleData
                {
                    Name = "Test 3",
                    Age = 20
                },
                new ExampleData
                {
                    Name = "Test 4",
                    Age = 21
                },
                new ExampleData
                {
                    Name = "Test 5",
                    Age = 22
                }
            };
        }

        public IEnumerable<ExampleResponse> Process(ExampleRequest request)
        {
            // is there an available sort strategy
            var strategy = _sortStrategies.FirstOrDefault(sortStrategy => sortStrategy.Accepts(request.SortOrder));

            // if not return empty response
            if (strategy == null)
            {
                return Enumerable.Empty<ExampleResponse>();
            }

            // sort data using request sort order key
            var sortedData = strategy.Process(_data);

            return sortedData?.Select(data => new ExampleResponse
            {
                Age = data.Age,
                Name = data.Name
            });
        }
    }
}
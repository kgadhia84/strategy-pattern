using StrategyExample.Data;
using StrategyExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace StrategyExample.Services.Strategies
{
    public class AgeSortDescStrategy : IExampleSortStrategy
    {
        public bool Accepts(ExampleSortOrder sortOrder)
        {
            return sortOrder == ExampleSortOrder.AgeDesc;
        }

        public IEnumerable<ExampleData> Process(IEnumerable<ExampleData> data)
        {
            return data.OrderByDescending(exampleData => exampleData.Age);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using StrategyExample.Data;
using StrategyExample.Models;

namespace StrategyExample.Services.Strategies
{
    public class NameSortDescStrategy : IExampleSortStrategy
    {
        public bool Accepts(ExampleSortOrder sortOrder)
        {
            return sortOrder == ExampleSortOrder.NameDesc;
        }

        public IEnumerable<ExampleData> Process(IEnumerable<ExampleData> data)
        {
            return data.OrderByDescending(exampleData => exampleData.Name);
        }
    }
}
using System.Collections.Generic;
using StrategyExample.Data;
using StrategyExample.Models;

namespace StrategyExample.Services.Strategies
{
    public interface IExampleSortStrategy
    {
        bool Accepts(ExampleSortOrder sortOrder);

        IEnumerable<ExampleData> Process(IEnumerable<ExampleData> data);
    }
}
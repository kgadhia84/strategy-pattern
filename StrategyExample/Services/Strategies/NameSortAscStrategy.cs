﻿using StrategyExample.Data;
using StrategyExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace StrategyExample.Services.Strategies
{
    public class NameSortAscStrategy : IExampleSortStrategy
    {
        public bool Accepts(ExampleSortOrder sortOrder)
        {
            return sortOrder == ExampleSortOrder.NameAsc;
        }

        public IEnumerable<ExampleData> Process(IEnumerable<ExampleData> data)
        {
            return data.OrderBy(exampleData => exampleData.Name);
        }
    }
}
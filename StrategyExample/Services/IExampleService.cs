using StrategyExample.Models;
using System.Collections.Generic;

namespace StrategyExample.Services
{
    public interface IExampleService
    {
        IEnumerable<ExampleResponse> Process(ExampleRequest request);
    }
}
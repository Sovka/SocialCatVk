using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suhorukov.Network.Socialcat.Interfaces
{
    public interface IResultsHandler<T>
    {
        void HandleResults(IEnumerable<T> results);

        void HandleResult(T result);

    }
}

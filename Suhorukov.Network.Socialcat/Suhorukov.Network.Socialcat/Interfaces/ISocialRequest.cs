using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Suhorukov.Network.Socialcat.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISocialRequest<TResult,TParams>
    {
        /// <summary>
        /// 
        /// </summary>
        ISocialSession Session { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<TResult> GetRecords(TParams parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TResult GetRecord(TParams parameters);
    }
}

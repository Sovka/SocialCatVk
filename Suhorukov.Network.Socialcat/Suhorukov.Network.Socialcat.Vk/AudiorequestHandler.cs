using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suhorukov.Network.Socialcat.Interfaces;
using Suhorukov.Network.Socialcat.Vk.Data;

namespace Suhorukov.Network.Socialcat.Vk
{
    class AudioRequestHandler : ISocialRequest<AudioInfo,AudioSearchParameters>
    {
        public AudioRequestHandler(ISocialSession session)
        {
            Session = session;
        }
//
        public ISocialSession Session { get; private set; }

        public IEnumerable<AudioInfo> GetRecords(AudioSearchParameters parameters)
        {
            var reqResult = Session.PerformRequest("/audios", );
            List<AudioInfo> l = new List<AudioInfo>();
        }

        public AudioInfo GetRecord(AudioSearchParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}

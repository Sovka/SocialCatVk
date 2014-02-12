using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Suhorukov.Network.Socialcat.Interfaces;

namespace Suhorukov.Network.Socialcat.Vk
{
    public class VkSocialSession : ISocialSession
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string BaseUri { get { return "vk.com"; } }

        public NameValueCollection Cookies { get; private set; }

        public void Authorize(string userName, string password)
        {
            //wr.Proxy = new WebProxy("192.168.0.106",3128);
            WebClient wc = new WebClient();
            var s = wc.DownloadString(string.Format("https://m.{0}", BaseUri));

            Regex r = new Regex(@"action=""([a-zA-Z\:\/.\?=&_0-9]*)\""");
            var m = r.Matches(s);
            var match = m[0];
            var g = match.Groups[1];
            var reqUrl = g.Value;

            string credentials = string.Format("email={0}%40pass={1}", userName, password);
            HttpWebRequest wr = (HttpWebRequest) HttpWebRequest.Create(reqUrl);
            wr.AllowAutoRedirect = true;
            wr.Proxy = new WebProxy("192.168.0.106", 3128);
            wr.Method = "POST";
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.GetRequestStream().Write(Encoding.UTF8.GetBytes(credentials),0,1);
            wr.GetRequestStream().Flush();
            var resp = wr.GetResponse();
            var cookies = resp.Headers[HttpResponseHeader.SetCookie];

            var istream = resp.GetResponseStream();
            TextReader tr = new StreamReader(istream);
            string result = tr.ReadToEnd();

        }

        public string PerformRequest(string path, NameValueCollection parameters)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected { get; private set; }
    }
}

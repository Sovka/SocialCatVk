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
            var request = (HttpWebRequest)WebRequest.Create(string.Format("http://vk.com/login.php?act=auth_result&m=4&permanent=1&install=1&expire=0&app={0}&to=&__q_hash=11bc4a0ffe7ecc35625a53cecd0ae805",
                    AppId));
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] buffer = Encoding.UTF8.GetBytes(string.Format("email={0}%40pass={1}", userName, password));
            request.ContentLength = buffer.Length;
            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(buffer, 0, buffer.Length);
            }
            var istream = request.GetResponse().GetResponseStream();
            string result = string.Empty;
            if (istream != null)
            {
                var tr = new StreamReader(istream);
                result = tr.ReadToEnd();
            }            
            
            //var wc = new WebClient();
            //var s = wc.DownloadString(string.Format("https://m.{0}", BaseUri));

            //var r = new Regex(@"action=""([a-zA-Z\:\/.\?=&_0-9]*)\""");
            //var m = r.Matches(s);
            //var match = m[0];
            //var g = match.Groups[1];
            //var reqUrl = g.Value;

            //string credentials = string.Format("email={0}%40pass={1}", userName, password);
            //var wr = (HttpWebRequest)WebRequest.Create(reqUrl);
            //wr.AllowAutoRedirect = true;
            ////wr.Proxy = new WebProxy("192.168.0.106", 3128);
            //wr.Method = "POST";
            //wr.ContentType = "application/x-www-form-urlencoded";
            //wr.GetRequestStream().Write(Encoding.UTF8.GetBytes(credentials), 0, 1);
            //wr.GetRequestStream().Flush();
            //var resp = wr.GetResponse();
            //var cookies = resp.Headers[HttpResponseHeader.SetCookie];

            //var istream = resp.GetResponseStream();
            //if (istream != null)
            //{
            //    var tr = new StreamReader(istream);
            //    string result = tr.ReadToEnd();
            //}

        }

        public string PerformRequest(string path, NameValueCollection parameters)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected { get; private set; }
    }
}

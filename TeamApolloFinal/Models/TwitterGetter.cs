using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace TeamApolloFinal.Models
{
    public class TwitterGetter
    {
        public static List<Tweets> tweetLst = new List<Tweets>();

        static void Main(string[] args)
        {
            string consumerKey = "moDgZkEvWnLEeNDyrOpZk0Psr";
            string consumerSecret = "EVY887yGI3zaJKmUq6bK3gZjLRPsLnb7sAUuCxvGstkfzrEhBh";
            string accessToken = "785929378316242944-KGsyQ1kWEMzce6MsuF8dxwj422FCwrR";
            string accessTokenSecret = "psu0BoU8GZCP2W2JtHRuFAVoHi7zXpZ5n3IiGeHW3tC0k";

            string URL = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            Dictionary<string, string> parameters = new Dictionary<string, string>() { { "q", "zzz" } };

            WebRequest request = CreateRequest(
                consumerKey, consumerSecret, accessToken, accessTokenSecret,
                "GET", URL, parameters);

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        //Console.Write(reader.ReadToEnd());    <---outputs jSon data

                        string jSonStr = reader.ReadToEnd();

                        JArray o = JArray.Parse(jSonStr);

                        for (int i = 0; i < o.Count(); i++)
                        {
                            //Console.WriteLine(o[i]["text"].ToString());   <---outputs tweet
                            Tweets tweet = new Tweets();
                            tweet.Tweet = o[i]["text"].ToString();
                            tweetLst.Add(tweet);
                        }
                    }
                }
            }
        }

        static public WebRequest CreateRequest(
            string consumerKey, string consumerSecret, string accessToken, string accessKey,
            string method, string url, Dictionary<string, string> parameters)
        {
            string encodedParams = EncodeParameters(parameters);

            WebRequest request;
            if (method == "GET")
                request = WebRequest.Create(string.Format("{0}?{1}", url, encodedParams));
            else
                request = WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add(
                "Authorization",
                MakeOAuthHeader(consumerKey, consumerSecret, accessToken, accessKey, method, url, parameters));

            if (method == "POST")
            {
                byte[] postBody = new ASCIIEncoding().GetBytes(encodedParams);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(postBody, 0, postBody.Length);
                }
            }

            return request;
        }

        static string EncodeParameters(Dictionary<string, string> parameters)
        {
            if (parameters.Count == 0)
                return string.Empty;
            Dictionary<string, string>.KeyCollection.Enumerator keys = parameters.Keys.GetEnumerator();
            keys.MoveNext();
            StringBuilder sb = new StringBuilder(
                string.Format("{0}={1}", keys.Current, Uri.EscapeDataString(parameters[keys.Current])));
            while (keys.MoveNext())
                sb.AppendFormat("&{0}={1}", keys.Current, Uri.EscapeDataString(parameters[keys.Current]));
            return sb.ToString();
        }

        static string MakeOAuthHeader(string consumerKey, string consumerSecret, string accessToken, string accessKey,
            string method, string url, Dictionary<string, string> parameters)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            string oauth_consumer_key = consumerKey;
            string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            string oauth_signature_method = "HMAC-SHA1";
            string oauth_token = accessToken;
            string oauth_timestamp = Convert.ToInt64(ts.TotalSeconds).ToString();
            string oauth_version = "1.0";

            SortedDictionary<string, string> sd = new SortedDictionary<string, string>();
            if (parameters != null)
                foreach (string key in parameters.Keys)
                    sd.Add(key, Uri.EscapeDataString(parameters[key]));
            sd.Add("oauth_version", oauth_version);
            sd.Add("oauth_consumer_key", oauth_consumer_key);
            sd.Add("oauth_nonce", oauth_nonce);
            sd.Add("oauth_signature_method", oauth_signature_method);
            sd.Add("oauth_timestamp", oauth_timestamp);
            sd.Add("oauth_token", oauth_token);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}&{1}&", method, Uri.EscapeDataString(url));
            foreach (KeyValuePair<string, string> entry in sd)
                sb.Append(Uri.EscapeDataString(string.Format("{0}={1}&", entry.Key, entry.Value)));
            string baseString = sb.ToString().Substring(0, sb.Length - 3);

            string oauth_token_secret = accessKey;
            string signingKey = string.Format(
                "{0}&{1}", Uri.EscapeDataString(consumerSecret), Uri.EscapeDataString(oauth_token_secret));
            HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(signingKey));
            string oauth_signature = Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(baseString)));

            sb = new StringBuilder("OAuth ");
            sb.AppendFormat("oauth_consumer_key=\"{0}\",", Uri.EscapeDataString(oauth_consumer_key));
            sb.AppendFormat("oauth_nonce=\"{0}\",", Uri.EscapeDataString(oauth_nonce));
            sb.AppendFormat("oauth_signature=\"{0}\",", Uri.EscapeDataString(oauth_signature));
            sb.AppendFormat("oauth_signature_method=\"{0}\",", Uri.EscapeDataString(oauth_signature_method));
            sb.AppendFormat("oauth_timestamp=\"{0}\",", Uri.EscapeDataString(oauth_timestamp));
            sb.AppendFormat("oauth_token=\"{0}\",", Uri.EscapeDataString(oauth_token));
            sb.AppendFormat("oauth_version=\"{0}\"", Uri.EscapeDataString(oauth_version));

            return sb.ToString();
        }
    }
}
    
  
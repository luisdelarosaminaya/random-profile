using System;

using System.Net;
using System.Resources;


namespace RandomProfileApp.Data
{
    static class API
    {
        private static WebClient _client;
        private static string _api;

        static API()
        {
            using (ResXResourceSet resxSet = new ResXResourceSet("Resources.resx"))
            {
                _api = resxSet.GetString("API");
                _client = new WebClient();
            }
        }
        public static string GET
        {
            get
            {
                try
                {
                    return _client.DownloadString(_api);
                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (WebException)
                {
                    throw;
                }
                catch (NotSupportedException)
                {
                    throw;
                }
            }
        }
    }
}
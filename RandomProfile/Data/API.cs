using System;

using System.Net;
using System.Resources;


namespace RandomProfileApp.Data
{
    static class API
    {
        private static readonly object _downloadStringLock = new object();

        private static WebClient _client;
        private static string _api;

        static API()
        {
            using (ResXResourceSet resxSet = new ResXResourceSet("Resources.resx"))
            {
                try
                {
                    _api = resxSet.GetString("API");
                    _client = new WebClient();
                }
                catch (Exception)
                {
                    throw;
                }                
            }
        }
        public static void GetData(DownloadStringCompletedEventHandler downloadStringCompleted)
        {
            try
            {
                _client.DownloadStringCompleted += downloadStringCompleted;
                _client.DownloadStringAsync(new Uri(_api), _downloadStringLock);                
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (WebException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
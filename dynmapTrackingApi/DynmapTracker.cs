using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace dynmapTrackingApi
{
    public class DynmapTracker
    {
        public class Tracker{
            public Tracker(string mapLink)
            {
                MapLink = mapLink;
            }

            public string MapLink { get; private set; }

            public async System.Threading.Tasks.Task<JObject> GetRawDataAsync()
            {
                var httpClient = new HttpClient();
                var data = httpClient.GetAsync(MapLink);
                var bodyData = await data.Result.Content.ReadAsStringAsync();
                return JObject.Parse(bodyData);
            }
        }
        

    }
}

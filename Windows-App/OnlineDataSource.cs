using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App
{
    class OnlineDataSource
    {
        public static OnlineDataSource singleton = new OnlineDataSource();

        private string baseUrl = "http://localhost:54191/api/";

        public async Task<ObservableCollection<Business>> fetchBusinesses()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "businesses/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Business>>(json);
        }

        public async Task<Business> fetchBusinessWithId(int id)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "businesses/"+id));
            return JsonConvert.DeserializeObject<Business>(json);
        }
    }
}

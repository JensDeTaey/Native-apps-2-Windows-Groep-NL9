using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App
{
    class OnlineDataSource : IDataSource
    {

        private string baseUrl = "http://localhost:52420/api/";

        protected override Task<AuthenticationBearer> GetAuthenticationBearer(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override async Task<ObservableCollection<Business>> FetchBusinesses()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "Businesses/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Business>>(json);
        }

        public override async Task<Business> FetchBusinessWithId(int id)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "Businesses/"+id));
            return JsonConvert.DeserializeObject<Business>(json);
        }

        public override async Task<ObservableCollection<Promotion>> FetchPromotions()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "Promotions/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Promotion>>(json);
        }

        public override async Task<ObservableCollection<Event>> FetchEvents()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri(baseUrl + "Events/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(json);
        }
    }
}

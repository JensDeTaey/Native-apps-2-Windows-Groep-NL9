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

        public override async Task<bool> AddEstablishment(int businessId,Establishment establishment)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(baseUrl + "Businesses/" + businessId + "/AddEstablishment"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(establishment));
            var json = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            try
            {
                JsonConvert.DeserializeObject<Establishment>(json);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> EditEstablishment(Establishment establishment)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(baseUrl + "Establishments/" + establishment.Id));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(establishment));
            var json = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            try
            {
                JsonConvert.DeserializeObject<Establishment>(json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> DeleteEstablishment(Establishment establishment)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, new Uri(baseUrl + "Establishments/" + establishment.Id));
            var json = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            try
            {
                JsonConvert.DeserializeObject<Establishment>(json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

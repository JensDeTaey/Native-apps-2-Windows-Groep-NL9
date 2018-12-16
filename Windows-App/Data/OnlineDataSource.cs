using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App
{
    class OnlineDataSource : IDataSource
    {

        #region Boring stuff
        private string BaseUrl = "http://localhost:52420/api/";
        private HttpClient _httpClient;
        private HttpClient HttpClient {
            get {
                _httpClient.DefaultRequestHeaders.Authorization = token;
                return _httpClient;
            }
            set {
                this._httpClient = value;
            }
        }
        private AuthenticationHeaderValue token {
            get {
                //TODO Hier juiste token zetten
                return new AuthenticationHeaderValue("Bearer", "Token yeees");
            }
        }

        public OnlineDataSource()
        {
            HttpClient = new HttpClient();
        }
        #endregion
        
        #region Main Pages Getters
        public override async Task<ObservableCollection<Business>> FetchBusinesses()
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "Businesses/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Business>>(json);
        }

        public override async Task<ObservableCollection<Promotion>> FetchPromotions()
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "Promotions/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Promotion>>(json);
        }

        public override async Task<ObservableCollection<Event>> FetchEvents()
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "Events/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(json);
        }
        public override Task<ObservableCollection<Business>> FetchSubscribedBusinesses()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Business Actions
        public override async Task<Business> FetchBusinessWithId(int id)
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "Businesses/" + id));
            return JsonConvert.DeserializeObject<Business>(json);
        }

        public override Task<bool> EditBusiness(Business business)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> SubscribeToBusiness(int businessId)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UnsubscribeFromBusiness(int businessId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Establishment CRUD
        public override async Task<bool> AddEstablishment(int businessId, Establishment establishment)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUrl + "Businesses/" + businessId + "/AddEstablishment"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(establishment));
            var json = await HttpClient.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
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

        public override async Task<bool> EditEstablishment(Establishment establishment)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(BaseUrl + "Establishments/" + establishment.Id));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(establishment));
            var json = await HttpClient.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
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
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, new Uri(BaseUrl + "Establishments/" + establishment.Id));
            var json = await HttpClient.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
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
        #endregion

        #region Promotion CRUD
        public override Task<bool> AddPromotion(int establishmentId, Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> EditPromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeletePromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event CRUD
        public override Task<bool> AddEvent(int establishmentId, Event @event)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> EditEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteEvent(Event @event)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

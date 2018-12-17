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
                return authenticationBearer == null? null:  new AuthenticationHeaderValue("Bearer", authenticationBearer.AccessToken);
            }
        }


        protected override async Task<AuthenticationBearer> GetAuthenticationBearer(string username, string password)
        {
            
            using (var httpClient = new HttpClient())
            {
                Collection<KeyValuePair<string, string>> postData = new Collection<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", username));
                postData.Add(new KeyValuePair<string, string>("password", password));

                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await httpClient.PostAsync(new Uri(BaseUrl + "Login"), content);

                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AuthenticationBearer>(json);
                }
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
            var res = JsonConvert.DeserializeObject<ObservableCollection<Business>>(json);

            return res;
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
        public override async Task<ObservableCollection<Business>> FetchSubscribedBusinesses()
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "SubscribedBusinesses/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Business>>(json);
        }
        #endregion

        #region Business Actions
        public override async Task<Business> FetchBusinessWithId(int id)
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "Businesses/" + id));
            return JsonConvert.DeserializeObject<Business>(json);
        }

        public override async Task<Business> FetchMyBusiness()
        {
            var json = await HttpClient.GetStringAsync(new Uri(BaseUrl + "MyBusiness"));
            return JsonConvert.DeserializeObject<Business>(json);
        }

        public override async Task<bool> EditBusiness(Business business)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(BaseUrl + "Businesses/" + business.Id));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(business),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> SubscribeToBusiness(int businessId)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUrl + "Businesses/" + businessId));
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }

        public override async Task<bool> UnsubscribeFromBusiness(int businessId)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUrl + "Businesses/" + businessId));
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        #endregion

        #region Establishment CRUD
        public override async Task<bool> AddEstablishment(int businessId, Establishment establishment)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUrl + "Businesses/" + businessId + "/AddEstablishment"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(establishment),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> EditEstablishment(Establishment establishment)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(BaseUrl + "Establishments/" + establishment.Id));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(establishment),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> DeleteEstablishment(Establishment establishment)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, new Uri(BaseUrl + "Establishments/" + establishment.Id));
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        #endregion

        #region Promotion CRUD
        public override async Task<bool> AddPromotion(int establishmentId, Promotion promotion)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUrl + "Establishments/" + establishmentId + "/AddPromotion"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(promotion),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> EditPromotion(Promotion promotion)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(BaseUrl + "Promotions/" + promotion.Id));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(promotion),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> DeletePromotion(Promotion promotion)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, new Uri(BaseUrl + "Promotions/" + promotion.Id));
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        #endregion

        #region Event CRUD
        public override async Task<bool> AddEvent(int establishmentId, Event @event)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUrl + "Establishments/" + establishmentId + "/AddEvent"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(@event),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> EditEvent(Event @event)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(BaseUrl + "Events/" + @event.Id));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(@event),
                                    Encoding.UTF8,
                                    "application/json");
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public override async Task<bool> DeleteEvent(Event @event)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, new Uri(BaseUrl + "Events/" + @event.Id));
            var response = await HttpClient.SendAsync(requestMessage);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        #endregion

    }
}

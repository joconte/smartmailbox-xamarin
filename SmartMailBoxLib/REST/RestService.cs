using SmartMailBoxLib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace SmartMailBoxLib.REST
{
    internal class RestService
    {
        public HttpClient _client;
        private static RestService instance = null;
        private static readonly object padlock = new object();

        RestService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Constants.BaseAdresse);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static RestService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RestService();
                    }
                    return instance;
                }
            }
        }

        public void Logout()
        {
            instance = null;
            _client = null;
        }

        public async Task<T> PostResponse<T>(string url, string jsonstring) where T : class
        {
            string contentType = "application/json";
            try
            {
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, contentType);
                var result = await _client.PostAsync(url, httpContent);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch
                    {

                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }





        public HttpStatusCode PostResponse(string url, string jsonstring)
        {
            string ContentType = "application/json";
            try
            {
                jsonstring = jsonstring == null ? "" : jsonstring;
                var Result = _client.PostAsync(url, new StringContent(jsonstring, Encoding.UTF8, ContentType)).Result;
                return Result.StatusCode;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }

        }


        public T PutResponse<T>(string url, string jsonstring, out HttpStatusCode outCode, out string errorJson) where T : class
        {
            outCode = HttpStatusCode.BadRequest;
            string ContentType = "application/json";
            errorJson = null;
            try
            {
                jsonstring = jsonstring ?? "";
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, ContentType);
                var result = _client.PutAsync(url, httpContent).Result;
                var jsonResult = result.Content.ReadAsStringAsync().Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    outCode = HttpStatusCode.OK;

                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch
                    {

                        return null;
                    }
                }
                else
                {
                    errorJson = jsonResult;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        public T GetResponse<T>(string url) where T : class
        {
            try
            {
                var response = _client.GetAsync(url).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return contentResp;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }


       

        public GenericObjectWithErrorModel<T> PostReponse<T>(string url, string jsonstring) where T : class
        {
            string contentType = "application/json";
            jsonstring = jsonstring ?? "";
            var httpContent = new StringContent(jsonstring, Encoding.UTF8, contentType);
            var Result = _client.PostAsync(url, httpContent).Result;
            var JsonResult = Result.Content.ReadAsStringAsync().Result;
            var genericObjectWithModelStateErrorToreturn = JsonConvert.DeserializeObject<GenericObjectWithErrorModel<T>>(JsonResult);
            return genericObjectWithModelStateErrorToreturn;
        }

        public GenericObjectWithErrorModel<T> PutResponse<T>(string url, string jsonstring) where T : class
        {
            const string contentType = "application/json";
            jsonstring = jsonstring ?? "";
            var httpContent = new StringContent(jsonstring, Encoding.UTF8, contentType);
            var result = _client.PutAsync(url, httpContent).Result;
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var genericObjectWithModelStateErrorToreturn = JsonConvert.DeserializeObject<GenericObjectWithErrorModel<T>>(jsonResult);
            return genericObjectWithModelStateErrorToreturn;
        }


    }
}

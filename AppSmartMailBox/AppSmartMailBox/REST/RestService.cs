using AppSmartMailBox.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace AppSmartMailBox.REST
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.BaseAdresse);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        //Login api avec token

        //Login api avec token
        public async Task<string> Login(Utilisateur utilisateur)
        {
            var postData = new List<KeyValuePair<string, string>>();
            
            string response = PostReponseLogin(Constants.LoginUrl, utilisateur);
            /*
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expires_in);
            */
            client.DefaultRequestHeaders.Authorization
                     = new AuthenticationHeaderValue("Bearer", response);
            //client.DefaultRequestHeaders.Add("api-version", 1.ToString());
            return response;
        }
        //réponse api 
        /*
        public async Task<T> PostResponseLogin<T>(string url, Utilisateur utilisateur) where T : class
        {
            string ContentType = "application/json";
            var jsonUtilisateur = JsonConvert.SerializeObject(utilisateur);
            var httpContent = new StringContent(jsonUtilisateur, Encoding.UTF8, ContentType);
            var response = await client.PostAsync(url, httpContent);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }*/



        public async Task<T> PostResponse<T>(string url, string jsonstring) where T : class
        {
            string ContentType = "application/json";
            try
            {
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, ContentType);
                var Result = await client.PostAsync(url, httpContent);
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
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
                var Result = client.PostAsync(url, new StringContent(jsonstring, Encoding.UTF8, ContentType)).Result;
                return Result.StatusCode;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }

        }


        public T PutResponse<T>(string url, string jsonstring, out HttpStatusCode outCode, out string errorJSON) where T : class
        {
            outCode = HttpStatusCode.BadRequest;
            string ContentType = "application/json";
            errorJSON = null;
            try
            {
                jsonstring = jsonstring == null ? "" : jsonstring;
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, ContentType);
                var Result = client.PutAsync(url, httpContent).Result;
                var JsonResult = Result.Content.ReadAsStringAsync().Result;
                if (Result.StatusCode == HttpStatusCode.OK)
                {
                    outCode = HttpStatusCode.OK;

                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return contentResp;
                    }
                    catch
                    {

                        return null;
                    }
                }
                else
                {
                    errorJSON = JsonResult;
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
                var response = client.GetAsync(url).Result;
                //Lors d'une deco reco on a BAD REQUEST ICI, à voir pourquoi. 
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
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


        public string PostReponseLogin(string url, Utilisateur utilisateur)
        {
            string token = null;
            string ContentType = "application/json";
            try
            {
                string jsonstring = JsonConvert.SerializeObject(utilisateur);
                jsonstring = jsonstring == null ? "" : jsonstring;
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, ContentType);
                var Result = client.PostAsync(url, httpContent).Result;
                var JsonResult = Result.Content.ReadAsStringAsync().Result;
                //genericObjectWithModelStateErrorTORETURN.HttpStatusCode = Result.StatusCode;

                try
                {
                    token = JsonResult;
                }
                catch
                {

                }
            }
            catch (Exception)
            {

            }
            return token;
        }

        public GenericObjectWithErrorModel<T> PostReponse<T>(string url, string jsonstring) where T : class
        {
            GenericObjectWithErrorModel<T> genericObjectWithModelStateErrorTORETURN = new GenericObjectWithErrorModel<T>();
            string ContentType = "application/json";
            try
            {
                jsonstring = jsonstring == null ? "" : jsonstring;
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, ContentType);
                var Result = client.PostAsync(url, httpContent).Result;
                var JsonResult = Result.Content.ReadAsStringAsync().Result;
                //genericObjectWithModelStateErrorTORETURN.HttpStatusCode = Result.StatusCode;

                try
                {
                    genericObjectWithModelStateErrorTORETURN = JsonConvert.DeserializeObject<GenericObjectWithErrorModel<T>>(JsonResult);
                }
                catch
                {

                }
            }
            catch (Exception)
            {

            }
            return genericObjectWithModelStateErrorTORETURN;
        }

        public GenericObjectWithErrorModel<T> PutResponse<T>(string url, string jsonstring) where T : class
        {
            GenericObjectWithErrorModel<T> genericObjectWithModelStateErrorTORETURN = new GenericObjectWithErrorModel<T>();
            string ContentType = "application/json";
            try
            {
                jsonstring = jsonstring == null ? "" : jsonstring;
                var httpContent = new StringContent(jsonstring, Encoding.UTF8, ContentType);
                var Result = client.PutAsync(url, httpContent).Result;
                var JsonResult = Result.Content.ReadAsStringAsync().Result;
                //genericObjectWithModelStateErrorTORETURN.HttpStatusCode = Result.StatusCode;
                
                try
                {
                    genericObjectWithModelStateErrorTORETURN = JsonConvert.DeserializeObject<GenericObjectWithErrorModel<T>>(JsonResult);
                }
                catch
                {

                }
            }
            catch (Exception)
            {

            }
            return genericObjectWithModelStateErrorTORETURN;
        }

        public byte[] GetFile(string url)
        {
            try
            {
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsByteArrayAsync().Result;
                    /*try
                    {
                        DependencyService.Get<IFileReader>().SaveandOpenFile(JsonResult, "test");
                        return null;
                    }
                    catch
                    {

                        return null;
                    }*/
                    return JsonResult;
                }
            }
            catch (Exception)
            {

                return null;
            }
            return null;
        }

    }
}

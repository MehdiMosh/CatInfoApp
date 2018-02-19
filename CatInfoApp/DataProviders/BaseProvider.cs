using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace CatInfoApp.DataProviders
{
    public abstract class BaseProvider
    {
        protected T Get<T>(string path) where T : class
        {
            try
            {
                T result = null;
                using (var client = new HttpClient())
                {
                    client.GetAsync(path).ContinueWith((task) =>
                    {
                        var response = task.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        result = JsonConvert.DeserializeObject<T>(jsonString.Result);

                    }).Wait();
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Data Layer should not know about the UI (ConsoleApp, WebApp,...) This is just to demonstrate a simple exception handling. 
                Console.WriteLine("Failed to retrieve the list of owners. Error : " + ex.Message);
            }
            return null;
        }
    }
}

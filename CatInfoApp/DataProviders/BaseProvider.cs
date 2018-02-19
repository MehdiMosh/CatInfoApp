using System.Net.Http;
using Newtonsoft.Json;

namespace CatInfoApp.DataProviders
{
    public abstract class BaseProvider
    {
        protected T Get<T>(string path) where T : class
        {
            T result = null;
            using (var client = new HttpClient())
            {
                client.GetAsync(path).ContinueWith((task) => {
                    var response = task.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    result = JsonConvert.DeserializeObject<T>(jsonString.Result);

                }).Wait();
                return result;
            }
        }
    }
}

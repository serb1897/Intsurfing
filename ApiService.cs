using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntsurfingTest
{
    public class ApiService
    {
        public async Task<T> GetRequestAsync<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string contents = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(contents))
                            return default!;
                        
                        T result = JsonConvert.DeserializeObject<T>(contents);
                        if (result == null)
                        {
                            return default!;
                        }
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                return default!;
            }
        }
    }
}

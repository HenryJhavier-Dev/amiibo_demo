using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmiiboPedia.Helpers
{
    // API
    // https://www.amiiboapi.com/docs/#amiiboCharacter
    public class HttpHelper<T>
    {
        public async Task<T> GetRestServiceDataAsync(string url) {

            HttpClient client   = new HttpClient();
            string responseBody = string.Empty;

            try
            {
                //HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                //response.EnsureSuccessStatusCode();
                //responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                responseBody = await client.GetStringAsync(new Uri(url));

                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.Error.Write("\nException Caught!");
                Console.Error.Write("Message :{0} ", e.Message);
            }

            var result     = JsonConvert.DeserializeObject<T>(responseBody);

            return result;
        }
    }
}

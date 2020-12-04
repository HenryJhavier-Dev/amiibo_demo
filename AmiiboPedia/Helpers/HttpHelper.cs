﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmiiboPedia.Helpers
{
    // API
    // https://www.amiiboapi.com/docs/#amiiboCharacter
    public class HttpHelper<T>
    {
        public async void GetRestServiceDataAsync(string url) {

            HttpClient client   = new HttpClient();
            client.BaseAddress  = new Uri(url); 
            //var response        = await client.GetAsync(url);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();

            //var result     = JsonConvert.DeserializeObject<T>(responseBody);

            //return result;

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }


        }
    }
}

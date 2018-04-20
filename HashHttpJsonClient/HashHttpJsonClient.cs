using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace HashHttpJsonClient
{
    public class HashHttpJsonClient
    {
        private readonly HttpClient client = new HttpClient();
        private readonly DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(HashResponse));
        private readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(HashRequest));

        public HashHttpJsonClient()
        {
            client.BaseAddress = new Uri("http://localhost:7998");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Compute(string algorithm, byte[] bytes)
        {
            HashRequest request = new HashRequest(bytes);
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, request);
            byte[] json = ms.ToArray();

            var content = new StringContent(Encoding.UTF8.GetString(json, 0, json.Length), Encoding.UTF8, "application/json");

            var httpResponse = client.PostAsync($"/{algorithm}/compute", content);

            var jsonString = await httpResponse.Result.Content.ReadAsStringAsync();
            var response = deserializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(jsonString))) as HashResponse;
            return response.hash;
        }
    }
}

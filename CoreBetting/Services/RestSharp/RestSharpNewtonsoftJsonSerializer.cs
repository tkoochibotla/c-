using System;
using System.IO;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace CoreBetting.Interfaces
{
    public class RestSharpNewtonsoftJsonSerializer : ISerializer, IDeserializer
    {

        private static readonly Newtonsoft.Json.JsonSerializer Serializer =
            new Newtonsoft.Json.JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

        private static RestSharpNewtonsoftJsonSerializer _instance;

        public static RestSharpNewtonsoftJsonSerializer Default
            => _instance ?? (_instance = new RestSharpNewtonsoftJsonSerializer());

        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        private RestSharpNewtonsoftJsonSerializer() { }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    Serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            try
            {
                using (var stringReader = new StringReader(response.Content))
                {
                    using (var jsonTextReader = new JsonTextReader(stringReader))
                    {
                        return Serializer.Deserialize<T>(jsonTextReader);
                    }
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}

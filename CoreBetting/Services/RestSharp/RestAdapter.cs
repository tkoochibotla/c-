using System;
using Castle.DynamicProxy;
using RestSharp;

namespace CoreBetting.Services.RestSharp
{
    public class RestAdapter
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();
        private readonly IRestClient _restClient;

        public RestAdapter(Uri baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            AddHandlers();
        }

        public RestAdapter(string baseUrl) : this(new UriBuilder(baseUrl).Uri) { }

        public RestAdapter(IRestClient client)
        {
            _restClient = client;
            AddHandlers();
        }

        private void AddHandlers()
        {
            _restClient.AddHandler("text/html", RestSharpNewtonsoftJsonSerializer.Default);
            _restClient.AddHandler("application/json", RestSharpNewtonsoftJsonSerializer.Default);
            _restClient.AddHandler("text/json", RestSharpNewtonsoftJsonSerializer.Default);
            _restClient.AddHandler("text/x-json", RestSharpNewtonsoftJsonSerializer.Default);
            _restClient.AddHandler("text/javascript", RestSharpNewtonsoftJsonSerializer.Default);
            _restClient.AddHandler("*+json", RestSharpNewtonsoftJsonSerializer.Default);
        }

        public string Server { get; set; }

        public T Create<T>() where T : class =>
            Generator.CreateInterfaceProxyWithoutTarget<T>(new RestInterceptor(_restClient));


    }
}

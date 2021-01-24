using System.Linq;
using Castle.DynamicProxy;
using RestSharp;
using System.Net;

namespace CoreBetting.Services.RestSharp
{
    public class RestInterceptor : IInterceptor
    {
        private readonly IRestClient _restClient;

        public RestInterceptor(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public void Intercept(IInvocation invocation)
        {
            // Build Request
            var methodInfo = new RestMethodInfo(invocation.Method);
            var request = new RequestBuilder(methodInfo, invocation.Arguments).Build();
            var test = _restClient.BuildUri(request);

            // Execute request
            var genericTypeArguments = invocation.Method.ReturnType.GetGenericArguments();
            if (genericTypeArguments.Length > 0)
            {
                // We have to find the method manually due to limitations of GetMethod()
                var method = _restClient.GetType().GetMethods()
                    .Where(m => m.Name == "Execute").First(m => m.IsGenericMethod);
                var genericTypeArgument = genericTypeArguments.Length > 0 ? genericTypeArguments[0] : null;
                var generic = method.MakeGenericMethod(genericTypeArgument);
                ServicePointManager.ServerCertificateValidationCallback +=
        (sender, certificate, chain, sslPolicyErrors) => true;
                invocation.ReturnValue = generic.Invoke(_restClient, new object[] { request });
            }
            else
            {
                var method = _restClient.GetType().GetMethods()
                    .Where(m => m.Name == "Execute").First(m => !m.IsGenericMethod);
                invocation.ReturnValue = method.Invoke(_restClient, new object[] { request });
            }
        }
    }
}
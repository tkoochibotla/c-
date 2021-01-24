using System;
using System.IO;
using RestSharp;

namespace CoreBetting.Services.RestSharp
{
    internal class RequestBuilder
    {
        private readonly RestMethodInfo _methodInfo;
        private readonly object[] _arguments;

        public RequestBuilder(RestMethodInfo methodInfo, object[] arguments)
        {
            _methodInfo = methodInfo;
            _arguments = arguments;
        }

        public IRestRequest Build()
        {
            var request = new RestRequest(_methodInfo.Path, _methodInfo.Method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = RestSharpNewtonsoftJsonSerializer.Default,
            };
            // TODO: Allow XML requests?
            for (var i = 0; i < _arguments.Length; i++)
            {
                var argument = _arguments[i];
                var usage = _methodInfo.ParameterUsage[i];

                switch (usage)
                {
                    case RestMethodInfo.ParamUsage.Query:
                        if (argument != null)
                        {
                            request.AddParameter(_methodInfo.ParameterNames[i], argument, ParameterType.QueryString);
                        }
                        break;
                    case RestMethodInfo.ParamUsage.Path:
                        request.AddUrlSegment(_methodInfo.ParameterNames[i], argument.ToString());
                        break;
                    case RestMethodInfo.ParamUsage.Header:
                        request.AddHeader(_methodInfo.ParameterNames[i], argument.ToString());
                        break;
                    case RestMethodInfo.ParamUsage.Body:
                        request.AddBody(argument);
                        break;
                    case RestMethodInfo.ParamUsage.Parameter:
                        request.AddParameter(_methodInfo.ParameterNames[i], argument.ToString(), ParameterType.GetOrPost);
                        break;
                    case RestMethodInfo.ParamUsage.File:
                        var path = argument.ToString();
                        var name = _methodInfo.ParameterNames[i] ?? Path.GetFileName(path);
                        request.AddFile(name, path, "multipart/form-data");
                        break;
                    case RestMethodInfo.ParamUsage.Cookie:
                        request.AddCookie(_methodInfo.ParameterNames[i], argument.ToString());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return request;
        }
    }
}
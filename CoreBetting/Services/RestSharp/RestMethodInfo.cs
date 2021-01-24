using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoreBetting.Services.Attributes;
using CoreBetting.Services.Attributes.Methods;
using CoreBetting.Services.Attributes.Parameters;
using RestSharp;

namespace CoreBetting.Services.RestSharp
{
    public class RestMethodInfo
    {
        private readonly MethodInfo _methodInfo;
        protected object RequestMethod { get; set; }
        public Method Method { get; set; }
        public string Path { get; set; }

        public List<ParamUsage> ParameterUsage { get; set; }
        public List<string> ParameterNames { get; set; }

        public enum ParamUsage
        {
            Query, Path, Body, Header, File, Parameter, Cookie
        }

        public RestMethodInfo(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
            Init();
        }

        private void Init()
        {
            ParseMethodAttributes();
            ParseParameters();
        }

        private void ParseMethodAttributes()
        {
            foreach (ValueAttribute attribute in _methodInfo.GetCustomAttributes(true))
            {
                var innerAttributes = attribute.GetType().GetCustomAttributes(true);

                RestMethodAttribute methodAttribute = innerAttributes.FirstOrDefault(theAttribute => theAttribute.GetType() == typeof(RestMethodAttribute)) as RestMethodAttribute;

                if (methodAttribute == null) continue;
                if (RequestMethod != null)
                    throw new ArgumentException($"Method {_methodInfo.Name} contains multiple HTTP methods. Found {RequestMethod} and {methodAttribute.Method}");

                Method = methodAttribute.Method;
                Path = attribute.Value;
            }
        }

        private void ParseParameters()
        {
            ParameterUsage = new List<ParamUsage>();
            ParameterNames = new List<string>();
            foreach (var parameter in _methodInfo.GetParameters())
            {
                var attribute = (ValueAttribute)parameter.GetCustomAttributes(false).FirstOrDefault();
                if (attribute == null)
                    throw new ArgumentException($"No annotation found on parameter {parameter.Name} of {_methodInfo.Name}");

                var type = attribute.GetType();
                if (type == typeof(PathAttribute))
                {
                    ParameterUsage.Add(ParamUsage.Path);
                    ParameterNames.Add(attribute.Value);
                }
                else if (type == typeof(ParameterAttribute))
                {
                    ParameterUsage.Add(ParamUsage.Parameter);
                    ParameterNames.Add(attribute.Value);
                }
                else if (type == typeof(BodyAttribute))
                {
                    ParameterUsage.Add(ParamUsage.Body);
                    ParameterNames.Add(null);
                }
                else if (type == typeof(QueryAttribute))
                {
                    ParameterUsage.Add(ParamUsage.Query);
                    ParameterNames.Add(attribute.Value);
                }
                else if (type == typeof(HeaderAttribute))
                {
                    ParameterUsage.Add(ParamUsage.Header);
                    ParameterNames.Add(attribute.Value);
                }
                else if (type == typeof(FileAttribute))
                {
                    ParameterUsage.Add(ParamUsage.File);
                    ParameterNames.Add(attribute.Value);
                }
                else if (type == typeof(CookieAttribute))
                {
                    ParameterUsage.Add(ParamUsage.Cookie);
                    ParameterNames.Add(attribute.Value);
                }
            }
        }
    }
}
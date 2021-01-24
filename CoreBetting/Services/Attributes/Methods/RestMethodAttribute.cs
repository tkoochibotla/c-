using System;
using RestSharp;

namespace CoreBetting.Services.Attributes.Methods
{
    public class RestMethodAttribute : Attribute
    {
        public Method Method { get; private set; }

        public RestMethodAttribute(Method method)
        {
            Method = method;
        }
    }
}

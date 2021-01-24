﻿using RestSharp;

namespace CoreBetting.Services.Attributes.Methods
{
    [RestMethod(Method.DELETE)]
    public class DeleteAttribute : ValueAttribute
    {
        public DeleteAttribute(string path)
        {
            Value = path;
        }
    }
}

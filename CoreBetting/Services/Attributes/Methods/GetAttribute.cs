using RestSharp;

namespace CoreBetting.Services.Attributes.Methods
{
    [RestMethod(Method.GET)]
    public class GetAttribute : ValueAttribute
    {
        public GetAttribute(string path)
        {
            Value = path;
        }
    }
}

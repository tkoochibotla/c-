using RestSharp;

namespace CoreBetting.Services.Attributes.Methods
{
    [RestMethod(Method.HEAD)]
    public class HeadAttribute : ValueAttribute
    {
        public HeadAttribute(string path)
        {
            Value = path;
        }
    }
}

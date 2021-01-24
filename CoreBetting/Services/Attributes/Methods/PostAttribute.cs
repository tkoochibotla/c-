using RestSharp;

namespace CoreBetting.Services.Attributes.Methods
{
    [RestMethod(Method.POST)]
    public class PostAttribute : ValueAttribute
    {
        public PostAttribute(string path)
        {
            Value = path;
        }
    }
}

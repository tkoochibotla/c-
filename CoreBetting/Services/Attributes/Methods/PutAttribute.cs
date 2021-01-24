using RestSharp;

namespace CoreBetting.Services.Attributes.Methods
{
    [RestMethod(Method.PUT)]
    public class PutAttribute : ValueAttribute
    {
        public PutAttribute(string path)
        {
            Value = path;
        }
    }
}

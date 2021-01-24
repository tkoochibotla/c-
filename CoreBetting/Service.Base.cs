using System.Threading;
using CoreBetting.Interfaces;
using CoreBetting.Services.RestSharp;

namespace CoreBetting
{
    public partial class Service
    {
       public static string apiUrl = "http://historicalbets.test.env.works";

        public static readonly ThreadLocal<IServiceEMC> ServiceECM =
            new ThreadLocal<IServiceEMC>(
                () => new RestAdapter(apiUrl).Create<IServiceEMC>());
    }
}

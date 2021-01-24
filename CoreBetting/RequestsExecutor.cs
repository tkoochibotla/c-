using CoreBetting.Model.Request;
using CoreBetting.Model.Response;

namespace CoreBetting
{
    public partial class Service
    {


        public class search : ServiceBase
        {
            public static SearchResponse SearchBet(SearchRequest request) => ExecuteRequest<SearchResponse>(()
                     => ServiceECM.Value.SearchBet(request)
                );
        }
    }
}
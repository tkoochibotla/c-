using RestSharp;
using CoreBetting.Model.Request;
using CoreBetting.Services.Attributes.Methods;
using CoreBetting.Model.Response;
using CoreBetting.Services.Attributes.Parameters;

namespace CoreBetting.Interfaces
{
	public interface IServiceEMC
    {
		[Post("/3.0/api/historicalbets/search")]
		RestResponse<SearchResponse> SearchBet(
			[Body()] SearchRequest request
			);
	}
}
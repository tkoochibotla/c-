namespace CoreBetting.Model.Request
{
	public class SearchRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "customerId")]
		public string CustomerId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "startIndex")]
		public string StartIndex { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "count")]
		public string Count { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "minDateUtc")]
		public string MinDateUtc { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "maxDateUtc")]
		public string MaxDateUtc { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "betSlipFilter")]
		public string BetSlipFilter { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "scope")]
		public string Scope { get; set; }
	}

}
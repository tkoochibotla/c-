using System.Collections.Generic;

namespace CoreBetting.Model.Response
{
	public class SearchResponse
	{
		public List<BetSlips> betSlips { get; set; }

		public class BetSlips
		{
			public int customerId { get; set; }
        }

    }
}

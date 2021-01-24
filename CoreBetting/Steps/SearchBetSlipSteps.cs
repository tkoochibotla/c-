using TechTalk.SpecFlow;
using CoreBetting.Model.Request;
using CoreBetting;

namespace CoreBetting.Steps
{
    [Binding]
    public class SearchBetSlipSteps
    {
        public SearchRequest search = new SearchRequest();
        public static int customerId;

        [Given(@"user sets the customerId ""(.*)""")]
        public void GivenUserSetsTheCustomerId(string p0)
        {
            search.CustomerId = p0;
        }

        [Given(@"user sets the startIndex ""(.*)""")]
        public void GivenUserSetsTheStartIndex(string p0)
        {
            search.StartIndex = p0;
        }

        [Given(@"user sets the count ""(.*)""")]
        public void GivenUserSetsTheCount(string p0)
        {
            search.Count = p0;
        }

        [Given(@"user sets the minDateUtc ""(.*)""")]
        public void GivenUserSetsTheMinDateUtc(string p0)
        {
            search.MinDateUtc = p0;
        }

        [Given(@"user sets the maxDateUtc ""(.*)""")]
        public void GivenUserSetsTheMaxDateUtc(string p0)
        {
            search.MaxDateUtc = p0;
        }

        [Given(@"user sets the betSlipFilter ""(.*)""")]
        public void GivenUserSetsTheBetSlipFilter(string p0)
        {
            search.BetSlipFilter = p0;
        }

        [Given(@"user sets the scope ""(.*)""")]
        public void GivenUserSetsTheScope(string p0)
        {
            search.Scope = p0;
        }

        [When(@"user search")]
        public void WhenUserSearch()
        {
            customerId =  Service.search.SearchBet(search).betSlips[0].customerId;

        }

        [Then(@"the betSlipNumber is retrieved")]
        public void ThenTheBetSlipNumberIsRetrieved()
        {
            AssertHooks.AssertIsNotNull(customerId, "Bet Slip id retrived: "+ customerId);
        }
    }
}

Feature: SearchBetSlip

@mytag
Scenario: Verify it is possible to search
	Given user sets the customerId "20590316"
	And user sets the startIndex "2"
	And user sets the count "20"
	And user sets the minDateUtc "2020-11-16T07:25:19.019Z"
	And user sets the maxDateUtc "2020-12-16T07:25:19.019Z"
	And user sets the betSlipFilter "open"
	And user sets the scope "NonLive"
	When user search
	Then the betSlipNumber is retrieved
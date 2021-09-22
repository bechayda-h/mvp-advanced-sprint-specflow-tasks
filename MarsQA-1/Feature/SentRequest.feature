Feature: SentRequest
	validate features in SentRequest page

Scenario: Manage Request --> Sent Request: Withdraw
	Given user logs in to website
	And user navigates to SentRequest page
	When user clicks Withdraw of a sent request
	Then a "Request has been withdrawn" message will appear
	And the Status field of the sent request should change to Withdrawn

Scenario: Manage Request --> Sent Request: Completed
	Given user logs in to website
	And user navigates to SentRequest page
	When user clicks Completed of a sent request
	Then a "Request has been updated" message will appear
	And the Status field of the sent request should change to Completed

Scenario: Manage Request --> Sent Request: Review
	Given user logs in to website
	And user navigates to SentRequest page
	And user clicks Review of a sent request
	And user inputs a review "Service review detail"
	And user inputs seller rating "3", service rating "4", and recommend rating "5"
	When user clicks Save in the Rate this Service page modal
	Then a "Rating added, thank you!" message will appear

Scenario: Manage Request --> Sent Request: access title link
	Given user logs in to website
	And user navigates to SentRequest page
	When user clicks the title link of a sent request
	Then the ServiceDetail page of the service entry should be displayed

Scenario: Manage Request --> Sent Request: access recipient link
	Given user logs in to website
	And user navigates to SentRequest page
	When user clicks the recipient link of a sent request
	Then the Profile page of the recipient should be displayed
Feature: ManageRequests
	Validate features in Manage Requests

Scenario: Manage Request --> Received Request
	Given user logs in to website
	When user clicks Received Requests
	Then user will be able to navigate to "ReceivedRequest" page

Scenario: Manage Request --> Sent Request
	Given user logs in to website
	When user clicks Sent Requests
	Then user will be able to navigate to "SentRequest" page


Feature: ReceivedRequest
	validate features in ReceivedRequest page

Scenario: Manage Request --> Received Request: Accept
	Given user logs in to website
	And user navigates to ReceivedRequest page
	When user clicks Accept of a received request
	Then a "Service has been updated" message will appear
	And the received request status will become Accepted

Scenario: Manage Request --> Received Request: Decline
	Given user logs in to website
	And user navigates to ReceivedRequest page
	When user clicks Decline of a received request
	Then a "Service has been updated" message will appear
	And the received request status will become Declined

Scenario: Manage Request --> Received Request: Complete
	Given user logs in to website
	And user navigates to ReceivedRequest page
	When user clicks Complete of a received request
	Then the sender rating should be displayed
	And a "Request has been updated" message will appear

Scenario: Manage Request --> Received Request: access title link
	Given user logs in to website
	And user navigates to ReceivedRequest page
	When user clicks the title link of a received request
	Then the ServiceDetail page of the service entry from ReceivedRequest page should be displayed

Scenario: Manage Request --> Received Request: access sender link
	Given user logs in to website
	And user navigates to ReceivedRequest page
	When user clicks the sender link of a received request
	Then the Profile page of the sender should be displayed
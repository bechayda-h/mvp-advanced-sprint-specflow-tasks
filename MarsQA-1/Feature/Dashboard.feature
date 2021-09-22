Feature: Dashboard
	validate features in Dashboard page

Scenario: Notifications --> Show Less
	Given user logs in to website
	And user clicks Dashboard
	And user clicks Load More... button
	When user clicks ...Show Less button
	Then less notifications will be displayed

Scenario: Notifications --> Load more
	Given user logs in to website
	And user clicks Dashboard
	When user clicks Load More... button
	Then more notifications will be displayed

Scenario: Notifications --> Delete
	Given user logs in to website
	And user clicks Dashboard
	And user clicks a checkbox
	When user clicks Delete selection
	Then a "Notification updated" message will appear
	And the notification will be deleted

Scenario: Notifications --> Mark as Read
	Given user logs in to website
	And user clicks Dashboard
	And user clicks a checkbox
	When user clicks Mark selection as read
	Then a "Notification updated" message will appear

Scenario: Notifications --> Select
	Given user logs in to website
	And user clicks Dashboard
	When user clicks Select All
	Then notification items will be selected

Scenario: Notifications --> Unselect
	Given user logs in to website
	And user clicks Dashboard
	And user clicks Select All
	When user clicks Unselect All
	Then notification items will be unselected
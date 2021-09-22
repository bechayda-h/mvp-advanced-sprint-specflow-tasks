Feature: Manage Listings
	validate features in Manage Listings

Scenario Outline: Manage Listings --> Edit 
	Given user logs in to website
	And user clicks Manage Listings
	And user clicks the write icon of a service entry
	And user updates the service entry details with '<title>', '<description>', '<category>', '<subcategory>', and '<servicetype>'
	When user clicks the Save button in ServiceListing page
	Then the '<category>', '<title>', '<description>', and '<servicetype>' of the service entry will be updated in ListingManagement page
	Examples:
	| title       | description | category        | subcategory                 | servicetype |
	| Ramen Skill | delicious   | Fun & Lifestyle | Health, Nutrition & Fitness | One-off     |

Scenario: Manage Listings --> Delete
	Given user logs in to website
	And user clicks Manage Listings
	And user clicks the remove icon
	When user clicks Yes in the page modal
	Then a service has been deleted message will appear

	
Feature: ServiceListing
	Validate features in ServiceListing page

Scenario Outline: Share Skills --> Add New
	Given user logs in to website
	And user clicks Share Skill button
	And user inputs skill details: '<Title>', '<Description>', '<Category>', '<Subcategory>', '<Tags>', '<Service Type>', '<Skill-Exchange>'
	When user clicks the Save button in ServiceListing page
	Then the skill details '<Category>', '<Title>', '<Description>', '<Service Type>' will be listed on top in the ListingManagement page
	Examples:
	| Title       | Description       | Category | Subcategory | Tags      | Service Type | Skill-Exchange     |
	| Skill Title | Skill Description | Business | Other       | Skill Tag | Hourly       | Skill-Exchange Tag |
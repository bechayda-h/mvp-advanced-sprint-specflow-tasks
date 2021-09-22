Feature: Search
	Validate features in Search page

Scenario: Search Skills --> by Filter Online
	Given user logs in to website
	And user clicks the search icon
	When user clicks the Online filter
	Then the total item count of All Categories will be updated

Scenario: Search Skills --> by Filter Onsite
	Given user logs in to website
	And user clicks the search icon
	When user clicks the Onsite filter
	Then the total item count of All Categories will be updated

Scenario: Search Skills --> by Filter ShowAll
	Given user logs in to website
	And user clicks the search icon
	And user clicks the Onsite filter
	When user clicks the ShowAll filter
	Then the total item count of All Categories will be updated

Scenario Outline: Search Skills --> Category
	Given user logs in to website
	And user clicks the search icon
	When user clicks '<category>' category
	Then '<category>' will become the active category
	Examples:
	| category              |
	| Graphics & Design     |
	| Digital Marketing     |
	| Writing & Translation |
	| Video & Animation     |
	| Music & Audio         |
	| Programming & Tech    |
	| Business              |
	| Fun & Lifestyle       |

Scenario Outline: Search Skills --> Subcategory
	Given user logs in to website
	And user clicks the search icon
	And user clicks '<category>' category
	When user clicks '<subcategory>' subcategory
	Then '<subcategory>' will become the active subcategory
	And '<category>' will become the active category
	Examples:
	| category              | subcategory                 |
	| Graphics & Design     | Logo Design                 |
	| Graphics & Design     | Book & Album covers         |
	| Graphics & Design     | Flyers & Brochures          |
	| Graphics & Design     | Web & Mobile Design         |
	| Graphics & Design     | Search & Display Marketing  |
	| Digital Marketing     | Social Media Marketing      |
	| Digital Marketing     | Content Marketing           |
	| Digital Marketing     | Video Marketing             |
	| Digital Marketing     | Email Marketing             |
	| Digital Marketing     | Search & Display Marketing  |
	| Writing & Translation | Resumes & Cover Letters     |
	| Writing & Translation | Proof Reading & Editing     |
	| Writing & Translation | Translation                 |
	| Writing & Translation | Creative Writing            |
	| Writing & Translation | Business Copywriting        |
	| Video & Animation     | Promotional Videos          |
	| Video & Animation     | Editing & Post Production   |
	| Video & Animation     | Lyric & Music Videos        |
	| Video & Animation     | Other                       |
	| Music & Audio         | Mixing & Mastering          |
	| Music & Audio         | Voice Over                  |
	| Music & Audio         | Song Writers & Composers    |
	| Music & Audio         | Other                       |
	| Programming & Tech    | WordPress                   |
	| Programming & Tech    | Web & Mobile App            |
	| Programming & Tech    | Data Analysis & Reports     |
	| Programming & Tech    | QA                          |
	| Programming & Tech    | Databases                   |
	| Programming & Tech    | Other                       |
	| Business              | Business Tips               |
	| Business              | Presentations               |
	| Business              | Market Advice               |
	| Business              | Legal Consulting            |
	| Business              | Financial Consulting        |
	| Business              | Other                       |
	| Fun & Lifestyle       | Online Lessons              |
	| Fun & Lifestyle       | Relationship Advice         |
	| Fun & Lifestyle       | Astrology                   |
	| Fun & Lifestyle       | Health, Nutrition & Fitness |
	| Fun & Lifestyle       | Gaming                      |
	| Fun & Lifestyle       | Other                       |

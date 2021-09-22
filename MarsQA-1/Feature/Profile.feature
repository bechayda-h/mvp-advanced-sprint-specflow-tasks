Feature: Profile
	Validate features in Profile Page

Scenario Outline: Profile --> Availability
	Given user logs in to website
	And user clicks the write icon of Availability
	When user selects '<availability>' as Availability
	Then the value of Availability will become '<availability>'
	And a "Availability updated" message will appear
	Examples:
	| availability |
	| Part Time    |
	| Full Time    |

Scenario Outline: Profile --> Hours
	Given user logs in to website
	And user clicks the write icon of Hours
	When user selects '<hours>' as Hours
	Then the value of Hours will become '<hours>'
	And a "Availability updated" message will appear
	Examples:
	| hours                    |
	| Less than 30hours a week |
	| More than 30hours a week |
	| As needed                |

Scenario Outline: Profile --> Earn Target
	Given user logs in to website
	And user clicks the write icon of Earn Target
	When user selects '<earn target>' as Earn Target
	Then the value of Earn Target will become '<earn target>'
	And a "Availability updated" message will appear
	Examples:
	| earn target                      |
	| Less than $500 per month         |
	| Between $500 and $1000 per month |
	| More than $1000 per month        |

Scenario Outline: Profile --> Add a Language entry
	Given user logs in to website
	And user clicks the Add New entry in Languages tab
	And user inputs '<language>' and '<language level>' in Languages tab
	When user clicks Add in Langauages tab
	Then a language entry '<language>' and '<language level>' will be added
	And a "<language> has been added to your languages" message will appear
	Examples:
	| language | language level |
	| English  | Basic          |

Scenario Outline: Profile --> Edit a Language entry
	Given user logs in to website
	And user clicks the write icon of a language entry
	And user updates the language entry with '<language>' and '<language level>'
	When user clicks Update of the language entry
	Then the language entry will be updated with '<language>' and '<language level>'
	And a "<language> has been updated to your languages" message will appear
	Examples:
	| language | language level |
	| Spanish  | Conversational |

Scenario: Profile --> Delete a Language entry
	Given user logs in to website
	When user clicks the remove icon of a language entry
	Then the language entry will be deleted
	And a language has been deleted message will appear

Scenario Outline: Profile --> Add a Skill entry
	Given user logs in to website
	And user clicks the "Skills" tab
	And user clicks the Add New entry in Skills tab
	And user inputs '<skill>' and '<skill level>' in Skills tab
	When user clicks Add in Skills tab
	Then a skill entry '<skill>' and '<skill level>' will be added
	And a "<skill> has been added to your skills" message will appear
	Examples:
	| skill   | skill level |
	| Cooking | Beginner    |

Scenario Outline: Profile --> Edit a Skill entry
	Given user logs in to website
	And user clicks the "Skills" tab
	And user clicks the write icon of a skill entry
	And user updates the skill entry with '<skill>' and '<skill level>'
	When user clicks Update of the skill entry
	Then the skill entry will be updated with '<skill>' and '<skill level>'
	And a "<skill> has been updated to your skills" message will appear
	Examples:
	| skill  | skill level |
	| Eating | Expert      |

Scenario: Profile --> Delete a Skill entry
	Given user logs in to website
	And user clicks the "Skills" tab
	When user clicks the remove icon of a skill entry
	Then the skill entry will be deleted
	And a skill has been deleted message will appear

Scenario Outline: Profile --> Add an Education entry
	Given user logs in to website
	And user clicks the "Education" tab
	And user clicks the Add New entry in Education tab
	And user inputs '<university>', '<country>', '<title>', '<degree>', and '<graduation year>' in Education tab
	When user clicks Add in Education tab
	Then an education entry '<country>', '<university>', '<title>', '<degree>', '<graduation year>' will be added
	And a "Education has been added" message will appear
	Examples:
	| country     | university    | title | degree   | graduation year |
	| New Zealand | My University | PHD   | Computer | 2020            |

Scenario Outline: Profile --> Edit an Education entry
	Given user logs in to website
	And user clicks the "Education" tab
	And user clicks the write icon of an education entry
	And user updates the education entry with '<university>', '<country>', '<title>', '<degree>', and '<graduation year>'
	When user clicks Update of the education entry
	Then the education entry will be updated with '<country>', '<university>', '<title>', '<degree>', and '<graduation year>'
	And a "Education as been updated" message will appear
	Examples:
	| country   | university | title | degree  | graduation year |
	| Australia | My College | MFA   | Science | 2019            |

Scenario: Profile --> Delete an Education entry
	Given user logs in to website
	And user clicks the "Education" tab
	When user clicks the remove icon of an education entry
	Then a "Education entry successfully removed" message will appear
	And the education entry will be deleted

Scenario Outline: Profile --> Add a Certification entry
	Given user logs in to website
	And user clicks the "Certifications" tab
	And user clicks the Add New entry in Certifications tab
	And user inputs '<certificate>', '<from>', and '<year>' in Certifications tab
	When user clicks Add in Certifications tab
	Then a certification entry '<certificate>', '<from>', '<year>' will be added
	And a "<certificate> has been added to your certification" message will appear
	Examples:
	| certificate    | from              | year |
	| My Certificate | Certificate Giver | 2018 |

Scenario Outline: Profile --> Edit a Certification entry
	Given user logs in to website
	And user clicks the "Certifications" tab
	And user clicks the write icon of a certification entry
	And user updates the certification entry with '<certificate>', '<from>', and '<year>'
	When user clicks the Update of the certification entry
	Then the certification entry will be updated with '<certificate>', '<from>', and '<year>'
	And a "<certificate> has been updated to your certification" message will appear
	Examples:
	| certificate   | from          | year |
	| Another Award | Another Giver | 2019 |

Scenario: Profile --> Delete a Certification entry
	Given user logs in to website
	And user clicks the "Certifications" tab
	When user clicks the remove icon of a certification entry
	Then the certification entry will be deleted
	And a certification entry has been deleted message will appear
	
Scenario Outline: Profile --> Description
	Given user logs in to website
	And user clicks the write icon of the Description
	And user edits the description with '<description>'
	When user clicks Save of the Description
	Then the description will be updated to '<description>'
	And a "Description has been saved successfully" message will appear
	Examples:
	| description            |
	| My profile description |

Scenario: Profile --> Change Password
	Given user logs in to website
	And user navigates to Change Password
	And user inputs old password "password" and new password "password1"
	When user clicks Save
	Then a "Password Changed Successfully" message will appear

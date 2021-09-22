Feature: Login
	Validate features in Home page

Scenario: Sign In
	Given user clicks Sign In
	When user logs in with "bechayda_h@yahoo.com" and "password"
	Then the user Profile Page "Aldwin Bechayda" will be accessed

Scenario: Registration
	Given user clicks Join
	And user inputs "firstname1", "lastname1", "email12@somedomain.com", "password", and "password"
	And user agrees with the terms and condition
	When user clicks the Join button
	Then a "Registration successful" message will appear
	


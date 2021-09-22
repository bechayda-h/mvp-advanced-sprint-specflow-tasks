Feature: Message
	validate features in Message page

Scenario Outline: Chat
	Given user logs in to website
	And user clicks Chat
	And user enters a message '<message>'
	When user clicks Send in the Message page
	Then the message '<message>' will be added in the chat content
	Examples:
	| message     |
	| Hello World |

Scenario: Chat --> History
	Given user logs in to website
	And user clicks Chat
	When user clicks the second chatroom from the top
	Then the chat content of that chat room will be displayed
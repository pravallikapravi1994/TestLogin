Feature: Login
	Validate Login Functionality




@postivescenario
Scenario Outline: Login with valid username and Password
	Given User is in Login page
	And Enters valid <Username> Username and <Password> Password
	When Clicked on Login button
	Then User '<Username>'should be logged in Successfully 
	
	Examples:
	| Username   | Password |
	| Test       | 12345    |
	| Pravallika | 12345    |



@negativescenario
Scenario Outline: Login should not be allowed to login using invalid credentials
	Given User is in Login page
	And Enters invalid Username and  Password
	When Clicked on Login button
	Then Login to be failed and Error message to be displayed





Feature: Logout
	Validate Logout functionality

@mytag
Scenario: User able to logout successfully 
	Given User is SignedIn
	When Clicked on Logout button
	Then Logout should be successfull
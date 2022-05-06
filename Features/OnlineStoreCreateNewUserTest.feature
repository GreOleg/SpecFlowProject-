Feature: OnlineStoreCreateNewUserTest

Scenario: Create a new User
	Given I open "My Store"
	When I press "login" button
	Then The "Login" page should be on the screen
	When I submit "user email" in the create an account form
	Then The "Login - My Store" page should be on the screen
	When I submit regestration user form with "user data"
	Then The "My account" page should be on the screen

Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

@login
Scenario: Invalid email
	Given I am on the signin page
	And I have not entered any credentials
	When I click the sign in button
	Then I should see an alert containing the error message "Epic sadface: Username is required"

@login
Scenario: No password entered
	Given I am on the signin page
	And I enter "testingEmail@email.com"
	And I don't enter a password
	When I click the sign in button
	Then I should see an alert containing the error message "Epic sadface: Password is required"

@login
Scenario: Valid email, invalid password
	Given I am on the signin page
	And I enter "testingEmail@email.com"
	And I enter an invalid password "password"
	When I click the sign in button
	Then I should see an alert containing the error message "Epic sadface: Username and password do not match any user in this service"

@login
Scenario: Valid credentials
	Given I am on the signin page
	And I enter "standard_user"
	And I enter an invalid password "secret_sauce"
	When I click the sign in button
	Then the resulting page navigated to should have title "Swag Labs"

@login
Scenario: Invalid email - using Specflow Assist
Given I am on the signin page
And I have the following credentials
| Email    | Password |
| test.com | nish     |

When I enter these credentials
And I click the sign in button
Then I should see an alert containing the error message "Epic sadface: Username and password do not match any user in this service"
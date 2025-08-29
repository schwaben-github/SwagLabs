Feature: Login
  As a SwagLabs user
    I want to login and logout, and see proper error messages

  Scenario: Login page test
    Given I am on the login page
    Then the login page elements should be visible

  Scenario: Login as standard_user and logout
    Given I am on the login page
    When I login as 'standard_user' with password 'secret_sauce'
    Then I should see the products page
    When I logout
    Then I should see the login page

  Scenario: Login Attempt as locked_out_user
    Given I am on the login page
    When I login as 'locked_out_user' with password 'secret_sauce'
    Then I should see an error message containing 'locked out'

  Scenario: Login Attempt with empty fields
    Given I am on the login page
    When I login as '' with password ''
    Then I should see an error message containing 'Username is required'

  Scenario: Login Attempt only username filled
    Given I am on the login page
    When I login as 'standard_user' with password ''
    Then I should see an error message containing 'Password is required'

  Scenario: Login Attempt only password filled
    Given I am on the login page
    When I login as '' with password 'secret_sauce'
    Then I should see an error message containing 'Username is required'

  Scenario: Login Attempt wrong username
    Given I am on the login page
    When I login as 'wrong_user' with password 'secret_sauce'
    Then I should see an error message containing 'Username and password do not match'

  Scenario: Login Attempt wrong password
    Given I am on the login page
    When I login as 'standard_user' with password 'wrong_password'
    Then I should see an error message containing 'Username and password do not match'

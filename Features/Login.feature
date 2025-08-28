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

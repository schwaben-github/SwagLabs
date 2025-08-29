Feature: Products
  As a logged in user
  I want to see the products page and its items

Scenario: Products page elements test
    Given I am logged in as 'standard_user' with password 'secret_sauce'
    When I am on the products page
    Then the products page should be loaded
    And there should be at least '1' product listed
    And the banner should contain text 'Swag Labs'
    And the banner should contain text 'Products'
    And the hamburger menu should be visible
    And the shopping cart should be visible
    And the sorting dropdown should be visible

Scenario: Add and remove product from shopping cart
    Given I am logged in as 'standard_user' with password 'secret_sauce'
    When I am on the products page
    And I add the first product to the shopping cart
    Then the shopping cart icon should display a red dot with '1'
    When I remove the first product from the shopping cart
    Then the shopping cart icon should not display a red dot
    When I log out
    Then I should be redirected to the login page
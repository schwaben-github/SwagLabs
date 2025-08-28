Feature: Products
  As a logged in user
  I want to see the products page and its items

  Scenario: Products page test
    Given I am logged in as 'standard_user' with password 'secret_sauce'
    When I am on the products page
    Then the products page should be loaded
    And there should be at least '1' product listed
    And the banner should contain text 'Swag Labs'
    And the banner should contain text 'Products'
    And the hamburger menu should be visible
    And the shopping cart should be visible
    And the sorting dropdown should be visible
Feature: AddOrder


Scenario:01. Validate items are added to checkout
Given I order a starter and a mains
Then the total price should be 11.40

Scenario:02. Validate no items are added to checkout
Given I do not order any item
Then the total price should be 0.00

Scenario:03. Validate multiple items are added to checkout
Given i order two starters, two mains
Then the total price should be 22.80

Scenario:04. Validate duplicate items are added to checkout
Given i order two same starters and one main
Then the total price should be 15.80
Feature: UpdateItem

Scenario: 01. Validate a single maincourse item is updated to an existing order
Given I update a single maincourse item from an existing order
Then the total price should be 18.40


Scenario: 02. Validate a single starter item is updated to an existing order
Given I update a single starter item from an existing order
Then the total price should be 15.80

Scenario: 03.Validate multiple items are updated to an existing order
Given I update multiple items from an existing order
Then the total price should be 34.20


Scenario:04. Validate an exception is thrown when items are updated from nonexisting order
Given I update items from an non-existing order
Then Order Not found exception is thrown


Scenario:05. Validate No items updated from the existing order
Given I do not update any items from an existing order
Then the total price should be 11.40
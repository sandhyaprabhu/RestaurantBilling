Feature: RemoveItem

Scenario:01. Validate a single item is removed from the order
Given I remove a single item from an existing order
Then the total price should be 4.40


Scenario:02. Validate multiple item are removed from the order
Given I remove multiple items from an existing order
Then the total price should be 11.40

Scenario:03. Validate an non existing item is removed from the order
Given I remove non existing item from an existing order
Then Item not found exception is thrown
Then the total price should be 11.40

Scenario:04. Validate No items removed from the existing order
Given I do not remove any items from an existing order
Then the total price should be 11.40

Scenario:05. Validate an exception is thrown when items are removed from nonexisting order
Given I remove items from an non-existing order
Then Order not found exception is thrown

Scenario:06. Validate an duplicate item is removed from an existing order
Given I remove a duplicate item from an existing order
Then the total price should be 11.40
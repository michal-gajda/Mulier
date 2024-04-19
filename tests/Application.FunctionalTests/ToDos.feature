Feature: CreateToDo
    In order to manage my tasks
    As a user
    I want to be able to create a new ToDo item

Scenario: Successfully create a ToDo item
    Given I have a valid ToDo creation command
    When I send the command to create a ToDo item
    Then the ToDo item should be created in the repository


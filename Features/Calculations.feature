Feature: Calculations

Scenario Outline: Calculations two numbers
	Given I open the Calculator
	Given I have entered first value is <firstValue> into the calculator
	And I press <action> 
	And I have entered second value is <secondValue> into the calculator
	When I press the equals button
	Then the <result> should be on the screen

Examples: 
| firstValue | secondValue  | action   | result   |
| 1          | 3            | Plus     | 4        |
| 2          | 2            | Minus    | 0        |
| 3          | 1            | Mult     | 3        |

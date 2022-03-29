Feature: play 9 innings

Scenario: first inning
	Given this is the 1st inning
	When inning is completed
	Then open 2nd inning

Scenario: second inning
	Given this is the second inning
	When inning is completed
	Then open 3rd inning
	
Scenario Outline
	
Scenario: last inning
	Given this is the last (9th) inning
	When inning is completed
	Then match is completed
Feature: Player can Win


Scenario: Player wins
	Given game is in last inning
	And player has more runs than opponent
	When las inning complete
	Then player wins

Scenario: Player lose
	Given game is in last inning
	and player has less runs than opponent
	When las inning complete
	Then player lose

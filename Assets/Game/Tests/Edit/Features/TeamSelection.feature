Feature: Team selection


Scenario: Team Selection - 1 player
	Given no team is selected by player
	When player select a team
	Then the team is selected

Scenario Outline: Team Selection - 2 player
	Given player 1 has a team <team> selected
	When player2 select a <team>
	Then the <team> is selected by player 2
	
	Examples: 
	<team> 
	Aguilas
	Licey


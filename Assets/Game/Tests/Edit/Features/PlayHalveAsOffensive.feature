Feature: Play Halve as Offensive

cuando el halve recibe un out, el halve se completa y cambia de halve

Scenario pasa de ofensivo a defensiva
	Given Player is offensive
	And AI is deffensive
	When offensive have 3 outs
	Then change to the next halve
	And swap teams to AI - Player

Scenario pasa de defensiva a ofensiva
	Given AI is offensive
	And Player is deffensive
	When offensive have 3 outs
	Then change to the next halve
	And swap teams to Player - AI

Feature: Pitching results in strikeout


Scenario: strikeout
	Given pitcher pitches
	And bat has 2 strikes
	When there is another strike
	Then pitching result is a strikeout

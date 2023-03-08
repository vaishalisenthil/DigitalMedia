Feature: Music Artist

Music Artist song playing now or played recently

@MusicArtist
Scenario Outline: Artist music album is playing now or in recently played
	Given I access CapitalFm <URL>
	When I accept consent cookies
	Then Check "<Artist>" is playing now or avaialble in recent play
		
Examples:
	| Artist        |
	| Justin Bieber |
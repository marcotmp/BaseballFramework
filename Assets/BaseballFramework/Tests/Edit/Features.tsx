Play Baseball Game {
	Setup Match {
		Player Select
		Team Select
		Pitcher Select
		Initial Board Display
	}
	Play a match {
		Jugar 9 innings {
			Jugar 1 inning {
				Jugar primer half {
					TeamVisitor como ofensivo
					TeamHome como ofensivo 
					Inicio del primer half
					Half termina cuando TeamVisitor queda fuera
				}
				Jugar segundo half {
					TeamVisitor como defensivo
					TeamHome como ofensivo 
					Inicio del segundo half
					Half termina cuando TeamHome queda fuera
				}
				Jugar un half {
					Jugar como Ofensivo {
						As human {
							Batter can bat the ball (move and swing){
								Batter can move
								Batter can swing 
							}
							Batter can steal base
							Runner can run to bases (home to 1st base, 1-2, 2-3, 3-home)
							Runner can score when reach home
							Runner can slide to try a safe base (cuando la bola se dirije a la misma base)
						}
						As AI {
						
						}
					}
					Jugar como Defensivo {
						Human
						AI 
					}
					Jugar en los estados {
						Pitching and Batting {
							Pitching Result {
								Pitching can result in a Strike
								Pitching can result in a Ball
								Pitching can result in a Strikeout
								Pitching can result in a Bat Hitting the ball {
									go to running and fielding
								}
							}
						}
						Running and Fielding {
							Hit can result in a fly/hit? (touch ground before catch)
							Hit can result in a homerun
							Hit can result in an out
							Hit can result in a foul
							Runner can be safe
							Runner can score a run when reach home
							Runner can steal base
							Runner can run to bases (home to 1st base, 1-2, 2-3, 3-home)
							Runner can slide to try a safe base (cuando la bola se dirije a la misma base)
						}
					}
					Half termina cuando Team Ofensivo queda fuera {
						3 out is a change
					}
					One out changes the batter
					New batter can play after score or batter out
					3 strikes becomes an strike-out
					3 outs changes half 
					change half show score board for a few seconds
				}	
			}
		}
		Jugador puede ganar {
			El equipo que más carreras tenga al final, gana}
		Jugador puede perder {
			El equipo que menos carreras tenga, pierde}
		Jugar Extra Innings {
			Si ambos equipos estan empates, se agrega un inning adicional }
	}
}

Play Homerun Derby {
	Setup Match {
		Player Select
		Oponent Select
	}
	Play 3 rounds {
		Play a round {
			play two states {
				Pitching & Batting {
					Pitching result in a strike 
					Pitching result in a hit
				}
				Ball moving after hit {
					Hit result into a homerun
					Hit result into a foul
					Hit result into a HIT
				}
				Each strike loses 1 oportunity
				When no oportunity balls left, end game
				Win when homerun greater than goal
				Lose when homeruns less than goal
			}			
		}
	
	
		Pitcher 1 tiene estrategia A
		Pitcher 2 tiene estrategia B
		Pitcher 3 tiene estrategia C
		
		Target, Homeruns, Ball lefts
		
	}
	
}



Gameplay {
	Batter view display info (init gameplay)
	
	Pitching Result {
		Pitching can result in a Strike
		Pitching can result in a Ball
		Pitching can result in a Strikeout
		Pitching can result in a Hit {
			Hit can result in a fly/hit? (touch ground before catch)
			Hit can result in a homerun
			Hit can result in an out
		}
	}
		
	Human {
		Ofensive {
			Batter can bat the ball (move and swing){
				Batter can move
				Batter can swing 
			}
			Batter can steal base
			Runner can run to bases (home to 1st base, 1-2, 2-3, 3-home)
			Runner can score when reach home
			Runner can slide to try a safe base (cuando la bola se dirije a la misma base)
		}
		Defensive {
			
		}
	}
	
	AI {
		Ofensive {
			AI Batter can bat the ball (move and swing){
				Batter can move
				Batter can swing 
			}
			Batter can steal base
		}
		Defensive {
			AI Pitcher can move left and right
			AI Pitcher can pitch the ball
			AI Fielders can catch the ball (out)
			AI Fielders can run and grab the ball on the floor
			AI 1,2,3 base can do out
		}
	}
	
	Play a Half {	
		New batter can play after score or batter out
		3 strikes becomes an strike-out
		3 outs changes half 
		One out changes the batter
		change half show score board for a few seconds
	}
	
	Ball can rebound when touches wall
	fielder can stand on a base when it's empty

	Defensiva {
		teamA use player controllers
		teamB use AI controllers
	}
	
	Ofensive {
		ofensive use player team and controller
		defensive uses AI team and controller
	}
}
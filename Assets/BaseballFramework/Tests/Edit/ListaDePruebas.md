# Features
Player Select
Team Select
Pitcher Select
Initial Board Display

# Play a match
# -Jugar 9 innings
# --Jugar 1 inning
# ---Jugar un halve como ofensivo
# ---Jugar un halve como defensivo

# Jugador puede ganar
El equipo que más carreras tenga al final, gana
# Jugador puede perder
El equipo que menos carreras tenga, pierde
# Extra Innings
Si ambos equipos estan empates, se agrega un inning adicional

## Gameplay
Batter view display info (init gameplay)
Player can bat the ball (move and swing)
	Batter can move
	Batter can swing
Pitching can result in a Strike
Pitching can result in a Ball
Pitching can result in a Strikeout
Pitching can result in a Hit
Batter can steal base
AI Pitcher can pitch the ball
Runner can run to bases (home to 1st base, 1-2, 2-3, 3-home)
Runner can score when reach home
Batter can slide to try a safe base (cuando la bola se dirije a la misma base)
AI Fielders can catch the ball (out)
AI Fielders can run and grab the ball on the floor
AI 1,2,3 base can do out
Batter Hit can result in a fly/hit? (touch ground before catch)
Batter Hit can result in a homerun
Batter Hit can result in an out
New batter can play after score or batter out
Ball can rebound when touches wall
3 strikes becomes an strike-out
3 outs changes halve 
change halve show score board for a few seconds
AI Pitcher can move left and right
One out changes the batter
fielder can stand on a base when it's empty

# Defensiva
defensive use player team and controller
ofensive uses AI team and controller

# Ofensive
ofensive use player team and controller
defensive uses AI team and controller















# Menu
When game starts it shows the menu
When click on 1p it shows the Select your team menu
When move the team selector moves
When click the team is selected
When both teams are selected, show the pitcher selection screen
When pitcher are selected, show the intro screen with the initial board
When timer ends, show gameplay scene with pitching view

# Gameplay
## pitching view
When gameplay start, show pitching view
When pitcher pitch, dispatch ball
when ball and bat touches, change to fly view

## Batter
When press movement btn, the batter moves
When batter reach limit, it stop moving

# Pitcher
## Pitcher AI
When pitcher pick lanzamiento, throws ball
## Pitcher player
When player press moveStick and pitchBtn, pitcher throws balls

# Fly View and states
When fly view init, 
	ball move
	batter move
	fielders move

## Runner
When runner reach base1, it's safe
When runner and ball touches outside of base, it's out for player
When runner moves, it shows it on the UI hud
When runner is close to base and ball is moving to that base, runner se lanza por el piso

## Ball
When ball is in fly mode, move and drop
When ball is moving, camera follows ball
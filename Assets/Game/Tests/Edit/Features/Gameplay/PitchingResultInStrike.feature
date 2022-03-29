Feature: Pitching can result in a Strike

pitcher steps
- pick lanzamient con <movimiento>
- inicia Anim lanzamiento
- lanza la pelota hacia el home con el <movimiento> picked
- pelota llega a home
- ampayer canta strike


Scenario: Strike
	Given pitcher is ready to pitch
	When game is in pitching state
	Then pitcher pick lanzamiento
	When thingking for x seconds
	Then inicia anim lanzamiento
	When pitcher frame de lanzamiento
	Then pelota inicia movimiento hacia home
	When pelota toca al home
	Then ampayer canta strike

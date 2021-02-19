/* 
	Bubble, Bubble, Toil, and Trouble

	Marjorie Ann Cuerdo
*/

Game description:

Bubble, Bubble, Toil, and Trouble is an alternative controller game about the current ongoing COVID-19 pandemic. The player needs to balance their personal human needs (physical health, mental health, finances) with their personal virus exposure levels and the local city's overall virus levels. If any of these reach failure status, then the player loses the game. They must try to stay alive during the time period from March 2020 (beginning of "quarantine") until February 2021 (when vaccinations are more available). The player will soon see that balancing meeting all of these needs are difficult.

Playing the game:

When your Arduino and breadboard are properly set up, the game can run in Unity. To expand the player's personal exposure bubble (yellow), the player must TURN the POTENTIOMETER LEFT to decrease the bubble size and RIGHT to increase the bubble size. 

However, simply increasing the bubble isn't enough! The player needs to consciously TAP the PIEZO BUZZER to "make contact" with the bubbles that are inside of the player's personal exposure bubble. 

As time goes on, the number of bubbles that spawn increase and it's harder to avoid making some decisions without accidentally setting off others (stressed by the instability of analog sensors). 
Tapping to collect the RED bubbles indicate riskier behaviors, increasing your personal and city virus levels. 
Tapping to collect the GREEN bubble indicate safer behaviors, decreasing virus levels while fulfilling your needs. 
However, the bubbles are randomized so try to strategize what's worth the risk in the moment!

If physical health, mental health, or finances go to 0, the game is over.
If the virus levels reach 100%, the game is over.

Good luck and stay safe!
# Verslag – ML-Agents I

## Oefening 1 - CubeAgent
In deze oefening werd een CubeAgent getraind met Unity ML-Agents om naar een target te bewegen zonder van het platform te vallen. 
De agent kreeg observaties van zowel zijn eigen positie als die van het doel, en leerde via beloningen: een positieve beloning bij het bereiken van de target 
en het beëindigen van de episode (en straf) bij vallen. Door herhaald trainen ontwikkelde de agent gedrag waarmee hij efficiënt naar het doel beweegt.

<img width="892" height="391" alt="image" src="https://github.com/user-attachments/assets/662a502e-1e6d-4b2d-bd35-639f63fc30d5" />

Uit de grafieken blijkt dat de agent gaandeweg zijn gedrag stabiliseert naarmate hij meer training krijgt en daardoor minder fouten maakt. 
Bovendien wordt de episode-lengte korter, wat erop wijst dat de agent steeds efficiënter het doel bereikt.

## Oefening 2 - CubeAgent met raycast
In de tweede oefening maken we gebruik van dezelfde scene en basislogica als in oefening 1, maar met één belangrijke aanpassing. De agent krijgt nu één 
observatie minder: de positie van het doel wordt niet langer rechtstreeks doorgegeven. In plaats daarvan maakt de agent gebruik van raycasts om de omgeving 
en het doel waar te nemen. Dankzij deze raycasts kan de agent als het ware 'zien' waar de target zich bevindt. 
Dit maakt de taak moeilijker, maar ook realistischer, omdat de agent niet langer perfecte informatie krijgt en zelf moet leren interpreteren wat hij 'ziet' 
om de target efficiënt te bereiken.

<img width="891" height="387" alt="image" src="https://github.com/user-attachments/assets/a6443c81-a948-4b72-a50d-0779d3789372" />

Ook hier zien we een geleidelijke evolutie: de agent stabiliseert zijn gedrag naarmate hij meer training krijgt en minder fouten maakt. De episode-lengte
wordt opnieuw korter, wat aantoont dat de agent zich steeds efficiënter naar het doel verplaatst.

## Oefening 3 - CubeAgent met groene zone
In de laatste oefening maken we opnieuw gebruik van de logica van oefening 1, waarbij de agent zich verplaatst op basis van de locatie van het doel. 
Deze keer komt er echter een extra uitdaging bij: nadat de agent het doel heeft bereikt, moet hij ook nog een groene zone bereiken. 
Pas wanneer deze zone bereikt is, eindigt de episode. 

<img width="941" height="380" alt="image" src="https://github.com/user-attachments/assets/56e639ae-da9d-4583-8bcc-a2197f535811" />

Uit de resultaten blijkt opnieuw een geleidelijke evolutie: het gedrag van de agent stabiliseert naarmate de training vordert, hij maakt minder fouten en 
de episode-lengte wordt korter. Dit wijst erop dat de agent niet alleen efficiënter het doel bereikt, maar ook de extra stap naar de groene zone steeds 
beter uitvoert.

## Conclusie
Doorheen de drie oefeningen is duidelijk te zien hoe de agent dankzij reinforcement learning stap voor stap beter leert navigeren. 
Of hij nu rechtstreeks de target krijgt, de omgeving moet “zien” via raycasts, of zelfs een extra uitdaging heeft met de groene zone: telkens 
stabiliseert zijn gedrag na verloop van training en wordt de episode-lengte korter. Dit toont aan dat de agent steeds efficiënter en consistenter 
leert omgaan met de taken die hem worden opgelegd.

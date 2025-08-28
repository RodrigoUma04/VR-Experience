# Verslag Towards AI – Labo’s 1 t/m 4
## Labo 1 - Waypoints
In het eerste labo maken we gebruik van waypoints om tanks rond te laten rijden. Elke tank beschikt over een FollowWaypoints-script, waarin een lijst van 
GameObjects (de waypoints) is gekoppeld. Het script doorloopt deze lijst en laat de tank draaien en rijden naar het volgende waypoint. 
Zodra de tank dicht genoeg bij een waypoint is, schakelt het script door naar het volgende waypoint in de lijst, waardoor een continue beweging ontstaat.

## Labo 2 - A*
In het tweede labo implementeren we het A*-algoritme om padplanning te realiseren. De vloer wordt opgedeeld in een grid van vakken, waarna een speler en 
een doelpunt worden geplaatst. Het algoritme berekent het kortste pad van de speler naar het doel, rekening houdend met obstakels.

Na het berekenen van het pad wordt dit pad gereconstrueerd en beweegt de speler erlangs naar het doel. Het hele proces wordt visueel weergegeven en 
handmatig gecontroleerd. Het script maakt ook gebruik van coroutines, zodat stappen per seconde (of minder) uitgevoerd kunnen worden, 
wat het proces overzichtelijker en beter controleerbaar maakt.

## Labo 3 - Waypoints & A*
In het derde labo combineren we de concepten van Labo 1 en 2. De tank maakt nu gebruik van het A*-algoritme om zich tussen verschillende waypoints te verplaatsen.

Het script gebruikt nog steeds een lijst van waypoints, maar bevat daarnaast een lijst van links tussen waypoints, die de mogelijke paden tussen 
twee punten aangeven. Deze links kunnen unidirectioneel (UNI) of bidirectioneel (BI) zijn. In deze oefening wordt gebruikgemaakt van bidirectionele links, 
omdat dit kortere paden oplevert.

Via een UI-dropdown kan de gebruiker selecteren naar welk waypoint de tank moet bewegen. Het A*-algoritme berekent vervolgens het kortste pad, 
waarna de tank automatisch naar het geselecteerde waypoint rijdt.

## Labo 4 - NavMesh
In het laatste labo gebruiken we een NavMesh en een NavMesh Agent om de beweging van een object te controleren. Door een NavMesh te genereren op de vloer, 
wordt aangegeven waar een agent zich kan verplaatsen.

De tank maakt gebruik van een TankAI-script, waarmee hij automatisch de speler volgt. Het script bepaalt zelfstandig het pad langs de NavMesh. 
De speler kan zich verplaatsen met behulp van een PlayerController-script, waarmee handmatige controle over de beweging mogelijk is.

## Conclusie
Doorheen de vier labo’s heb ik stap voor stap geleerd hoe objecten in Unity kunnen navigeren, van eenvoudige waypoint-volging tot het gebruik van 
geavanceerde padplanning met A* en NavMesh Agents. Elk labo bouwt voort op het vorige, waardoor een duidelijke evolutie van eenvoudige naar complexe 
AI-beweging zichtbaar wordt.

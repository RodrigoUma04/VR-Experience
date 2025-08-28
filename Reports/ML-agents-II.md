# Verslag – ML-Agents II
## Intro
In dit labo bouw ik verder op oefening 3 van ML-Agents I om onderzoek te voeren. Hierbij selecteer ik één hyperparameter en één agent-parameter om hun 
invloed op het leergedrag te vergelijken en er een verklaring voor te vinden.

## Agent parameter - Speed Multiplier 
De snelheid van de agent werd in vijf varianten getest:
* Speed 1: 1.4
* Speed 2: 4.2
* Speed 3: 0.1
* Speed 4: 2.7
* Speed 5: 0.7

<img width="1308" height="635" alt="image" src="https://github.com/user-attachments/assets/c6e29f4d-a6c6-460f-bf53-1706746dbd82" />

Uit de resultaten blijkt een duidelijk verschil in leergedrag afhankelijk van de gekozen snelheid. Wanneer de agent te snel beweegt, wordt het gedrag 
vaak chaotisch en kan het leerproces zelfs volledig instorten. Wanneer de agent te traag beweegt, wordt het leerproces aanzienlijk vertraagd, waardoor
het langer duurt om stabiel gedrag te ontwikkelen.

Dit toont aan dat een goede balans in de speed multiplier cruciaal is: enkel dan kan de agent snel én efficiënt trainen, met een stabiele en consistente 
leercurve als resultaat.

## Hyperparameter - num_layers
Het aantal lagen werd in drie varianten getest:
* Layers 1: 1
* Layers 2: 2
* Layers 3: 3

<img width="1308" height="661" alt="image" src="https://github.com/user-attachments/assets/864f4e6d-ded5-4cfe-9040-078f8601c915" />

Uit de resultaten blijkt dat het aantal lagen een merkbaar effect heeft op het leergedrag. Met één laag leert de agent sneller, maar de beloningscurve 
vertoont meer schommelingen. Bij twee lagen verloopt de evolutie trager, maar de toename is duidelijk stabieler en de curve verloopt veel vloeiender. Bij te veel 
lagen zien we dat het leerproces chaotischer kan worden en langer duurt om te stabiliseren. Dit wijst erop dat een complexer netwerk niet noodzakelijk sneller 
leert, maar wel kan zorgen voor consistenter en robuuster gedrag.

Het vinden van het juiste evenwicht is dus opnieuw cruciaal: met weinig lagen kan de agent wel sneller vooruitgang boeken, maar minder stabiel. 
Met een extra laag verloopt het proces stabieler en betrouwbaarder, terwijl té veel lagen het leerproces juist chaotisch en minder efficiënt kunnen maken.

## Conclusie
Uit deze experimenten blijkt duidelijk dat zowel agent-parameters als hyperparameters een grote invloed hebben op het leergedrag van ML-Agents. 
De speed multiplier toont aan dat te hoge of te lage snelheden respectievelijk chaotisch gedrag of vertraagde leerprocessen kunnen veroorzaken, 
terwijl het aantal lagen van het netwerk bepaalt hoe stabiel en robuust het leerproces verloopt.

Dit benadrukt dat het begrijpen van de werking en impact van verschillende parameters cruciaal is om een goed presterende agent te ontwikkelen. 
Het vinden van een juiste balans tussen snelheid, netwerkcomplexiteit en andere instellingen bepaalt niet alleen hoe snel een agent leert, maar ook hoe 
betrouwbaar en consistent het gedrag is.

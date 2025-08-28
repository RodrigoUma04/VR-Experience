# Verslag – ML-Agents III
In dit project is een ML-Agent ontwikkeld die leert springen over obstakels in een 3D-omgeving. De agent gebruikt raycasts om obstakels in zijn omgeving te 
detecteren en ontvangt op basis daarvan observaties over zijn positie en verticale snelheid. Aan de hand van deze informatie beslist hij continu of hij moet 
springen. Obstakels worden dynamisch gespawnd en verwijderd door aparte scripts, waardoor de agent steeds nieuwe uitdagingen tegenkomt zonder dat de scene 
overbelast raakt.

De beloningsstructuur stimuleert de agent om efficiënt te springen: hij krijgt een kleine beloning voor elk moment dat hij overleeft, een bonus bij 
succesvol ontwijken van obstakels en straf wanneer hij botst of onnodig springt. Door deze opzet leert de agent een balans te vinden tussen voorzichtigheid
en actie, waarbij hij alleen springt wanneer het echt nodig is.

Tijdens de training werd duidelijk dat de instellingen van parameters zoals springkracht en beloningen een groot verschil maken. Springt de agent te laag 
of te hoog, dan faalt hij of vertoont hij chaotisch gedrag. Met goed afgestemde parameters en een evenwichtige beloningsstructuur leert de agent daarentegen
stabiel en efficiënt. Het laat zien hoe belangrijk het is om de wisselwerking tussen agent, omgeving en beloningen goed te begrijpen om de beste
leerresultaten te behalen.

<img width="909" height="446" alt="image" src="https://github.com/user-attachments/assets/02d917f4-efab-4660-b635-679e9fc47adb" />

We zien een duidelijke positieve evolutie in het gedrag van de agent. Hoewel er af en toe nog een fout voorkomt, blijft de slaagscore hoog.

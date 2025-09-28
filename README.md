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

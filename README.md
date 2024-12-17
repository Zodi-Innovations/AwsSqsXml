# AwsSqsXml

## Beschrijving
AwsSqsXml is een .NET-consoletoepassing die berichten uit een Amazon SQS-wachtrij leest en gebruikt om een vooraf gedefinieerd XML-sjabloonbestand aan te passen. Het project is ontworpen voor efficiënte labelverwerking of vergelijkbare geautomatiseerde taken.

## Functionaliteiten
- **Ontvangst van berichten**: Verbindt met een AWS SQS-wachtrij en haalt meerdere berichten tegelijk op.
- **Aanpassing van XML**: Werkt tekstvelden in een XML-sjabloonbestand bij met gegevens uit de berichten.
- **Verwijdering van verwerkte berichten**: Verwijdert berichten uit de wachtrij na succesvolle verwerking.

## Vereisten
- .NET 6+
- AWS SQS-toegang
- XML-sjabloonbestand

## NuGet Packages
- **AWSSDK.SQS**
- **AWSSDK.Core**

### Auteur
Ismail El Kaddaoui 


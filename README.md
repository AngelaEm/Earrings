# Örhängen Webbapplikation

Detta är en webbapplikation som visar örhängen till försäljning. Applikationen är byggd med .NET och använder Docker och Docker Compose för att hantera körning och testning av applikationen.

## Förutsättningar

Innan du börjar, se till att du har följande installerat på din maskin:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET SDK](https://dotnet.microsoft.com/download)

## Steg-för-steg Guide

### 1. Klona detta repository

git clone <URL-to-your-repository>
cd <repository-directory>


### 2. Se till att din `appsettings.json` innehåller en korrekt connectionstring för att ansluta till SQL-server databasen som körs i Docker.


{
  "ConnectionStrings": {
    "DefaultConnection": "Server=sqlserver;Database=EarringsDb;User Id=sa;Password=<YourStrong!Passw0rd>;"
  }
}

### 3. Lägg till SA-lösenordet till din Docker-Compose

### 4. Bygg och starta containrarna med:

docker-compose up --build

### 5. När containrarna körs, navigera till:

http://localhost:8080

### 6. Stoppa containrar med:

docker-compose down



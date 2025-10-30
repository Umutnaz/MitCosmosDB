# 💼 Cosmos Support WebApp

## 📘 Formål
Formålet med dette projekt er at udvikle en enkel, brugervenlig webapplikation, hvor man kan oprette og se supporthenvendelser.  
Projektet skulle være lavet med CosmosDB Azure som database.

---

## 🪐Hvordan du opretter en CosmoDB med Az KMDO
- $ export DBACCOUNT="ibas-db-account"-$RANDOM
- $ export RESGRP="IBasSupportRG" # Brug gruppenavnet anvendt i opgave A
- $ az cosmosdb create --name $DBACCOUNT --resource-group $RESGRP --enable-free-tier true
- $ export DATABASE="IBasSupportDB"
- $ az cosmosdb sql database create --account-name $DBACCOUNT \
- --resource-group $RESGRP --name $DATABASE
---
## 🔗Hvordan bruger du min app?
- Program.cs ln 13
- builder.Services.AddSingleton(sp => { var connectionString = "INDSÆT HER"; return new CosmosClient(connectionString); });
- Indsæt din connectionstring ved INDSÆT HER

---
## 📉Status
#### Jeg nået det som jeg gerne ville med opgaven, nemlig at forbinde til db,en oprette og se henvendelser på frontend

---
## 👟Næste skridt
- Næste skridt for systemet ville være at give brugeren mulighed for at slette henvendelser
- Dernæst redigere i henvendelser
#### 📈Yderligere niveau
- Med rolle indeling på og en login side, kunne man gøre således at kun "kunder" kan oprette og kun "admin" kan se/slette og redigere alle henvendelser

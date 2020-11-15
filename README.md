Battleship State Tracker API
=================

A Battleship state tracking API ws built for a single player that must
support the following logic:
• Create a board
• Add a battleship to the board
• Take an “attack” at a given position, and report back whether the attack
resulted in a hit or a miss.
The API should not support the entire game, just the state tracker. No graphical
interface or persistence layer is required. 

### To Run API:

* cd BattleshipStateTracker folder 
* start .sln solution in visual studio.
* Deployed swagger: https://battleshipstatetrackerweb20201116074713.azurewebsites.net/swagger/
* Deployed app: https://battleshipstatetrackerweb20201116074713.azurewebsites.net/

### To Run tests:

* Build and run all tests in Visual Studio.


### Architecture:

* .NET core 3.1. used for WebAPI
* DI used for IOC.
* xUnit used as test framework.
* Shouldly used to write test conditions in BDD fashion.

### Known issues:

* None

### Possible Improvements:

* Integration tests
* Controller models + DTOs
* Setup Dev, Staging, PROD environments (config files, CI/CD) 
* BDD-FY test cases using BDDFY to make test cases more readable.
* More detailed error handling.

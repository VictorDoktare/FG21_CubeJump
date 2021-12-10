# FG21 GamePatterns Assignment
Victor Doktare  
A simple game abut avoiding obstacles. Main focus with this game was to test out using state pattern for the player movement.

**-State Pattern:**  
  Player State Machine in `PlayerController.cs` in `class PlayerController`.  
  
   Player State - `Idle.cs` in `class Idle`  
   Player State - `Moving.cs` in `class Moving`  
   Player State - `Jump.cs` in `class Jump`  
   Player State - `Falling.cs` in `class Falling`  
   
 Used a hierarchical finite state machine to keep track of the different player states and avoid a bool spaghetti.  
 
 ![test](https://i.ibb.co/SQzK2dt/FSM-Flowchart.png)  
 
**-Singleton Pattern:**  
  `EventManager.cs` in `class EventManager` as `EventManager.Instance`.  
   Used as an accessible subject for the observer pattern.  
   
  `PoolManager.cs` in `class PoolManager` as `PoolManager.Instance`.  
   Used for easy access to the PoolManager.
   
  `SceneManager.cs` in `class SceneManager` as `SceneManager.Instance`.  
   Used by UI buttons to change scenes.  
   
 **-Observer Pattern:**  
  Subject - `EventManager.cs` in `class EventManager`.  
  
  Observer - `ObstacleSpawmner.cs` in `class ObstacleSpawner` subscribes to `EventManager.Instance.ONPlayerDeath`  
  Used to dissable the spawner when game ends.
  
  Observer - `EndMenu.cs` in `class EndMenu` subscribes to `EventManager.Instance.ONPlayerDeath`  
  Used to dissable UI canvas when game ends.
  
  Observer - `ScoreCount.cs` in `class ScoreCount` subscribes to `EventManager.Instance.ONScore`  
  Used to update score UI.
   

#Task Info:
You should create a generic mechanism that takes care of objects productivity during a pause in the game. 
While paused the objects should suspend their activity, and after unpause the objects should compensate the production, 
which would take place during the pause.

1. Several active objects in the scene:
  a. One type produces a resource (float) at a rate of: production rate per hour (incrementation);
  b. The other type produces gameObjects (the simplest example: cube) with a frequency of x per hour.
2. Response to game pause  - objects should suspend production.
3. Responding to the reactivation of the game - the production of objects should catch up with pauses, as if it had never been turned off.

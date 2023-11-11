# TTRPG_Godot

This is a project to adapt the (great) Unity tutorial of http://theliquidfire.com/2015/05/04/tactics-rpg-series-intro/ to Godot.

Considering my background and to stick to the root material, I mostly used C#. For now, there is no GDScript in this project but I might if I feel like I need it.

## How to use

Launch in Godot.

### Enemy Generation

You can generate enemies by changing the bestiary.csv. It should auto reload and generate new enemies in import/enemies, thanks to the enemy import addon.

### Board Creation

You can generate levels by going to the board creator and setting the packed scene (See Godot Doc). You can then save or load a level and expand on it, mostly thanks to the board creator addon.

### Input Events repeater

You can directly listen to input events, in any of Godot ways, but you also can have input events as a repeater, essentially replicating part 4 of the original tutorial.
Basically, you just have to add the input you'd like to be repeated inside of the InputManager file and then you can listen to the event as you would any of your other inputs. Take a look at InputManager for an example of how to use it!
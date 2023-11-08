# TTRPG_Godot
This is a project to adapt the (great) Unity tutorial of http://theliquidfire.com/2015/05/04/tactics-rpg-series-intro/ to Godot.
Considering my background and to stick to the root material, I mostly used C#. For now, there is no GDScript in this project but I might if I feel like I need it.

# How to use
Launch in Godot.
You can generate enemies by changing the bestiary.csv. It should auto reload and generate new enemies in import/enemies, thanks to the enemy import addon.
You can generate levels by going to the board creator and setting the packed scene (See Godot Doc). You can then save or load a level and expand on it, mostly thanks to the board creator addon.
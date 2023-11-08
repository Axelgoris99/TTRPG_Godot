using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
[Tool]
public partial class LevelData : Resource
{
    [Export]
    public Godot.Collections.Array<Vector3> tiles;
}
#if TOOLS
using Godot;
using System;

[Tool]
public partial class BoardCreatorPlugin : EditorPlugin
{
    private BoardInspector _plugin;

    public override void _EnterTree()
    {
        _plugin = new BoardInspector();
        AddInspectorPlugin(_plugin);
    }

    public override void _ExitTree()
    {
        RemoveInspectorPlugin(_plugin);
    }
}
#endif

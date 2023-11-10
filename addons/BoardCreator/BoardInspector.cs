// MyInspectorPlugin.cs
#if TOOLS
using Godot;
[Tool]

public partial class BoardInspector : EditorInspectorPlugin
{
    public override bool _CanHandle(GodotObject @object)
    {
        if (@object.HasMethod("GrowArea") || @object.HasMethod("Shrink"))
        {
            // ParseBegin will be called on every file that returns true.
            return true;
        }
        return false;
    }

    public override void _ParseBegin(GodotObject @object)
    {
        base._ParseBegin(@object);
        // We create a new board inspector editor and add it to the inspector.
        BoardInspectorEditor control = new BoardInspectorEditor();
        control.Alignment = BoxContainer.AlignmentMode.Center;
        control.Vertical = true;
        AddCustomControl(control);

    }
}
#endif
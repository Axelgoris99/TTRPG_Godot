#if TOOLS
using Godot;

[Tool]
public partial class EnemyImport : EditorPlugin
{
    EditorImportPlugin importPlugin;
    public override void _EnterTree()
    {
        // Initialization of the plugin goes here.
        importPlugin = new EnemyEditorImport();
        AddImportPlugin(importPlugin);
    }

    public override void _ExitTree()
    {
        // Clean-up of the plugin goes here.
        // Always remember to remove it from the engine when deactivated.
        RemoveImportPlugin(importPlugin);
        importPlugin = null;
    }
}
#endif
#if TOOLS

using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.IO;
public partial class EnemyEditorImport : EditorImportPlugin
{
	public override Error _Import(string sourceFile, string savePath, Godot.Collections.Dictionary
	options, Godot.Collections.Array<string> platformVariants, Godot.Collections.Array<string>
	genFiles)
	{
		string path = "res://import/enemies/";
		HandleDirectoryCreation();
		var file = Godot.FileAccess.Open(sourceFile, Godot.FileAccess.ModeFlags.Read);
		if (file == null)
		{
			return Error.FileNotFound;
		}
		file.GetLine(); // Skip header

		var lastValue = new EnemyData();
		while (!file.EofReached())
		{
			string line = file.GetLine();
			if (line == null)
			{
				break;
			}
			EnemyData enemyData = new EnemyData();
			enemyData.Load(line);
			string fileName = string.Format("{0}{1}.tres", path, enemyData.name);
			ResourceSaver.Save(enemyData, fileName);
			// This is to prevent caching so that the data are actualized in the editor.
			enemyData.TakeOverPath(fileName);
			lastValue = enemyData;
		}

		file.Close();
		file.Dispose();
		return ResourceSaver.Save(new Resource(), savePath + ".tres");
		//return Error.Ok;
	}

	public void HandleDirectoryCreation()
	{
		var dir = DirAccess.Open("res://");
		if (!dir.DirExists("import"))
		{
			dir.MakeDir("import");
		}
		dir = DirAccess.Open("res://import");
		if (!dir.DirExists("enemies"))
		{
			dir.MakeDir("enemies");
		}
	}

	public override string _GetImporterName()
	{
		return "EnemyEditorImporter";
	}
	public override string _GetVisibleName()
	{
		return "Enemy Importer";
	}
	public override string[] _GetRecognizedExtensions()
	{
		return new string[] { "csv" };
	}
	public override string _GetSaveExtension()
	{
		return "tres";
	}
	public override string _GetResourceType()
	{
		return "Resource";
	}
	public override int _GetPresetCount()
	{
		return 1;
	}
	public override string _GetPresetName(int presetIndex)
	{
		return "Default";
	}
	public override bool _GetOptionVisibility(string path, StringName optionName, Dictionary options)
	{
		return base._GetOptionVisibility(path, optionName, options);
	}

	public override int _GetImportOrder()
	{
		return 2;
	}
	public override Godot.Collections.Array<Godot.Collections.Dictionary> _GetImportOptions(string
	path, int presetIndex)
	{
		return new Godot.Collections.Array<Godot.Collections.Dictionary>
		{
			new Godot.Collections.Dictionary
			{
				{ "name", "myOption" },
				{ "default_value", false },
			}
		};
	}

}

#endif
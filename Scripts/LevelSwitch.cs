using Godot;
using System;

public partial class LevelSwitch : Area2D
{
	public enum OPERATOR_TYPE
	{
		ADD,
		MINUS,
		MULTIPLY,
		DIVIDE
	}

	[Export]
	public int currentLevelID = 0;

	[Export]
	public OPERATOR_TYPE operatorType = OPERATOR_TYPE.ADD;

	[Export]
	public int diceInput = 0;

	public int targetLevelID = 0;

	[Export]
	public string levelToLoadName = "";

	[Export]
	public string pathsToLevelFolder = "res://";

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void NextLevelCalculation(int diceInput)
	{
		this.diceInput = diceInput;

		switch (operatorType)
		{
			case OPERATOR_TYPE.ADD:
				targetLevelID = currentLevelID + diceInput;
				break;

			case OPERATOR_TYPE.MINUS:
				targetLevelID = currentLevelID - diceInput;
				break;

			case OPERATOR_TYPE.MULTIPLY:
				targetLevelID = currentLevelID * diceInput;
				break;

			case OPERATOR_TYPE.DIVIDE:
				if (diceInput == 0)
				{
					GD.PrintErr("LevelSwitch: division by zero avoided.");
					return;
				}
				targetLevelID = currentLevelID / diceInput;
				break;
		}


		string sceneToLoad = pathsToLevelFolder + levelToLoadName + targetLevelID + ".tscn";
		GetTree().ChangeSceneToFile(sceneToLoad);
		GD.PrintErr("sceneToLoad");
	}

	private void OnBodyEntered(Node2D body)
	{
		NextLevelCalculation(diceInput);
	}
}

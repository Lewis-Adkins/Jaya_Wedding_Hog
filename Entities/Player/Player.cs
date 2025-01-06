using Godot;
using System;

public partial class Player : Node3D
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{



		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var playerPosition         = Position;

		Node3D  startNode             = (Node3D)GetParent().GetNode("StartAreaNode");
		Node3D  startNodeStartingNode = (Node3D)startNode.GetChild(0);
		var     startNodeStartingNodePosition = startNodeStartingNode.Position;
		
	
		playerPosition = startNodeStartingNodePosition;

		GD.Print(playerPosition);

	}
}

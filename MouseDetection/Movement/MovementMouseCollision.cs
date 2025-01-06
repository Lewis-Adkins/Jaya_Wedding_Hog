using Godot;
using System;

public partial class MovementMouseCollision : CollisionShape3D
{
	
	public void SetDefaultCursor() {
		var defaultCursor = ResourceLoader.Load("res://Assets/CursorIcons/Default.png");
		Input.SetCustomMouseCursor(defaultCursor);
	}
	public void OnMouseEnter(Node3D startingNode, Node3D nextNode, string cursor, Vector3 cameraRotation) {
		var chosenCursor = ResourceLoader.Load("res://Assets/CursorIcons/" + cursor + ".png");
		Node3D mainNode        = (Node3D)GetNode("../../../");
		Node3D playerNode      = (Node3D)mainNode.GetNode("Player");
		Camera3D playerCamera  = (Camera3D)playerNode.GetNode("PlayerCamera");
		Vector3 playerPosition =  playerNode.GlobalPosition;

		GD.Print(cursor);
	}

	public void OnMouseExit() {
		SetDefaultCursor();
	}
	public override void _Ready()
	{	
		Callable cOnMouseEnter = new Callable(this, MethodName.OnMouseEnter);
		Callable cOnMouseExit  = new Callable(this, MethodName.OnMouseEnter);
		Connect("mouse_entered", cOnMouseEnter);
		Connect("mouse_exited", cOnMouseExit);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

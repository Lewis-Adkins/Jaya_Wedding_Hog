using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class MovementMouseButton : Button
{
	
    public Node3D StartingNode {get; set;}
    public Node3D NextNode{get; set;}
    public string CursorName{get; set;}
    public Vector3 CameraRotationAxis{get; set;}
    public float CameraRotationRadians{get; set;}

	    public void Configure(Vector2 position, Node3D startingNode, Node3D nextNode, string cursorName, Vector3 cameraRotationAxis, float cameraRotationRadians)
    {
		Position              = position;
        StartingNode          = startingNode;
        NextNode              = nextNode;
        CursorName            = cursorName;
        CameraRotationAxis    = cameraRotationAxis;
        CameraRotationRadians = cameraRotationRadians;
    }
	public void SetCursor(string cursorName) {
		var chosenCursor = ResourceLoader.Load("res://Assets/CursorIcons/"+ cursorName + ".png");
		Input.SetCustomMouseCursor(chosenCursor);
	}
	public void OnMouseEnter() {
		SetCursor(CursorName);
		}
	public void OnMouseExit() {
		SetCursor("Default");
	}
	public void OnMousePressed() {
		Node3D   mainNode   = (Node3D)GetNode("../../../../../");
		Node3D   playerNode = (Node3D)mainNode.GetNode("Player");

		if (playerNode.GlobalPosition == StartingNode.GlobalPosition){
			Camera3D playerCamera     = (Camera3D)playerNode.GetNode("PlayerCamera");
			playerNode.GlobalPosition = NextNode.GlobalPosition;
			playerCamera.Rotate(CameraRotationAxis, CameraRotationRadians);
	
			GD.Print(CursorName);
		}
		 		
	}
	public override void _Ready()
	{			
		Callable cOnMouseEnter = new Callable(this, MethodName.OnMouseEnter);
		Callable cOnMouseExit  = new Callable(this, MethodName.OnMouseExit);
		Callable cOnMouseClick = new Callable(this, MethodName.OnMousePressed);

		Connect("mouse_entered", cOnMouseEnter);
		Connect("mouse_exited", cOnMouseExit);
		Connect("pressed", cOnMouseClick);
	}

	}




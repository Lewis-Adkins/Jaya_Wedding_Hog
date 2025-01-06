using Godot;
using System;

public partial class PositionNode1CanvasLayer : CanvasLayer
{
    public override void _Ready()
    {

        
        var forwardButtonScene = GD.Load<PackedScene>("res://Interactives/MouseInteractionsPanels/Movement/Movement.tscn");
        var forwardButtonInstance = forwardButtonScene.Instantiate();
        Node3D nextNode           = (Node3D)this.GetParent().GetParent().GetNode("PositionNodes2");
        Node3D startNode          = (Node3D) this.GetParent();

        // Access the Button child and cast to MovementMouseButton
        var button = forwardButtonInstance.GetNode<Button>("MovementMouseButton"); // Adjust the path if needed

        if (button is MovementMouseButton forwardButton)
        {
            // Set properties
            forwardButton.Configure(  
                new Vector2(425,100),
                startNode,             
                nextNode,
                "Forward",
                new Vector3(1.0f, 0.0f, 0.0f),
                0.0f);
            
                /*
            forwardButton.startingNode = (Node3D)GetParent();
            forwardButton.nextNode = (Node3D)GetParent().GetParent().GetNode("PositionNodes2");
            forwardButton.cursorName = "Forward";
            forwardButton.cameraRotationAxis = new Vector3(0.0f, 1.0f, 0.0f);
            forwardButton.cameraRotationRadians = 0.0f;*/


        }
        else
        {  
            GD.PrintErr("Failed to cast the Button to MovementMouseButton.");
        }

        // Add the root Control node to the scene
        AddChild(forwardButtonInstance);
    }
}

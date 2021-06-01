using Godot;
using System;

public class Portal : Area
{
	[Export]
	public NodePath otherPortalPath;
	private Portal otherPortal = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (otherPortalPath != null) otherPortal = GetNode<Portal>(otherPortalPath);
	}

	public void onCollide(Node body) {
		if (body is Player) otherPortal.teleport((Player)body);
	}

	public void teleport(Player player) {
        // Player should not spawn in the portal, so an offset of 2 times z vector is applied.
		Vector3 exitPosition = GlobalTransform.origin + GlobalTransform.basis.z * 2;
		Vector3 enterPosition = player.GlobalTransform.origin;
        // Process of the translation between the position of the player and the position of the portal.
		Vector3 translation = exitPosition - enterPosition;
        // Apply translation.
		player.Translate(translation);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

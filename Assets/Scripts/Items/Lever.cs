using Godot;
using System;

public class Lever : StaticBody, Usable
{
	[Export]
	public NodePath conveyerPath;
	[Export]
	public int state = 0;

	private Spatial red;
	private Spatial green;
	private DirectionalConveyer conveyer = null;

	public override void _Ready()
	{
		base._Ready();

		red = GetChildren()[0] as Spatial;
		green = GetChildren()[1] as Spatial;
		if (conveyerPath != null) conveyer = GetNode<DirectionalConveyer>(conveyerPath);

		applyState();
	}

	public void applyState() {
		switch(state) {
			case 0:
				red.Visible = true;
				green.Visible = false;
				break;
			default:
				red.Visible = false;
				green.Visible = true;
				break;
		}
	}

	public void use()
	{
		if (conveyer != null) conveyer.switchPosition();
		state = (state + 1) % 2;
		applyState();
	}
}

using Godot;
using System.Collections.Generic;

public class Teapot : RigidBody {
	private LinkedList<Conveyer> Conveyers { get; } = new LinkedList<Conveyer>();
	private LinkedList<double> TimeOnRails { get; } = new LinkedList<double>();

	public void _on_Teapot_body_entered(object node) {
		if (node is Conveyer) { 
			Conveyers.AddLast((Conveyer)node);
			TimeOnRails.AddLast(0.0);
		}
	}

	public void _on_Teapot_body_exited(object node) {
		if (node is Conveyer) {
			Conveyers.RemoveFirst();
			TimeOnRails.RemoveFirst();
		}
	}

	public override void _Process(float delta) {
		if (Conveyers.Count > 0 && TimeOnRails.Count > 0) {
			Vector3 newPosition = Conveyers.Last.Value.GetPosition(TimeOnRails.Last.Value);

			Translation += newPosition - GlobalTransform.origin;

			TimeOnRails.Last.Value += delta;
		}
	}
}

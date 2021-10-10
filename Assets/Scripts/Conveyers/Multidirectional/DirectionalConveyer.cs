using Godot;
using System;

public class DirectionalConveyer : MultidirectionalConveyer
{
    private const float SQUARE_ANGLE = (float)(Math.PI/2.0);
    [Export] int position = 0;

    private Spatial arrow;


    public override void _Ready() {
        base._Ready();

        arrow = GetChildren()[1] as Spatial;
    }

    public void switchPosition() {
        position = (position + 1) % 2;

        // Apply visual effect.
        switch(position) {
            case 0:
                arrow.Rotate(GlobalTransform.basis.y, -SQUARE_ANGLE);
                break;
            default:
                arrow.Rotate(GlobalTransform.basis.y, SQUARE_ANGLE);
                break;
        }
    }

    public override Vector3 GetPosition(double elapsedTime) {
        double t = elapsedTime / TravelDuration;

        if (elapsedTime < 0.5) {
            t /= 0.5;
            return EntryPoint + (float)t * PathVector[0];
        } else {
            t = (t - 0.5) / 0.5;
            switch (position) {
                case 0:
                    return MidPoint + (float)t * PathVector[0];
                case 1:
                    return MidPoint + (float)t * PathVector[1];
                default:
                    throw new InvalidOperationException("position must be 0 or 1.");
            }
        }
    }
}

using Godot;
using System;
using System.Collections.Generic;

public class Camera : Godot.Camera {
    [Export] List<NodePath> PlayersPath = new List<NodePath>();

    [Export] Vector3 CameraDistance = new Vector3(0.0f, -10.0f, -10.0f);

    private List<Player> players = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        players = new List<Player>(PlayersPath.Count);

        foreach (NodePath playerPath in PlayersPath)
        {
            players.Add(GetNode<Player>(playerPath));
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        Vector3 applicationPoint = new Vector3();

        foreach (Player player in players)
        {
            applicationPoint += player.GlobalTransform.origin;
        }

        applicationPoint /= players.Count;

        Vector3 translation = (applicationPoint + CameraDistance) - GlobalTransform.origin;

        Translation += translation;
    }
}

using Godot;
using System;

public class EdgeColliders : Node2D
{
    private void UpdateEdge(){
        var x = GetViewport().Size.x;
        var y = GetViewport().Size.y;
        // 上边缘
        UpdateEdgeCollider("Top", new Vector2(x / 2, 0), new Vector2(-x / 2, 0), new Vector2(x / 2, 0));
        // 下边缘
        UpdateEdgeCollider("Bottom", new Vector2(x / 2, y), new Vector2(-x / 2, 0), new Vector2(x / 2, 0));
        // 左边缘
        UpdateEdgeCollider("Left", new Vector2(0, y / 2), new Vector2(0, -y / 2), new Vector2(0, y / 2));
        // 右边缘
        UpdateEdgeCollider("Right", new Vector2(x, y / 2), new Vector2(0, -y / 2), new Vector2(0, y / 2));
        }
    private void UpdateEdgeCollider(string nodeName, Vector2 globalPosition, Vector2 start, Vector2 end)
    {
        var edge = GetNode<StaticBody2D>(nodeName);
        var collisionShape = edge.GetNode<CollisionShape2D>("CollisionShape2D");
        var segmentShape = (SegmentShape2D)collisionShape.Shape;
        segmentShape.A = start;
        segmentShape.B = end;
        edge.GlobalPosition = globalPosition;
    }
    public override void _Ready()
    {
        UpdateEdge();
        GetViewport().Connect("size_changed", this, nameof(UpdateEdge));
    }
}

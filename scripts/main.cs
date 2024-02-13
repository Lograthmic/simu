using Godot;
using System;
using System.Collections.Generic;

public class main : Node
{
	[Export]
	public AnimatedTexture textures;
	[Export]
	public int NumPerItem = 10;
	[Export]
	public int SafeRange = 20;
	[Export]
	public int velocity = 50;
	[Export]
	public PackedScene ps;
	private List<RigidBody2D> items = new List<RigidBody2D>();

	private void InstancingNewItem(int TextureIndex){
		if(ps == null || textures == null) return;
		var instance = ps.Instance() as RigidBody2D;
		var item = instance as Item;
		item.SetAnimatedTexture(textures);
		item.SetTexture(TextureIndex);
		var x = (int) GD.RandRange(SafeRange, GetViewport().Size.x - SafeRange);
		var y = (int) GD.RandRange(SafeRange, GetViewport().Size.y - SafeRange);
		instance.Position = new Vector2(x, y);
		var vx = (float) GD.RandRange(-1, 1);
		var vy = (float) GD.RandRange(-1, 1);
		instance.LinearVelocity = new Vector2(vx, vy) * velocity;
		items.Add(instance);
		AddChild(instance);
		GD.Print("初始化item: (", x, ",", y, "),(", vx, ",", vy, ")");
	}
	public override void _Ready(){
		GD.Randomize();
		for(int textureIndex = 0; textureIndex < textures.Frames; textureIndex++){
			for(int i=0; i<NumPerItem; i++) InstancingNewItem(textureIndex);
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		// GD.Print(GetViewport().Size);
	}
}

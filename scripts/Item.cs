using Godot;
using System;
using System.Collections.Generic;

public class Item : RigidBody2D
{
    public int TextureIndex;
    public AnimatedTexture textures;
    // todo: 加载自config的配置文件
    public int[,] TransMatrix = {{0, 0, 2},
                                 {0, 1, 1},
                                 {2, 1, 2}};
    public void SetAnimatedTexture(AnimatedTexture t){
        textures = t;
    }
    public void SetTexture(int index){
        var sprite = FindNode("Sprite") as Sprite;
        TextureIndex = index;
        sprite.Texture = textures.GetFrameTexture(index);
    }
    public void OnBodyEntry(PhysicsBody2D physicsBody2D){
        if(!(physicsBody2D is Item)) return;
        var another = physicsBody2D as Item;
        if(TextureIndex >= another.TextureIndex) return;
        var NewIndex = TransMatrix[TextureIndex, another.TextureIndex];
        SetTexture(NewIndex);
        another.SetTexture(NewIndex);
    }
    public override void _Ready(){
        Connect("body_entered", this, nameof(OnBodyEntry));
    }
}

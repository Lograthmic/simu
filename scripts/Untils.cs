using Godot;
using System;

public class Utils{
    static public Vector2 GetCenter(int x, int y, int Groups, int GroupNum){
        float cx = (float) (x/2+Math.Cos(2*Math.PI*GroupNum/Groups)*x/4);
        float cy = (float) (x/2+Math.Sin(2*Math.PI*GroupNum/Groups)*x/4);
        Vector2 center = new Vector2(cx, cy);
        return center;
    }

    static public Vector2 GetGussRandom(Vector2 center, double stdDev){
        var x = (float) Guss(center.x, stdDev);
        var y = (float) Guss(center.y, stdDev);
        return new Vector2(x, y);
    }

    static public double Guss(double mean, double stdDev){
        Random random = new Random();
        double u1 = 1.0 - random.NextDouble();
        double u2 = 1.0 - random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        double randNormal = mean + stdDev * randStdNormal; 
        return randNormal;
    }
}
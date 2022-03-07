using System;

[Serializable]
public class Ash: Tree
{
    public int leafCount;
    public Ash(int height, int age, int leafCount): base(height, age) 
    {
        this.leafCount = leafCount;
    }
    public Ash() { }
}
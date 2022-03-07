using System;

[Serializable]
public class Oak: Tree
{
    public int acornCount;
    public Oak(int height, int age, int acornCount): base(height, age)
    {
        this.acornCount = acornCount;
    }
    public Oak() { }
}
using System;
using System.Xml.Serialization;

[Serializable]
[XmlInclude(typeof(Oak))]
[XmlInclude(typeof(Ash))]
public class Tree : IComparable<Tree>
{
    public int age;
    public int height;
    public Tree(int height, int age)
    {
        this.age = age;
        this.height = height;
    }
    public Tree() { }
    internal int CompareTo(Tree maxTree)
    {
        return this.height.CompareTo(maxTree.height);
    }

    int IComparable<Tree>.CompareTo(Tree other)
    {
        return height.CompareTo(other.height);
    }
    public override string ToString()
    {
        if (this is Oak)
        {
            return $"Oak with height:{height} age:{age} acorn:{(this as Oak).acornCount}";
        }
        else
        {
            return $"Ash with height:{height} age:{age} leaf:{(this as Ash).leafCount}";
        }
    }
}
using System;
using System.Runtime.Serialization;

[DataContract, KnownTypeAttribute(typeof(Meat)), KnownTypeAttribute(typeof(Vegetable))]
internal class Ingredient: IComparable<Ingredient>
{
    [DataMember]
    public string Name;
    [DataMember]
    public int TimeToCook;
    public Ingredient(string name, int timeToCook)
    {
        this.Name = name;
        this.TimeToCook = timeToCook;
    }

    public int CompareTo(Ingredient other)
    {
        return other.TimeToCook.CompareTo(TimeToCook);
    }

    public override string ToString()
    {
        return Name;
    }
    
}
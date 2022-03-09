using System;
using System.Xml.Serialization;

public class Lamp : Furniture
{
    public int lifeTime;
    private Lamp() : base()
    {
    }
    public Lamp(long id, TimeSpan lifeTime) : base(id)
    {
        this.lifeTime = ((int)lifeTime.TotalSeconds);
    }
}
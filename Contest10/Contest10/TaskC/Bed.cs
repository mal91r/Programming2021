using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlInclude(typeof(Pillow))]
public class Bed : Furniture
{
    [XmlElement("pillow")]
    public List<Pillow> pillows;
    Bed() { }
    public Bed(long id, List<Pillow> pillows) : base(id)
    {
        this.pillows = pillows;
    }
}
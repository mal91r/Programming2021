using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

internal class SimpleFurnitureSerializer
{
    public void Serialize(List<Furniture> furniture, string outputPath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Furniture>));
        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
        {
            ser.Serialize(fs, furniture);
        }
    }
}
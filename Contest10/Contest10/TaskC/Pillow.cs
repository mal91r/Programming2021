using System;
using System.Xml.Serialization;

[Serializable]
public class Pillow
{
    public long id;
    public string isRuined;

    Pillow() { }

    public Pillow(long id, bool isRuined)
    {
        switch (isRuined)
        {
            case true:
                this.isRuined = "Yes";
                break;
            case false:
                this.isRuined = "No";
                break;
        }
        this.id = id;
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[DataContract]
internal class Camera
{
    [DataMember]
    public int id;
    [DataMember]
    public List<Penalty> penalties = new List<Penalty>();
    public int maxSpeed;
    public Camera(int id, int maxSpeed)
    {
        this.id = id;
        this.maxSpeed = maxSpeed;
    }
}
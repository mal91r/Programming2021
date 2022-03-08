using System;
using System.Runtime.Serialization;

[DataContract]
internal class Penalty
{
    [DataMember]
    public int car_number;
    [DataMember]
    public int cost;
    public Penalty(int carNumber, int cost)
    {
        this.cost = cost;
        this.car_number = carNumber; 
    }
}
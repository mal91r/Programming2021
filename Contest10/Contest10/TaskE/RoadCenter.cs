using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
    
[DataContract]
internal class RoadCenter : ITrackingCenter
{
    Dictionary<int, Camera> camerasDict = new Dictionary<int, Camera>();
    [DataMember]
    List<Camera> cameras = new List<Camera>();

    public DataContractJsonSerializer DataContractJsonSerializerserializer { get; private set; }

    public void AddCamera(int id, int maxSpeed)
    {
        var camera = new Camera(id, maxSpeed);
        camerasDict.Add(id, camera);
        cameras.Add(camera);
    }

    public void CheckCarSpeed(int forCameraId, int carNumber, int carSpeed)
    {
        if (camerasDict.ContainsKey(forCameraId) && camerasDict[forCameraId].maxSpeed < carSpeed)
        {
            camerasDict[forCameraId].penalties.Add(new Penalty(carNumber, (carSpeed - camerasDict[forCameraId].maxSpeed) * 100));
        }
    }

    public void GetData(string inFilePath)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RoadCenter));
        using FileStream fs = new FileStream(inFilePath, FileMode.Create);
        serializer.WriteObject(fs, this);
    }
}
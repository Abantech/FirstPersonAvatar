using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

class UnityBody : IJointPositionUpdater<Windows.Kinect.Joint>
{
    public Dictionary<JointType, GameObject> jointCollection = new Dictionary<JointType, GameObject>();
    List<Bone> bones;
    private float jointSize = .1f;
    public ulong bodyID;


     
    public UnityBody(Body body)
    {
        bodyID = body.TrackingId;
        Color meshColor = GetNextColor();

        foreach (var joint in body.Joints)
        {
            var jgo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            jgo.transform.localScale = new Vector3(jointSize, jointSize, jointSize);
            jgo.name = joint.Key.ToString();

            //create a new material
            var materialColored = new Material(Shader.Find("Diffuse"));
            materialColored.color = meshColor;
            jgo.GetComponent<Renderer>().material = materialColored;
            jointCollection.Add(joint.Key, jgo);
        }

        bones = new List<Bone>();

        CreateBones();
    }

    public void UpdateJoints(IEnumerable<Windows.Kinect.Joint> joints)
    {
        foreach (var joint in joints)
        {
            jointCollection[joint.JointType].transform.position = new Vector3(joint.Value.Position.X, joint.Value.Position.Y + 1, joint.Value.Position.Z);
        }

        foreach (var bone in bones)
        {
            bone.Update();
        }
    }

    public void UpdateJoints(Dictionary<JointType, Windows.Kinect.Joint> joints)
    {
        foreach (var joint in joints)
        {
            jointCollection[joint.Key].transform.position = new Vector3(joint.Value.Position.X, joint.Value.Position.Y + 1, joint.Value.Position.Z);
        }

        foreach (var bone in bones)
        {
            bone.Update();
        }
    }

    internal void Clear()
    {

        foreach (var bone in bones)
        {
            UnityEngine.Object.Destroy(bone.GetBoneGameObject());
        }

        foreach (var joint in jointCollection)
        {
            UnityEngine.Object.Destroy(joint.Value);
        }
    }

    private void CreateBones()
    {
        // Head - Shoulder
        bones.Add(Bone.Create(jointCollection[JointType.Head], jointCollection[JointType.SpineShoulder]));
        // Sholder - Shoulder Right
        bones.Add(Bone.Create(jointCollection[JointType.SpineShoulder], jointCollection[JointType.ShoulderRight]));
        // Shoulder Right - Elbow
        bones.Add(Bone.Create(jointCollection[JointType.ShoulderRight], jointCollection[JointType.ElbowRight]));
        // Elbow Right - Wrist
        bones.Add(Bone.Create(jointCollection[JointType.ElbowRight], jointCollection[JointType.WristRight]));
        // Wrist Right - Hand
        bones.Add(Bone.Create(jointCollection[JointType.WristRight], jointCollection[JointType.HandRight]));
        // Wrist Right - Thumb
        bones.Add(Bone.Create(jointCollection[JointType.WristRight], jointCollection[JointType.ThumbRight]));
        // Shoulder - Shoulder Left
        bones.Add(Bone.Create(jointCollection[JointType.SpineShoulder], jointCollection[JointType.ShoulderLeft]));
        // Shoulder Left - Elbow
        bones.Add(Bone.Create(jointCollection[JointType.ShoulderLeft], jointCollection[JointType.ElbowLeft]));
        // Elbow Left - Wrist
        bones.Add(Bone.Create(jointCollection[JointType.ElbowLeft], jointCollection[JointType.WristLeft]));
        // Wrist Left - Hand
        bones.Add(Bone.Create(jointCollection[JointType.WristLeft], jointCollection[JointType.HandLeft]));
        // Wrist Left - Thumb
        bones.Add(Bone.Create(jointCollection[JointType.WristLeft], jointCollection[JointType.ThumbLeft]));
        // Shoulder - Spine Mid
        bones.Add(Bone.Create(jointCollection[JointType.SpineShoulder], jointCollection[JointType.SpineMid]));
        // Spine Mid - Spine Base
        bones.Add(Bone.Create(jointCollection[JointType.SpineMid], jointCollection[JointType.SpineBase]));
        // Spine Base - Hip Right
        bones.Add(Bone.Create(jointCollection[JointType.SpineBase], jointCollection[JointType.HipRight]));
        // Hip Right - Knee
        bones.Add(Bone.Create(jointCollection[JointType.HipRight], jointCollection[JointType.KneeRight]));
        // Knee Right - Ankle
        bones.Add(Bone.Create(jointCollection[JointType.KneeRight], jointCollection[JointType.AnkleRight]));
        //Ankle Right - Foot Right
        bones.Add(Bone.Create(jointCollection[JointType.AnkleRight], jointCollection[JointType.FootRight]));
        // Spine Base - Hip Left
        bones.Add(Bone.Create(jointCollection[JointType.SpineBase], jointCollection[JointType.HipLeft]));
        // Hip Left - Knee
        bones.Add(Bone.Create(jointCollection[JointType.HipLeft], jointCollection[JointType.KneeLeft]));
        // Knee Left - Ankle
        bones.Add(Bone.Create(jointCollection[JointType.KneeLeft], jointCollection[JointType.AnkleLeft]));
        //Ankle Left - Foot Left
        bones.Add(Bone.Create(jointCollection[JointType.AnkleLeft], jointCollection[JointType.FootLeft]));
    }

    private static Color GetNextColor()
    {
        Color returnColor = Color.black;
        colorCounter++;

        if (colorCounter == colors.Length)
        {
            colorCounter = 0;
        }

        returnColor = colors[colorCounter];

        return returnColor;
    }

    private static Color[] colors = new Color[] { Color.red, Color.green, Color.yellow, Color.blue, Color.magenta, Color.cyan, Color.black };
    private static int colorCounter = 0;
}
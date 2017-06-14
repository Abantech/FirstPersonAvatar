using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Struct that replicates the Kinect Joint type (can add to this later if needed)
/// </summary>
public enum HumanJointType : int
{
    SpineBase = 0,
    SpineMid = 1,
    Neck = 2,
    Head = 3,
    ShoulderLeft = 4,
    ElbowLeft = 5,
    WristLeft = 6,
    HandLeft = 7,
    ShoulderRight = 8,
    ElbowRight = 9,
    WristRight = 10,
    HandRight = 11,
    HipLeft = 12,
    KneeLeft = 13,
    AnkleLeft = 14,
    FootLeft = 15,
    HipRight = 16,
    KneeRight = 17,
    AnkleRight = 18,
    FootRight = 19,
    SpineShoulder = 20,
    HandTipLeft = 21,
    ThumbLeft = 22,
    HandTipRight = 23,
    ThumbRight = 24,
}

public static class HumanJointTypeUtil
{
    public static HumanJointType OppositeSideJoint(HumanJointType joint)
    {
        string jointName = joint.ToString();
        if (jointName.Contains("Right"))
        {
            string oppositeJointName = jointName.Replace("Right", "Left");
            return (HumanJointType)System.Enum.Parse(typeof(HumanJointType), oppositeJointName);
        }
        else if (jointName.Contains("Left"))
        {
            string oppositeJointName = jointName.Replace("Left", "Right");
            return (HumanJointType)System.Enum.Parse(typeof(HumanJointType), oppositeJointName);
        }

        return joint;
    }
}

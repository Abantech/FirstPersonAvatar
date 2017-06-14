using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class BodyJointPositionMapping : MonoBehaviour
{
    public Vector3 Offset;

    public bool IsInitialized { get; protected set; }

    public virtual bool IsTrackingHuman { get; protected set; }

    public Vector3 GetMidpointPosition(Vector3 vector1, Vector3 vector2)
    {
        return (vector1 + vector2) / 2;
    }

    public static IEnumerable<HumanJointType> GetAllJointTypes()
    {
        return Enum.GetValues(typeof(HumanJointType)).Cast<HumanJointType>();
    }

    public virtual bool TryGetMappedJointPosition(HumanJointType jointType, out Vector3 mappedJointPosition)
    {
        try
        {
            mappedJointPosition = GetMappedJointPosition(jointType);
            return true;
        }
        catch( Exception ex)
        {
            mappedJointPosition = Vector3.zero;
            Debug.LogWarningFormat("Unable to retrieve position for {0}: {1}", jointType.ToString(), ex.Message);
       }

       return false;
    }

    public Vector3 GetMappedJointPosition(HumanJointType jointType)
    {
        switch (jointType)
        {
            case HumanJointType.Head:
                return this.HeadPosition;
            case HumanJointType.Neck:
                return this.NeckPosition;
            case HumanJointType.SpineShoulder:
                return this.SpineShoulderPosition;
            case HumanJointType.SpineMid:
                return this.SpineMidPosition;
            case HumanJointType.SpineBase:
                return this.SpineBasePosition;

            case HumanJointType.ShoulderLeft:
                return this.LeftArmShoulderPosition;
            case HumanJointType.ElbowLeft:
                return this.LeftArmElbowPosition;
            case HumanJointType.WristLeft:
                return this.LeftArmWristPosition;
            case HumanJointType.HandLeft:
                return this.LeftArmHandPosition;
            case HumanJointType.HandTipLeft:
                return this.LeftArmHandTipPosition;
            case HumanJointType.ThumbLeft:
                return this.LeftArmHandThumbPosition;

            case HumanJointType.ShoulderRight:
                return this.RightArmShoulderPosition;
            case HumanJointType.ElbowRight:
                return this.RightArmElbowPosition;
            case HumanJointType.WristRight:
                return this.RightArmWristPosition;
            case HumanJointType.HandRight:
                return this.RightArmHandPosition;
            case HumanJointType.HandTipRight:
                return this.RightArmHandTipPosition;
            case HumanJointType.ThumbRight:
                return this.RightArmHandThumbPosition;

            case HumanJointType.HipLeft:
                return this.LeftLegHipPosition;
            case HumanJointType.KneeLeft:
                return this.LeftLegKneePosition;
            case HumanJointType.AnkleLeft:
                return this.LeftLegAnklePosition;
            case HumanJointType.FootLeft:
                return this.LeftLegFootPosition;

            case HumanJointType.HipRight:
                return this.RightLegHipPosition;
            case HumanJointType.KneeRight:
                return this.RightLegKneePosition;
            case HumanJointType.AnkleRight:
                return this.RightLegAnklePosition;
            case HumanJointType.FootRight:
                return this.RightLegFootPosition;

            default:
                throw new Exception("Unrecognized joint type");
                break;
        }
    }


    public abstract Vector3 HeadPosition { get; set; }
    public abstract Vector3 NeckPosition { get; set; }
    public abstract Vector3 SpineShoulderPosition { get; set; }
    public abstract Vector3 SpineMidPosition { get; set; }
    public abstract Vector3 SpineBasePosition { get; set; }

    #region Arms Positions
    public abstract Vector3 LeftArmShoulderPosition { get; set; }
    public abstract Vector3 LeftArmElbowPosition { get; set; }
    public abstract Vector3 LeftArmWristPosition { get; set; }
    public abstract Vector3 LeftArmHandPosition { get; set; }
    public abstract Vector3 LeftArmHandTipPosition { get; set; }
    public abstract Vector3 LeftArmHandThumbPosition { get; set; }

    public abstract Vector3 RightArmShoulderPosition { get; set; }
    public abstract Vector3 RightArmElbowPosition { get; set; }
    public abstract Vector3 RightArmWristPosition { get; set; }
    public abstract Vector3 RightArmHandPosition { get; set; }
    public abstract Vector3 RightArmHandTipPosition { get; set; }
    public abstract Vector3 RightArmHandThumbPosition { get; set; }
    #endregion

    #region Legs Positions
    public abstract Vector3 LeftLegHipPosition { get; set; }
    public abstract Vector3 LeftLegKneePosition { get; set; }
    public abstract Vector3 LeftLegAnklePosition { get; set; }
    public abstract Vector3 LeftLegFootPosition { get; set; }

    public abstract Vector3 RightLegHipPosition { get; set; }
    public abstract Vector3 RightLegKneePosition { get; set; }
    public abstract Vector3 RightLegAnklePosition { get; set; }
    public abstract Vector3 RightLegFootPosition { get; set; }
    #endregion
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AvatarSynchronizer : MonoBehaviour
{
    //Source 
    public BodyJointPositionMapping AuthoritativePositionSource;
    public BodyJointPositionMapping MocapDataSource;
    public BodyJointPositionMapping AvatarTarget;

    private void Start()
    {
    }

    private void Update()
    {
        if (MocapDataSource.IsInitialized && AvatarTarget.IsInitialized)
        {
            AvatarTarget.HeadPosition = MocapDataSource.HeadPosition;
            AvatarTarget.NeckPosition = MocapDataSource.NeckPosition;
            AvatarTarget.SpineShoulderPosition = MocapDataSource.SpineShoulderPosition;
            AvatarTarget.SpineMidPosition = MocapDataSource.SpineMidPosition;
            AvatarTarget.SpineBasePosition = MocapDataSource.SpineBasePosition;

            AvatarTarget.LeftArmShoulderPosition = MocapDataSource.LeftArmShoulderPosition;
            AvatarTarget.LeftArmElbowPosition = MocapDataSource.LeftArmElbowPosition;
            AvatarTarget.LeftArmWristPosition = MocapDataSource.LeftArmWristPosition;
            AvatarTarget.LeftArmHandPosition = MocapDataSource.LeftArmHandPosition;
            AvatarTarget.LeftArmHandTipPosition = MocapDataSource.LeftArmHandTipPosition;
            AvatarTarget.LeftArmHandThumbPosition = MocapDataSource.LeftArmHandThumbPosition;

            AvatarTarget.RightArmShoulderPosition = MocapDataSource.RightArmShoulderPosition;
            AvatarTarget.RightArmElbowPosition = MocapDataSource.RightArmElbowPosition;
            AvatarTarget.RightArmWristPosition = MocapDataSource.RightArmWristPosition;
            AvatarTarget.RightArmHandPosition = MocapDataSource.RightArmHandPosition;
            AvatarTarget.RightArmHandTipPosition = MocapDataSource.RightArmHandTipPosition;
            AvatarTarget.RightArmHandThumbPosition = MocapDataSource.RightArmHandThumbPosition;

            AvatarTarget.LeftLegHipPosition = MocapDataSource.LeftLegHipPosition;
            AvatarTarget.LeftLegKneePosition = MocapDataSource.LeftLegKneePosition;
            AvatarTarget.LeftLegAnklePosition = MocapDataSource.LeftLegAnklePosition;
            AvatarTarget.LeftLegFootPosition = MocapDataSource.LeftLegFootPosition;

            AvatarTarget.RightLegAnklePosition = MocapDataSource.RightLegAnklePosition;
            AvatarTarget.RightLegKneePosition = MocapDataSource.RightLegKneePosition;
            AvatarTarget.RightLegFootPosition = MocapDataSource.RightLegFootPosition;
            AvatarTarget.RightLegHipPosition = MocapDataSource.RightLegHipPosition;
            
        }
    }
}
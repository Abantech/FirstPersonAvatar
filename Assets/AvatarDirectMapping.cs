using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class AvatarDirectMapping : BodyJointPositionMapping
{
    public GameObject Head;
    public GameObject Neck;
    public GameObject Chest;
    public GameObject UpperSpine;
    public GameObject LowerSpine;
    public GameObject Hips;

    public GameObject RightArmShoulder;
    public GameObject RightArmUpper;
    public GameObject RightArmLower;
    public GameObject RightArmHand;

    public GameObject LeftArmShoulder;
    public GameObject LeftArmUpper;
    public GameObject LeftArmLower;
    public GameObject LeftArmHand;

    public GameObject RightLegUpper;
    public GameObject RightLegLower;
    public GameObject RightLegFoot;
    public GameObject RightLegToes;

    public GameObject LeftLegUpper;
    public GameObject LeftLegLower;
    public GameObject LeftLegFoot;
    public GameObject LeftLegToes;

    List<Bone> BoneList = new List<Bone>();

    private void Start()
    {
        
    }

    private void Update()
    {
        this.IsInitialized =
            !(Head == null &&
            //     Neck == null && 
            Hips == null &&
            UpperSpine == null &&
            //     Chest == null && 
            //     RightArmShoulder == null && 
            RightArmUpper == null &&
            RightArmLower == null &&
            RightLegUpper == null &&
            RightLegLower == null &&
            RightLegFoot == null &&
            //     RightLegToes == null && 
            //     LeftArmShoulder == null && 
            LeftArmUpper == null &&
            LeftArmLower == null &&
            LeftLegUpper == null &&
            LeftLegLower == null &&
            LeftLegFoot == null 
            //     LeftLegToes == null
            );

        if (BoneList.Count == 0)
        {
            BoneList.Add(Bone.AssociateBoneJoints(Head, () => HeadPosition, () => NeckPosition));
            BoneList.Add(Bone.AssociateBoneJoints(Neck, () => NeckPosition, () => SpineShoulderPosition));

            BoneList.Add(Bone.AssociateBoneJoints(Chest, () => NeckPosition, () => ChestPosition));
            BoneList.Add(Bone.AssociateBoneJoints(UpperSpine, () => ChestPosition, () => LowerSpineTipPosition));
            BoneList.Add(Bone.AssociateBoneJoints(LowerSpine, () => LowerSpineTipPosition, () => HipsPosition));
            BoneList.Add(Bone.AssociateBoneJoints(Hips, () => LowerSpineTipPosition, () => SpineBasePosition));

            BoneList.Add(Bone.AssociateBoneJoints(RightArmShoulder, () => SpineShoulderPosition, () => RightCollarBonePosition));
            BoneList.Add(Bone.AssociateBoneJoints(RightArmUpper, () => RightCollarBonePosition, () => RightArmElbowPosition));
            BoneList.Add(Bone.AssociateBoneJoints(RightArmLower, () => RightArmElbowPosition, () => RightArmWristPosition));
            BoneList.Add(Bone.AssociateBoneJoints(RightArmHand, () => RightArmWristPosition, () => RightArmHandTipPosition));

            BoneList.Add(Bone.AssociateBoneJoints(RightLegUpper, () => SpineBasePosition, () => RightLegHipPosition));
            BoneList.Add(Bone.AssociateBoneJoints(RightLegLower, () => SpineBasePosition, () => RightLegKneePosition));
            BoneList.Add(Bone.AssociateBoneJoints(RightLegFoot, () => RightLegKneePosition, () => RightLegAnklePosition));
            BoneList.Add(Bone.AssociateBoneJoints(RightLegToes, () => RightLegAnklePosition, () => RightLegFootPosition));

            BoneList.Add(Bone.AssociateBoneJoints(LeftArmShoulder, () => SpineShoulderPosition, () => LeftCollarBonePosition));
            BoneList.Add(Bone.AssociateBoneJoints(LeftArmUpper, () => LeftCollarBonePosition, () => LeftArmElbowPosition));
            BoneList.Add(Bone.AssociateBoneJoints(LeftArmLower, () => LeftArmElbowPosition, () => LeftArmWristPosition));
            BoneList.Add(Bone.AssociateBoneJoints(LeftArmHand, () => LeftArmWristPosition, () => LeftArmHandTipPosition));

            BoneList.Add(Bone.AssociateBoneJoints(LeftLegUpper, () => SpineBasePosition, () => LeftLegHipPosition));
            BoneList.Add(Bone.AssociateBoneJoints(LeftLegLower, () => SpineBasePosition, () => LeftLegKneePosition));
            BoneList.Add(Bone.AssociateBoneJoints(LeftLegFoot, () => LeftLegKneePosition, () => LeftLegAnklePosition));
            BoneList.Add(Bone.AssociateBoneJoints(LeftLegToes, () => LeftLegAnklePosition, () => LeftLegFootPosition));
        }

        //BoneList.ForEach(x => Bone.Update(x));
        foreach(var bone in BoneList)
        {
            Bone.Update(bone);
        }
    }

    public Vector3 ChestPosition { get { return GetMidpointPosition(SpineShoulderPosition, SpineMidPosition); } }
    public Vector3 RightCollarBonePosition { get { return GetMidpointPosition(SpineShoulderPosition, RightArmShoulderPosition); } }
    public Vector3 LeftCollarBonePosition { get { return GetMidpointPosition(SpineShoulderPosition, LeftArmShoulderPosition); } }
    public Vector3 LowerSpineTipPosition { get { return GetMidpointPosition(SpineMidPosition, HipsPosition); } }
    public Vector3 HipsPosition { get { return GetMidpointPosition(SpineBasePosition, SpineMidPosition); } }


    public override Vector3 HeadPosition { get; set; }
    public override Vector3 NeckPosition { get; set; }
    public override Vector3 SpineShoulderPosition { get; set; }
    public override Vector3 SpineMidPosition { get; set; }
    public override Vector3 SpineBasePosition { get; set; }

   
    public override Vector3 LeftArmShoulderPosition { get; set; }
    public override Vector3 LeftArmElbowPosition { get; set; }
    public override Vector3 LeftArmWristPosition { get; set; }
    public override Vector3 LeftArmHandPosition { get; set; }
    public override Vector3 LeftArmHandTipPosition { get; set; }
    public override Vector3 LeftArmHandThumbPosition { get; set; }


    public override Vector3 RightArmShoulderPosition { get; set; }
    public override Vector3 RightArmElbowPosition { get; set; }
    public override Vector3 RightArmWristPosition { get; set; }
    public override Vector3 RightArmHandPosition { get; set; }
    public override Vector3 RightArmHandTipPosition { get; set; }
    public override Vector3 RightArmHandThumbPosition { get; set; }

    public override Vector3 LeftLegHipPosition { get; set; }
    public override Vector3 LeftLegKneePosition { get; set; }
    public override Vector3 LeftLegAnklePosition { get; set; }
    public override Vector3 LeftLegFootPosition { get; set; }

    public override Vector3 RightLegHipPosition { get; set; }
    public override Vector3 RightLegKneePosition { get; set; }
    public override Vector3 RightLegAnklePosition { get; set; }
    public override Vector3 RightLegFootPosition { get; set; }
    

    /*
    public override Vector3 ChestPosition
    {
        get
        {
            return Chest.transform.position;
        }

        set
        {
            Chest.transform.position = value;
        }
    }

    public override Vector3 HeadPosition
    {
        get
        {
            return Head.transform.position;
        }

        set
        {
            Head.transform.position = value;
        }
    }

    public override Vector3 HipsPosition
    {
        get
        {
            return Hips.transform.position;
        }

        set
        {
            Hips.transform.position = value;
        }
    }

    public override Vector3 LeftArmElbowPosition
    {
        get
        {
            return LeftArmLower.transform.position;
        }

        set
        {
            LeftArmLower.transform.position = value;
        }
    }

    public override Vector3 LeftCollarBonePosition
    {
        get
        {
            return LeftArmShoulder.transform.position;
        }

        set
        {
            LeftArmShoulder.transform.position = value;
        }
    }

    public override Vector3 LeftArmShoulderPosition
    {
        get
        {
            return LeftArmUpper.transform.position;
        }

        set
        {
            LeftArmUpper.transform.position = value;
        }
    }

    public override Vector3 LeftArmWristPosition
    {
        get
        {
            return LeftArmWrist.transform.position;
        }

        set
        {
            LeftArmWrist.transform.position = value;
        }
    }

    public override Vector3 LeftLegAnklePosition
    {
        get
        {
            return LeftLegFoot.transform.position;
        }

        set
        {
            LeftLegFoot.transform.position = value;
        }
    }

    public override Vector3 LeftLegKneePosition
    {
        get
        {
            return LeftLegLower.transform.position;
        }

        set
        {
            LeftLegLower.transform.position = value;
        }
    }

    public override Vector3 LeftLegToesPosition
    {
        get
        {
            return LeftLegToes.transform.position;
        }

        set
        {
            LeftLegToes.transform.position = value;
        }
    }

    public override Vector3 LeftLegHipPosition
    {
        get
        {
            return LeftLegUpper.transform.position;
        }

        set
        {
            LeftLegUpper.transform.position = value;
        }
    }

    public override Vector3 NeckPosition
    {
        get
        {
            return Neck.transform.position;
        }

        set
        {
            Neck.transform.position = value;
        }
    }

    public override Vector3 RightArmElbowPosition
    {
        get
        {
            return RightArmLower.transform.position;
        }

        set
        {
            RightArmLower.transform.position = value;
        }
    }

    public override Vector3 RightCollarBonePosition
    {
        get
        {
            return RightArmShoulder.transform.position;
        }

        set
        {
            RightArmShoulder.transform.position = value;
        }
    }

    public override Vector3 RightArmShoulderPosition
    {
        get
        {
            return RightArmUpper.transform.position;
        }

        set
        {
            RightArmUpper.transform.position = value;
        }
    }

    public override Vector3 RightArmWristPosition
    {
        get
        {
            return RightArmWrist.transform.position;
        }

        set
        {
            RightArmWrist.transform.position = value;
        }
    }

    public override Vector3 RightLegAnklePosition
    {
        get
        {
            return RightLegFoot.transform.position;
        }

        set
        {
            RightLegFoot.transform.position = value;
        }
    }

    public override Vector3 RightLegKneePosition
    {
        get
        {
            return RightLegLower.transform.position;
        }

        set
        {
            RightLegLower.transform.position = value;
        }
    }

    public override Vector3 RightLegFootPosition
    {
        get
        {
            return RightLegToes.transform.position;
        }

        set
        {
            RightLegToes.transform.position = value;
        }
    }
    
    public override Vector3 RightLegHipPosition
    {
        get 
        {
            return RightLegUpper.transform.position; 
        }

        set
        {
            RightLegUpper.transform.position = value;
        }
    }

    public override Vector3 SpinePosition
    {
        get
        {
            return Spine.transform.position;
        }

        set
        {
            Spine.transform.position = value;
        }
    }
    */
}

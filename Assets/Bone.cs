using System;
using UnityEngine;

internal class Bone
{
    private GameObject boneGameObject;
    Func<Vector3> StartJointPositionGetter;
    Func<Vector3> EndJointPositionGetter;

    private float thickness = .05f;

    public static Bone Create(GameObject joint1, GameObject joint2)
    {
        return new Bone(joint1, joint2);
    }

    public static Bone AssociateBoneJoints(GameObject bone, Func<Vector3> startJointPositionGetter, Func<Vector3> endJointPositionGetter)
    {
        return new Bone(bone, startJointPositionGetter, endJointPositionGetter);
    }

    private Bone(GameObject joint1, GameObject joint2)
    {
        boneGameObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        boneGameObject.transform.localScale = new Vector3(thickness, thickness, thickness);
        boneGameObject.name = joint1.name + "-" + joint2.name + "Bone";
        StartJointPositionGetter = () => { return joint1.transform.position; };
        EndJointPositionGetter = () => { return joint2.transform.position; };
    }

    private Bone(GameObject bone, Func<Vector3> startJointPositionGetter, Func<Vector3> endJointPositionGetter)
    {
        boneGameObject = bone;
        StartJointPositionGetter = startJointPositionGetter;
        EndJointPositionGetter = endJointPositionGetter;
    }

    public static void Update(Bone bone)
    {
        float length = GetBoneLength(bone.StartJointPositionGetter(), bone.EndJointPositionGetter()) / 2;

        // Scale bone along local y to the length between two points
        bone.GetBoneGameObject().transform.localScale = new Vector3(bone.GetBoneGameObject().transform.localScale.x, length, bone.GetBoneGameObject().transform.localScale.z);

        // Set position to midpoint
        bone.GetBoneGameObject().transform.position = GetBoneMidpoint(bone.StartJointPositionGetter(), bone.EndJointPositionGetter());

        // Set "up" vector to match line between two points
        bone.GetBoneGameObject().transform.up = bone.EndJointPositionGetter() - bone.StartJointPositionGetter();
    }

    public static void UpdateLocation(Bone bone)
    {
        //float length = GetBoneLength(bone.StartJointPositionGetter(), bone.EndJointPositionGetter()) / 2;

        // Scale bone along local y to the length between two points
        //bone.GetBoneGameObject().transform.localScale = new Vector3(bone.GetBoneGameObject().transform.localScale.x, length, bone.GetBoneGameObject().transform.localScale.z);

        // Set position to midpoint
        bone.GetBoneGameObject().transform.position = GetBoneMidpoint(bone.StartJointPositionGetter(), bone.EndJointPositionGetter());

        // Set "up" vector to match line between two points
        //bone.GetBoneGameObject().transform.up = bone.EndJointPositionGetter() - bone.StartJointPositionGetter();
    }

    public GameObject GetBoneGameObject()
    {
        return boneGameObject;
    }

    private static float GetBoneLength(Vector3 startJointPosition, Vector3 endJointPosition)
    {
        return Vector3.Distance(startJointPosition, endJointPosition);
    }

    private static Vector3 GetBoneMidpoint(Vector3 startJointPosition, Vector3 endJointPosition)
    {
        return Vector3.Lerp(startJointPosition, endJointPosition, 0.5f);
    }
}
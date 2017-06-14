using UnityEngine;

internal class Bone
{
    private GameObject joint1;
    private GameObject joint2;
    private GameObject bone;
    private float thickness = .05f; 

    public static Bone Create(GameObject joint1, GameObject joint2)
    {
        return new Bone(joint1, joint2);
    }

    private Bone(GameObject joint1, GameObject joint2)
    {
        bone = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bone.transform.localScale = new Vector3(thickness, thickness, thickness);
        bone.name = joint1.name + "-" + joint2.name + "Bone";
        this.joint1 = joint1;
        this.joint2 = joint2;
    }

    public void Update()
    {
        float length = GetBoneLength(joint1, joint2) / 2;

        // Scale bone along local y to the length between two points
        bone.transform.localScale = new Vector3(bone.transform.localScale.x, length, bone.transform.localScale.z);

        // Set position to midpoint
        bone.transform.position = GetBoneMidpoint(joint1, joint2);

        // Set "up" vector to match line between two points
        bone.transform.up = joint2.transform.position - joint1.transform.position;
    }
    
    public GameObject GetBoneGameObject()
    {
        return bone;
    }

    private float GetBoneLength(GameObject joint1, GameObject joint2)
    {
        return Vector3.Distance(joint1.transform.position, joint2.transform.position);
    }

    private Vector3 GetBoneMidpoint(GameObject joint1, GameObject joint2)
    {
        return Vector3.Lerp(joint1.transform.position, joint2.transform.position, 0.5f);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Windows.Kinect;

public class KinectJointPositionMapper : IBodyPartPositionProvider
{
    Dictionary<JointType, GameObject> JointCollection { get; set;}

    public KinectJointPositionMapper()
    {
        JointCollection = new Dictionary<JointType, GameObject>(); 
    }

    public Vector3 Chest  
    {
        get 
        {
            return (JointCollection[JointType.SpineShoulder].transform.position + JointCollection[JointType.SpineMid].transform.position) / 2;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 Head
    {
        get
        {
            return JointCollection[JointType.Head].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }


    public Vector3 Neck
    {
        get
        {
            return JointCollection[JointType.Neck].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 Spine
    {
        get
        {
            return JointCollection[JointType.SpineMid].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 Hips
    {
        get
        {
            return JointCollection[JointType.SpineBase].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 RightArmShoulder
    {
        get
        {
            return (JointCollection[JointType.SpineShoulder].transform.position + JointCollection[JointType.ShoulderRight].transform.position) / 2;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 RightArmUpper
    {
        get
        {
            return JointCollection[JointType.ShoulderRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 RightArmLower
    {
        get
        {
            return JointCollection[JointType.ElbowRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 RightArmWrist
    {
        get
        {
            return JointCollection[JointType.WristRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 RightLegUpper
    {
        get
        {
            return JointCollection[JointType.HipRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 RightLegLower
    {
        get
        {
            return JointCollection[JointType.KneeRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 RightLegFoot
    {
        get
        {
            return JointCollection[JointType.AnkleRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 RightLegToes
    {
        get
        {
            return JointCollection[JointType.FootRight].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }


    public Vector3 LeftArmShoulder
    {
        get
        {
            return (JointCollection[JointType.SpineShoulder].transform.position + JointCollection[JointType.ShoulderLeft].transform.position) / 2;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 LeftArmUpper
    {
        get
        {
            return JointCollection[JointType.ShoulderLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 LeftArmLower
    {
        get
        {
            return JointCollection[JointType.ElbowLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 LeftArmWrist
    {
        get
        {
            return JointCollection[JointType.WristLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 LeftLegUpper
    {
        get
        {
            return JointCollection[JointType.HipLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 LeftLegLower
    {
        get
        {
            return JointCollection[JointType.KneeLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
    public Vector3 LeftLegFoot
    {
        get
        {
            return JointCollection[JointType.AnkleLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public Vector3 LeftLegToes
    {
        get
        {
            return JointCollection[JointType.FootLeft].transform.position;
        }

        set
        {
            throw new NotImplementedException();
        }
    }
}


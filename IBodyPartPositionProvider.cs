using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
  
    public interface IBodyPartPositionProvider
    {
        Vector3 Head { get; set; }
        Vector3 Neck { get; set; }

        Vector3 Hips { get; set; }
        Vector3 Spine { get; set; }
        Vector3 Chest { get; set; }
        Vector3 RightArmShoulder { get; set; }
        Vector3 RightArmUpper { get; set; }
        Vector3 RightArmLower { get; set; }
        Vector3 RightArmWrist { get; set; }

        Vector3 RightLegUpper { get; set; }
        Vector3 RightLegLower { get; set; }
        Vector3 RightLegFoot { get; set; }

        Vector3 RightLegToes { get; set; }

        Vector3 LeftArmShoulder { get; set; }
        Vector3 LeftArmUpper { get; set; }
        Vector3 LeftArmLower { get; set; }
        Vector3 LeftArmWrist { get; set; }

        Vector3 LeftLegUpper { get; set; }
        Vector3 LeftLegLower { get; set; }
        Vector3 LeftLegFoot { get; set; }

        Vector3 LeftLegToes { get; set; }

        //TO DO: Finger joints

    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Implement to defetermine the viewport position & orientation. This may be attached to the MainCamera or to whatever causes the head position and orientation to change.
/// </summary>   
interface IViewPortLocationProvider
{

    Vector3 CurrentWorldPosition { get; set; } 
    Quaternion CurrentOrientation { get; set; }  
} 
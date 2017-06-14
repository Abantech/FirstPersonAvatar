using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CalibrationManager
{
    public CalibrationManager(GameObject object1, GameObject object2, float tolerance, Action onCalibratedHandler, Action onNonCaliratedHandler)
    {
        GameObject object1Marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        object1Marker.GetComponent<Renderer>().enabled = false;
        object1Marker.AddComponent<SphereCollider>();
        object1Marker.GetComponent<SphereCollider>().radius = tolerance;
        object1Marker.name = object1.name + "-CalibrationMarker";
        object1Marker.transform.parent = object1.transform;
        object1Marker.AddComponent<Rigidbody>().isKinematic = true;
        object1Marker.transform.localPosition = Vector3.zero;

        //Add Calibration Sphere
        GameObject object2Marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        object2Marker.name = object2.name + "-CalibrationMarker";
        object2Marker.GetComponent<Renderer>().enabled = false;
        object2Marker.transform.parent = object2.transform;
        object2Marker.AddComponent<Rigidbody>().isKinematic = true;
        object2Marker.transform.localPosition = Vector3.zero;

        object2Marker.AddComponent<SphereCollider>();
        object2Marker.GetComponent<SphereCollider>().radius = tolerance;
        object2Marker.GetComponent<SphereCollider>().isTrigger = true;
        object2Marker.AddComponent<CalibrationHandler>();
        object2Marker.GetComponent<CalibrationHandler>().TriggerEnteredHandler = x => { if (x == object1Marker) { onCalibratedHandler(); } };
        object2Marker.GetComponent<CalibrationHandler>().TriggerExitedHandler = x => { if (x == object1Marker) { onNonCaliratedHandler(); } };
    }
}


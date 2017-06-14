using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CalibrationHandler : MonoBehaviour
{
    public Action<Collider> TriggerEnteredHandler;
    public Action<Collider> TriggerExitedHandler;
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarningFormat("TriggerHandler ENTER was tripped by: {0} / {1}", other.name, other.gameObject.name);
        if (TriggerEnteredHandler!=null)
        {
            TriggerEnteredHandler(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.LogWarningFormat("TriggerHandler EXIT was tripped by: {0} / {1}", other.name, other.gameObject.name);
        if (TriggerExitedHandler != null)
        {
            TriggerExitedHandler(other);
        }
    }
}

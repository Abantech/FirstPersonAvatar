using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using System.Linq;

public class DrawBodies : MonoBehaviour
{
    ConcurrentDictionary<ulong, UnityBody> bodies = new ConcurrentDictionary<ulong, UnityBody>();

    public bool HasBodyData { get { return Kinect.HasBodyData(); } }

    public Dictionary<JointType, GameObject> JointCollection
    {
        get
        {
            var keys = bodies.GetKeysArray();
            if (keys.Length > 0)
            {
                return bodies[keys.First()].jointCollection;
            }
            
            return new Dictionary<JointType, GameObject>();
        }
    }

    void Update()
    {
        if (Kinect.HasBodyData())
        {
            // Get Tracked Bodies
            var trackedBodies = Kinect.GetTrackedBodies();

            // Track bodies in the frame
            List<ulong> trackedBodiesIDsThisFrame = new List<ulong>();

            // Loop through tracked bodies
            foreach (var detectedBody in trackedBodies)
            {
                // Check if dictionary already contains body
                if (!bodies.ContainsKey(detectedBody.TrackingId))
                {
                    // Create new body
                    bodies.Add(detectedBody.TrackingId, new UnityBody(detectedBody));
                }

                // Update joints
                bodies[detectedBody.TrackingId].UpdateJoints(detectedBody.Joints.Values);

                // Add body id to tracked
                trackedBodiesIDsThisFrame.Add(detectedBody.TrackingId);
            }

            foreach (var key in bodies.GetKeysArray())
            {
                // Find old bodies in the dictionary
                if (!trackedBodiesIDsThisFrame.Contains(key))
                {
                    // Clear them
                    bodies[key].Clear();

                    // Remove them from the dictionary
                    bodies.Remove(key);
                }
            }
        }
        else
        {
            foreach (var key in bodies.GetKeysArray())
            {
                bodies[key].Clear();
            }

            bodies = new ConcurrentDictionary<ulong, UnityBody>();
        }
    }
}

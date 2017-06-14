using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Windows.Kinect;

public class LocalKinectController : MonoBehaviour
{
    private KinectSensor localKinectSensor;
    private BodyFrameReader bodyFrameReader;
    private static Body[] trackeBodyData = null;
    private static GameObject localKinectController;
    public static bool IsInitialized { get; private set; }

    public static Windows.Kinect.Body[] GetTrackedBodies()
    {
        return trackeBodyData.Where(x => x.IsTracked).ToArray();
    }

    public static bool HasBodyData()
    {
        return trackeBodyData != null && trackeBodyData.Count(x => x != null && x.IsTracked) > 0;
    }

    public static GameObject GetInstance()
    {
        if (IsInitialized)
        {
            return localKinectController;
        }
        else
        {
            throw new Exception("Local Controller not yet initialized.");
        }
    }

    void Start()
    {
        localKinectController = this.gameObject;
        AssignAndOpenSensor(KinectSensor.GetDefault());
    }

    private void AssignAndOpenSensor(KinectSensor sensor)
    {
        localKinectSensor = sensor;
        localKinectSensor.IsAvailableChanged += HandleSensorAvailabilityChanged;
        if (localKinectSensor != null)
        {
            bodyFrameReader = localKinectSensor.BodyFrameSource.OpenReader();

            if (!localKinectSensor.IsOpen)
            {
                localKinectSensor.Open();
                IsInitialized = true;
            }
        }
    }

    private void HandleSensorAvailabilityChanged(object sender, IsAvailableChangedEventArgs e)
    {
        IsInitialized = e.IsAvailable;
    }

    void Update()
    {
        if (!IsInitialized)
        {
            AssignAndOpenSensor(KinectSensor.GetDefault());
        }

        if (IsInitialized)
        {
            if (bodyFrameReader != null)
            {
                var frame = bodyFrameReader.AcquireLatestFrame();
                if (frame != null)
                {
                    if (trackeBodyData == null)
                    {
                        trackeBodyData = new Body[localKinectSensor.BodyFrameSource.BodyCount];
                    }

                    frame.GetAndRefreshBodyData(trackeBodyData);

                    frame.Dispose();
                    frame = null;
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        if (bodyFrameReader != null)
        {
            bodyFrameReader.Dispose();
            bodyFrameReader = null;
        }

        if (localKinectSensor != null)
        {
            if (localKinectSensor.IsOpen)
            {
                localKinectSensor.Close();
            }

            localKinectSensor = null;
        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Windows.Kinect;

public class LocalKinectController : MonoBehaviour
{
    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private static Body[] _Data = null;
    private static GameObject localKinectController;
    public static bool IsInitialized { get; private set; }

    public static Windows.Kinect.Body[] GetTrackedBodies()
    {
        return _Data.Where(x => x.IsTracked).ToArray();
    }

    public static bool HasBodyData()
    {
        return _Data != null && _Data.Count(x => x != null && x.IsTracked) > 0;
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
        IsInitialized = true;

        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();

            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
    }

    void Update()
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();
            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(_Data);

                frame.Dispose();
                frame = null;
            }
        }
    }

    void OnApplicationQuit()
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }

            _Sensor = null;
        }
    }

}


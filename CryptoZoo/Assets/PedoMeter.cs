using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class PedoMeter : MonoBehaviour
{
    public float LeftRight;
    public float UpDown;
    public bool DoOnce = false;
    public bool DoOnceUD = false;
    public bool LR;
    public bool UD;

    public int Steps;
    
     public void Update()
    {
        Shaking();

        Debug.Log(Steps);
        ///Debug.Log(Up);
        // Debug.Log(Right);
        // Debug.Log(Down);

    }

    private void Shaking()
    {
        LeftRight = Input.acceleration.y;
        UpDown = Input.acceleration.x;

        if(LeftRight > .05f)
        {
           // LR = true;
        }
        if (LeftRight < -.05f)
        {
            LR = false;
        }

        switch (LR)
        {
            case false:
                if(DoOnce == false) { 
                AddStep();
                    DoOnce = true;
                }
                break;
            case true:
                if(DoOnce == true) { 
                AddStep();
                DoOnce = false;
                }
                break;
        }


          if (UpDown > .05f && LR == false)
        {
            UD = true;
        }
        if (UpDown < -.05f)
        {
            UD = false;
        }

        switch (UD)
        {
            case false:
                if (DoOnceUD == false)
                {
                    AddStep();
                    DoOnceUD = true;
                }
                break;
            case true:
                if (DoOnceUD == true)
                {
                    AddStep();
                    DoOnceUD = false;
                }
                break;
        }
    }
    private void AddStep()
    {
        Steps += 1;
    }
    //#region
    //private static PedoMeter instance;
    //public static PedoMeter Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<PedoMeter>();
    //            if (instance == null)
    //            {
    //                instance = new GameObject("Spawned Accelerometer", typeof(PedoMeter)).GetComponent<PedoMeter>();
    //            }
    //        }
    //        return instance;
    //    }
    //    set
    //    {
    //        instance = value;
    //    }
    //}
    //#endregion

    //[Header("Shake Detection")]
    //public Action OnShake;
    //[SerializeField] private float shakeDetectionThreshold = 2.0f;
    //private float accelerometerUpdateInterval = 1.0f / 60.0f;
    //private float lowPassKernelWidthInSeconds = 1.0f;
    //private float lowPassFilterFactor;
    //private Vector3 lowPassValue;

    //private void Start()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //    lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
    //    shakeDetectionThreshold *= shakeDetectionThreshold;
    //    lowPassValue = Input.acceleration;

    //}
    //private void Update()
    //{
    //    Debug.Log(Input.acceleration);
    //    Vector3 acceleration = Input.acceleration;
    //    lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
    //    Vector3 deltaAcceleration = acceleration - lowPassValue;

    //    //Shake Detection
    //    if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)

    //        OnShake.Invoke();

    //}
    
}
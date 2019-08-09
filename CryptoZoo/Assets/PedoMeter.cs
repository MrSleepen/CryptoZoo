using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class PedoMeter : MonoBehaviour
{
    #region
    private static PedoMeter instance;
    public static PedoMeter Instance
    {
        get
        {
            if(instance == null)
            {
                instance =  FindObjectOfType<PedoMeter>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned Accelerometer", typeof(PedoMeter)).GetComponent<PedoMeter>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Shake Detection")]
    public Action OnShake;
    [SerializeField] private float shakeDetectionThreshold = 2.0f;
    private float accelerometerUpdateInterval = 1.0f / 60.0f;
    private float lowPassKernelWidthInSeconds = 1.0f;
    private float lowPassFilterFactor;
    private Vector3 lowPassValue;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
        
    }
    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        //Shake Detection
        if(deltaAcceleration.sqrMagnitude>= shakeDetectionThreshold)
        
            OnShake.Invoke();
        
    }
}
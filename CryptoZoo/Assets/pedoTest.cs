using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pedoTest : MonoBehaviour {

    public int StepCount;
    public Text StepCounttext;
	// Use this for initialization
	void Start () {
        PedoMeter.Instance.OnShake += ActionToRunWhenShakingDevice;
	}
    private void OnDestroy()
    {
        PedoMeter.Instance.OnShake -= ActionToRunWhenShakingDevice;
    }

    private void ActionToRunWhenShakingDevice()
    {
        StepCount += 1;
    }
    private void Update()
    {

        StepCounttext.text = StepCount.ToString();
    }
	
}

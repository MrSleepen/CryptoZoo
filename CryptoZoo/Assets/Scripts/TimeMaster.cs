using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour {

    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation;
    public static TimeMaster instance;
	// Use this for initialization
	void Awake () {
        instance = this;

        //set our player prefs to savelocation

        saveLocation = "Lastsavedate1";
	}
    //Checks the current time agaist the saved time and returns the difference in seconds;
    public float CheckDate()
    {
       currentDate = System.DateTime.Now;

        string tempString = PlayerPrefs.GetString(saveLocation, "1");

        long tempLong = Convert.ToInt64(tempString);

        DateTime oldDate = DateTime.FromBinary(tempLong);
        print("oldDate"+ oldDate);

        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Differnece" + difference);

        return (float)difference.TotalSeconds;
    }

    public void SaveDate()
    {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());
        print("Saving" + System.DateTime.Now);
    }
	//store the current time
  
    
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour {

    public bool JustBorn = false;
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log(PlayerPrefs.GetInt("HungerLevel"));
        
        if (JustBorn == true)
        {
            PlayerPrefs.SetInt("HungerLevel", 100);
        }

        while(PlayerPrefs.GetInt("HungerLevel")>=0){
            StartCoroutine(GettingHungry());
        }
	}

    public IEnumerator GettingHungry()
    {
        int HungerLevel = PlayerPrefs.GetInt("HungerLevel");
        PlayerPrefs.SetInt("HungerLevel", HungerLevel -=1);
        yield return new WaitForSeconds(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour {

    public bool JustBorn = false;
    private bool TimerTF = false;
    private int HungerLocal;
	
	// Update is called once per frame
	void Update () {
        HungerLocal = PlayerPrefs.GetInt("HungerLevel");


        if (JustBorn == true)
        {
            PlayerPrefs.SetInt("HungerLevel", 100);
            JustBorn = false;
        }

        while(PlayerPrefs.GetInt("HungerLevel")>=0 && TimerTF == false){
            TimerTF = true;
            StartCoroutine(GettingHungry());
        }
	}

    public IEnumerator GettingHungry()
    {
        Debug.Log(PlayerPrefs.GetInt("HungerLevel"));
        PlayerPrefs.SetInt("HungerLevel", HungerLocal -=1);
        yield return new WaitForSeconds(1);
        TimerTF = false;
    }
}

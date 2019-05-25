using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    // Use this for initialization
    public bool Eating = false;
    private int HungerLocal;

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("HungerLevel") < 100 && Eating == true)
        {
            PlayerPrefs.SetInt("HungerLevel", 100);
            Eating = false;
        }
    }

}
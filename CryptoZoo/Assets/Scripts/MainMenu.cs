using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject Overworld;
    public GameObject MainMenuScreen;


    //function to Open OverWorld Called from Button
    public void OverWorld()
    {
        Overworld.SetActive(true);
        MainMenuScreen.SetActive(false);
    }
    //function to Open Settings Menu Called from Button
    public void Settings()
    {
        Debug.Log("LoadSettings");
    }
}

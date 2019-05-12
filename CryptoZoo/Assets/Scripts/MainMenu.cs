using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject Overworld;
    public GameObject MainMenuScreen;



    public void OverWorld()
    {
        Overworld.SetActive(true);
        MainMenuScreen.SetActive(false);
    }

    public void Settings()
    {
        Debug.Log("LoadSettings");
    }
}

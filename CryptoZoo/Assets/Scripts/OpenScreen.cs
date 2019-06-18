using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScreen : MonoBehaviour
{
    public GameObject PlayScreen;
    public GameObject MainMenuScreen;
   //Funtion to Start Called from Button
    public void Play()
    {
        MainMenuScreen.SetActive(true);
        PlayScreen.SetActive(false);
    }
}
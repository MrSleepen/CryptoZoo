using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScreen : MonoBehaviour
{
    public GameObject PlayScreen;
    public GameObject MainMenuScreen;
    // Use this for initialization
    public void Play()
    {
        MainMenuScreen.SetActive(true);
        PlayScreen.SetActive(false);
    }
}
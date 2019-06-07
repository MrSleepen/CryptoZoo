using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Create the game manager and make it visible from other scripts
    private static GameManager _Instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();

            }
            return _Instance;
        }
    }
   

    
    void Awake()
    {
        _Instance = this;
    }

    public Text scrollingTextPrefab;
    public Transform levelNotification;
    public Transform xpNotification;

    public void addPlayerXP(int experience)
    {
        var localXP = PlayerPrefs.GetInt("playerXP");
        var localLevel = PlayerPrefs.GetInt("playerLevel");
        PlayerPrefs.SetInt("playerXP", localXP += experience);
        Text xpText = Instantiate(scrollingTextPrefab, xpNotification.transform);
        xpText.GetComponent<ScrollingText>().Initilize(10, transform.up, "+" + experience, 2);
        if (PlayerPrefs.GetInt("playerXP") > PlayerPrefs.GetInt("playerXPMax"))
        {
            print("LEVEL");
            PlayerPrefs.SetInt("playerLevel", localLevel += 1);
            PlayerPrefs.SetInt("playerXP", localXP -= 1000);

            Text levelText = Instantiate(scrollingTextPrefab, levelNotification.transform);
            levelText.GetComponent<ScrollingText>().Initilize(30, transform.up, "Level Up!", 2);
        }
    }

}


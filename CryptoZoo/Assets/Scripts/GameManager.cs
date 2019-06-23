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

    public List<GameObject> monsterList;
    public float[] localHunger;
    public float[] localBoredom;
    private float[] loadedHunger;
    private float[] loadedBoredom;

    public void Start()
    {
        monsterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("monster"));
        
        GetData();
    }

    public void FixedUpdate()
    {
        SetData();
    }

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
    public void GetData()
    {
        loadedHunger = SaveSystem.loadMonsters().hungerArray;
        loadedBoredom = SaveSystem.loadMonsters().boredomArray;

        for (int i = 0; i < monsterList.Count; i++)
        {
            print("Added Hunger to monster " + i);
            monsterList[i].GetComponent<MonsterData>().Hunger = loadedHunger[i];
        }
        for (int i = 0; i < monsterList.Count; i++)
        {
            print("Added Hunger to monster " + i);
            monsterList[i].GetComponent<MonsterData>().Boredom = loadedBoredom[i];
        }
    }

    public void SetData()
    {
        //setting length of array = length of list in GameManager
        localHunger = new float[monsterList.Count];
        localBoredom = new float[monsterList.Count];
        for (int i = 0; i < localHunger.Length; i++)
        {
            //setting array int values to = hunger in the same oder as the list
            localHunger[i] = monsterList[i].GetComponent<MonsterData>().Hunger;
            
        }
        for (int i = 0; i < localBoredom.Length; i++)
        {
            //setting array int values to = hunger in the same oder as the list
            localBoredom[i] = monsterList[i].GetComponent<MonsterData>().Boredom;

        }

        SaveSystem.SaveMonster(this);
    }
    

}


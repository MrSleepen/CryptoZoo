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

    public GameObject Monster1Prefab;
    public GameObject Monster2Prefab;

    public List<GameObject> monsterList;
    public int[] monsterNumValue;
    public float[] localHunger;
    public float[] localBoredom;
    public float[] localSize;
    public int[] loadedMonsterNumValue;
    private float[] loadedHunger;
    private float[] loadedBoredom;
    private float[] loadedSize;

    public void Start()
    {
        Spawn();
        monsterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("monster"));
        GetData();
    }

    public void FixedUpdate()
    {
        monsterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("monster"));
        SetData();
        SetMonsters();
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
        loadedSize = SaveSystem.loadMonsters().monsterSize;

        for (int i = 0; i < monsterList.Count; i++)
        {
            print("Added Hunger to monster " + i);
            monsterList[i].GetComponent<MonsterData>().Hunger = loadedHunger[i];
        }
        for (int i = 0; i < monsterList.Count; i++)
        {
            print("Added boredom to monster " + i);
            monsterList[i].GetComponent<MonsterData>().Boredom = loadedBoredom[i];
        }
        for (int i = 0; i < monsterList.Count; i++)
        {
            print("Added boredom to monster " + i);
            monsterList[i].GetComponent<MonsterData>().Size = loadedSize[i];
        }
    }

    public void SetData()
    {
        //setting length of array = length of list in GameManager
        localHunger = new float[monsterList.Count];
        localBoredom = new float[monsterList.Count];
        localSize = new float[monsterList.Count];
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
        for (int i = 0; i < localSize.Length; i++)
        {
            //setting array int values to = hunger in the same oder as the list
            localSize[i] = monsterList[i].GetComponent<MonsterData>().Size;

        }

        SaveSystem.SaveMonster(this);
    }

    public void SetMonsters()
    {
        
        monsterNumValue = new int[monsterList.Count];
        for(int i = 0; i < monsterList.Count; i++)
        {
            if(monsterList[i].gameObject.GetComponent<MonsterData>().monsterType == "Monster1")
            {
                monsterNumValue[i] = 1;
            }
            else if(monsterList[i].gameObject.GetComponent<MonsterData>().monsterType == "Monster2")
            {
                monsterNumValue[i] = 2;
            }
        }
        SaveSystem.SaveMonster(this);
    }

    public void Spawn()
    {
        loadedMonsterNumValue = SaveSystem.loadMonsters().monsterNumValue;
        for (int i = 0; i < loadedMonsterNumValue.Length; i++)
        {
            if (loadedMonsterNumValue[i] == 1)
            {
                var clone = Instantiate(Monster1Prefab);
                clone.name = "Monster1";
            }
            else if (loadedMonsterNumValue[i] == 2)
            {
                var clone = Instantiate(Monster2Prefab);
                clone.name = "Monster2";
            }
        }
    }
    

}


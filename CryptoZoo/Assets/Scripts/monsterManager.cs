using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterManager : MonoBehaviour {

    public GameObject Monster1Prefab;
    public GameObject Monster2Prefab;
    public int MonsterNumber = 1;
    // Use this for initialization

    void Update()
    {
        Debug.Log("dasdas");
    }

    public void Spawn()
    {
        GameManager gameManager = GameManager.Instance;
        for(int i = 0; i < gameManager.loadedMonsterNumValue.Length; i++)
        {
            if(gameManager.loadedMonsterNumValue[i] == 1)
            {
                var clone = Instantiate(Monster1Prefab);
                clone.name = "Monster1";
            }
            else if (gameManager.loadedMonsterNumValue[i] == 2)
            {
                var clone = Instantiate(Monster2Prefab);
                clone.name = "Monster2";
            }
        }
    }
    public void ChangeMonster()
    {
        if (MonsterNumber == 1)
        {
            MonsterNumber = 2;
        }
        else
        {
            MonsterNumber = 1;
        }
    }
}

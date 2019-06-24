using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripp : MonoBehaviour {

    public GameObject Monster1;
    public GameObject Monster2;
    public int MonsterNumber  = 1;
    // Use this for initialization

        void Update()
    {
        Debug.Log("dasdas");
    }


    public void Spawn()
    {
        if (MonsterNumber == 1)
        {
           Instantiate(Monster1);
        }
        

        if(MonsterNumber == 2 )
        {
            Instantiate(Monster2);
        }
            
    }
    public void ChangeMonster()
    {
        if(MonsterNumber == 1)
        {
            MonsterNumber = 2;
        }
        else
        {
            MonsterNumber = 1;
        }
    }
    }

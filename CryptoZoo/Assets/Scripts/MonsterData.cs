using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour {

    public int hunger;

	// Use this for initialization
	void Start () {
        print("Before save hunger: " + hunger);
        hunger = 10;
        SaveSystem.SaveMonster(this);
        print("Saving hunger at: " + hunger);
        hunger = 0;
        print("Before load hunger: " + hunger);
        MonsterSaves data = SaveSystem.loadMonsters();
        hunger = data.testhunger;
        print("After load hunger: " + hunger);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}

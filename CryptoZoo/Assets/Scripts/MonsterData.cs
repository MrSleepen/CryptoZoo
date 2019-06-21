using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{

    public bool JustBorn = false;
    private bool TimerTF = false;
    public int Hunger;
    public int Bordum;
    private int FedXP = 100;
    private int Happiness;

    void start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MonsterSaves data = SaveSystem.loadMonsters();

        Hunger = data.testhunger;
        Bordum = data.bordum;

        Debug.Log("Hunger is" + Hunger);
        Debug.Log("Bordum is" + Bordum);
        FedXP = PlayerPrefs.GetInt("playerXP");
        //if Monster has just been created, start with full hunger and toggle just born to false.
        if (JustBorn == true)
        {
            Hunger = 100;
            Bordum = 0;
            JustBorn = false;
            SaveSystem.SaveMonster(this);
        }
        //if hunger level is above 0 run coroutine to subract hunger. use time to determine the amount of time between subraction.
        while (Hunger >= 1 && TimerTF == false)
        {
            TimerTF = true;
            StartCoroutine(GettingHungry());
        }
        while (Bordum <= 99 && TimerTF == false)
        {
            TimerTF = true;
            StartCoroutine(GettingBored());
        }
    }

    public IEnumerator GettingHungry()
    {
        //Wait For time and subtract health.
        Hunger -= 1;
        SaveSystem.SaveMonster(this);
        yield return new WaitForSeconds(1);
        TimerTF = false;
    }
    public IEnumerator GettingBored()
    {
        //Wait For time and subtract health.
        Bordum += 1;
        SaveSystem.SaveMonster(this);
        yield return new WaitForSeconds(1);
        TimerTF = false;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {

        switch (collider.gameObject.name)
        {
            ///////////////////////FOOD ITEMS COLLISION MENU////////////////////////        
            case "TestFood":
                // Right Food Fed to This Creature + happiness + hunger + Player XP destroy Food
                if (this.gameObject.name == "Monster1")
                {
                    if (Hunger <= 90)
                    {
                        Happiness += 10;
                    }
                    Hunger = 100;
                    SaveSystem.SaveMonster(this);
                    Destroy(collider.gameObject);
                    PlayerPrefs.SetInt("playerXP", FedXP += 100);
                }

                else
                {
                    // Wrong Food Fed to This Creature - happiness destroy Food
                    Destroy(collider.gameObject);
                    Happiness -= 10;
                }

                break;

            case "AnotherFood":
                // Right Food Fed to This Creature + happiness + hunger + Player XP destroy Food
                if (this.gameObject.name == "Monster2")
                {
                    if (Hunger <= 90)
                    {
                        Happiness += 10;
                    }

                    Hunger = 100;
                    SaveSystem.SaveMonster(this);
                    Destroy(collider.gameObject);
                    PlayerPrefs.SetInt("playerXP", FedXP += 100);
                }

                else
                {
                    // Wrong Food Fed to This Creature - happiness destroy Food
                    Destroy(collider.gameObject);
                    Happiness -= 10;

                }

                break;


        }
    }
}

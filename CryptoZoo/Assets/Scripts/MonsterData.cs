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
        if (SaveSystem.loadMonsters() == null)
        {
            Debug.LogError("Creating Save");
            SaveSystem.SaveMonster(GameManager.Instance);
        }
        //MonsterSaves data = SaveSystem.loadMonsters();

        //Hunger = data.testhunger;
        //Bordum = data.bordum;

        Debug.Log("Hunger is" + Hunger);
        Debug.Log("Bordum is" + Bordum);
        FedXP = PlayerPrefs.GetInt("playerXP");
        //if Monster has just been created, start with full hunger and toggle just born to false.
        if (JustBorn == true)
        {
            Hunger = 100;
            Bordum = 0;
            SaveSystem.SaveMonster(GameManager.Instance);
            JustBorn = false;

        }
        //if hunger level is above 0 run coroutine to subract hunger. use time to determine the amount of time between subraction.
        if(TimerTF == false)
        {
            StartCoroutine(runTimedEvents());
        }
    }

    public IEnumerator runTimedEvents()
    {
        TimerTF = true;
        
        yield return new WaitForSeconds(1);
        if (Hunger >= 1)
        {
            Hunger -= 1;
            SaveSystem.SaveMonster(GameManager.Instance);
            TimerTF = false;
        }
        if (Bordum <= 99)
        {
            Bordum += 1;
            SaveSystem.SaveMonster(GameManager.Instance);
            TimerTF = false;
        }
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
                    SaveSystem.SaveMonster(GameManager.Instance);
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
                    SaveSystem.SaveMonster(GameManager.Instance);
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

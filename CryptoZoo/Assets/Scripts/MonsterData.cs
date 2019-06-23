﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterData : MonoBehaviour
{
    public bool JustBorn = false;
    public bool TimerTF = false;


    //UI Elements
    public GameObject CreatureattsMenu;
    public Slider Hungerslider;
    public Slider BoredumSlider;
    public Slider Happinessslider;



    //Monster Attributes
    private float Happiness;
    public float Hunger;
    public float Boredom;
    private float totHunger;
    private float totBoredom;
    private float NumOfAtts = 2;
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

        Debug.Log("Hunger is" + Hunger);
        Debug.Log("Bordum is" + Boredom);
        //if Monster has just been created, start with full hunger and toggle just born to false.
        if (JustBorn == true)
        {
            Hunger = 1f;
            Boredom = 1f;
            SaveSystem.SaveMonster(GameManager.Instance);
            JustBorn = false;
        }

        totHunger = Hunger / NumOfAtts;
        totBoredom = Boredom / NumOfAtts;
        Happiness = totBoredom + totHunger;
        Hungerslider.value = Hunger;
        BoredumSlider.value = Boredom;
        Happinessslider.value = Happiness;
       
        //if hunger level is above 0 run coroutine to subract hunger. use time to determine the amount of time between subraction.

        if (TimerTF == false)
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
        if (Boredom <= 99)
        {
            Boredom += 1;
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
                
                }
                else
                {
                    // Wrong Food Fed to This Creature - happiness destroy Food
                    Destroy(collider.gameObject);
                    Hunger -= .2f;
                    SaveSystem.SaveMonster(GameManager.Instance);
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
                }
                else
                {
                    // Wrong Food Fed to This Creature - happiness destroy Food
                    Destroy(collider.gameObject);
                    Hunger -= .2f;
                    SaveSystem.SaveMonster(GameManager.Instance);

                }

                break;


        }
    }
    public void PlayWith()
    {
        if(Boredom <= .85f) {
            Boredom = 1f;
        SaveSystem.SaveMonster(GameManager.Instance);
        }
        else if (Boredom > .85f)
        {
            Debug.Log("Baby Does Not want to play");
        }
    }
}

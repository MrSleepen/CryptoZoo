using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterData : MonoBehaviour
{

    public bool JustBorn = false;
    public bool TimerTF = false;
    public string monsterType;


    //UI Elements
    public GameObject Creature;
    public GameObject CreatureattsMenu;
    public Slider Hungerslider;
    public Slider BoredumSlider;
    public Slider Happinessslider;


    //Monster Attributes
    private float Happiness;
    public float Hunger;
    public float Boredom;
    public float GrowthRate = 2;
    public float Size = 1f;
    private float totHunger;
    private float totBoredom;
    private float NumOfAtts = 2;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GrowthRate);
       
        if (JustBorn == true)
        {
            Hunger = 1f;
            Boredom = 1f;
            SaveSystem.SaveMonster(GameManager.Instance);
            JustBorn = false;

        }

        //Hunger = data.testhunger;
        //Boredom = data.bordum;
        totHunger = Hunger / NumOfAtts;
        totBoredom = Boredom / NumOfAtts;
        Happiness = totBoredom + totHunger;
        Hungerslider.value = Hunger;
        BoredumSlider.value = Boredom;
        Happinessslider.value = Happiness;
        GrowthRate = Happiness;


        Vector3 theScale = transform.localScale;
        theScale.y = Size;
        theScale.x = Size;
        transform.localScale = theScale;

        //This obsurd check can be replaced by name when proper monster names are given such as "if(gameObject.name == "Zombie")
        if (gameObject.name == "Monster1")
        {
            monsterType = "Monster1";
            print("Saving monster 1");
        }
        else if (gameObject.name == "Monster2")
        {
            monsterType = "Monster2";
            print("Saving monster 2");
        }

 

        if (TimerTF == false)
        {
            StartCoroutine(runTimedEvents());
        }


        

    }
    // Run Time Events
    public IEnumerator runTimedEvents()
    {
        TimerTF = true;

        yield return new WaitForSeconds(1);
        if (Hunger >= .01f)
        {
            Hunger -= .01f;
            SaveSystem.SaveMonster(GameManager.Instance);
            TimerTF = false;
        }
        else
        {
            Hunger = 0;
        }

        if (Boredom >= .01f)
        {
            Boredom -= .01f;
            SaveSystem.SaveMonster(GameManager.Instance);
            TimerTF = false;
        }
        else
        {
            Boredom = 0;
        }
        if(Size <= 1f)
        {
            Size += GrowthRate /100;
        }
        else
        {
            Size = 1;
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

                    Hunger = 1;
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

                    Hunger = 1;
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
        if (Boredom <= .85f)
        {
            Boredom = 1f;
            SaveSystem.SaveMonster(GameManager.Instance);
        }
        else if (Boredom > .85f)
        {
            Debug.Log("Baby Does Not want to play");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterData : MonoBehaviour
{

    public bool JustBorn = false;
    public bool TimerTF = false;
    public string monsterType;
    private bool fullGrownchecked;
    public float timer;


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
    public float Size = .01f;
    private float totHunger;
    private float totBoredom;
    private float NumOfAtts = 2;
    private float TestFloat;
    void Start()
    {
        //timer = 300;
        //timer -= TimeMaster.instance.CheckDate();
    }

    // Update is called once per frame
    void Update()
    {
Debug.Log(timer);

        //timer -= Time.deltaTime;
        //TimeMaster.instance.SaveDate();


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
        if(fullGrownchecked == false)
        {
            GrowthRate = Happiness;
        }
        


        Vector3 theScale = transform.localScale;
        theScale.y = Size;
        theScale.x = Size;
        transform.localScale = theScale;

        //This obsurd check can be replaced by name when proper monster names are given such as "if(gameObject.name == "Zombie")
        if (gameObject.name == "Monster1")
        {
            monsterType = "Monster1";
           // print("Saving monster 1");
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



        //Hunger Calculations
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


        // Bordom Calculations
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

        //Growth Rate and max Size
         if(Size <= .33f && Size >=0)
        {
             Size += GrowthRate /100;
            //Debug.Log("Stage1");
        }
         else if (Size <= .66f && Size >= .33f)
        {
             Size += GrowthRate / 150;
            //Debug.Log("Stage2");
        }
         else if (Size <= 1f && Size >= .66f)
        {
             Size += GrowthRate / 250;
            //Debug.Log("Stage3");
        }
        else
        {
            TestFloat = Size = 1;
            if(fullGrownchecked == false)
            {
                GameManager.Instance.addPlayerXP(500);
                fullGrownchecked = true;
                GrowthRate = 0;
            }
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


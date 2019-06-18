using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour {

    public bool JustBorn = false;
    private bool TimerTF = false;
    private int HungerLocal;
    private int FedXP = 100;
    private int Happiness;
    

    // Update is called once per frame
    void Update () {
        HungerLocal = PlayerPrefs.GetInt("HungerLevel");

        Debug.Log(Happiness);
        FedXP = PlayerPrefs.GetInt("playerXP");

        //Debug.Log(PlayerPrefs.GetInt("playerXP"));

        if (JustBorn == true)
        {
            PlayerPrefs.SetInt("HungerLevel", 100);
            JustBorn = false;
        }

        while(PlayerPrefs.GetInt("HungerLevel")>=0 && TimerTF == false){
            TimerTF = true;
            StartCoroutine(GettingHungry());
        }
	}

    public IEnumerator GettingHungry()
    {
        
        PlayerPrefs.SetInt("HungerLevel", HungerLocal -=1);
        yield return new WaitForSeconds(1);
        TimerTF = false;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {

        switch (collider.gameObject.name)
        {
            

            case "TestFood":

                if (this.gameObject.name == "Monster1")
                {
                    if (HungerLocal <=90)
                    {
                        Happiness += 10;
                    }
                    
                    PlayerPrefs.SetInt("HungerLevel", 100);
                    Destroy(collider.gameObject);
                    PlayerPrefs.SetInt("playerXP", FedXP += 100);
                    
                }
                else {
                   
                    Destroy(collider.gameObject);
                    //Happiness Down 
                }
               
                break;
                


            case "AnotherFood":
                if (this.gameObject.name == "Monster2")
                {
                      if (HungerLocal <= 90)
                    {
                        Happiness += 10;
                    }
                    
                    PlayerPrefs.SetInt("HungerLevel", 100);
                    Destroy(collider.gameObject);
                    PlayerPrefs.SetInt("playerXP", FedXP += 100);
                }
                else
                {
                   
                    Destroy(collider.gameObject);
                    //Happiness Down 
                }

                break;


        }
    }
    }

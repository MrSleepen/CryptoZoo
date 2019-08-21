using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPost : MonoBehaviour
{

    public float One;
    public float Two;
    public float Three;
    public int RandomNumber;
    public GameObject MissionOne;
    public GameObject MissionTwo;
    public GameObject MissionThree;
    public GameObject ButtonOneGO;
    public GameObject ButtonTwoGO;
    public GameObject ButtonThreeGO;
    public GameObject[] Missions;

    //public Sprite ItemUnlocked2;
    //public Sprite ItemUnlocked3;
    public int ResetCounter;
   
    public bool Playing;


    public void reentermp()
    {
        StartCoroutine(ResetTimer());
    }

    // Update is called once per frame
    void Update()
    {
        #region RandomNumbers
        if (ResetCounter <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                RandomNumber = Random.Range(1, Missions.Length); Debug.Log(RandomNumber);
                if (i == 1)
                {
                    One = RandomNumber;
                }
                if (i == 2)
                {
                    Two = RandomNumber;
                }
                if (i == 3)
                {
                    Three = RandomNumber;
                }
            }

       
        }



        if (ResetCounter >= 0 && Playing != true)
        {
            Playing = true;
            StartCoroutine(ResetTimer());

        }

        #endregion
        MissionSelector();
    }

    void MissionSelector()
    {
        #region ItemOne
        if (One == 1)
        {
           

        }
        if (One == 2)
        {
            
        }
        if (One == 3)
        {
           
        }
        #endregion


        #region ItemTwo
        if (Two == 1)
        {
           
        }
        if (Two == 2)
        {
          
        }
        if (Two == 3)
        {
           
        }
        #endregion


        #region ItemThree
        if (Three == 1)
        {
          
        }
        if (Three == 2)
        {
           
        }
        if (Three == 3)
        {
          
        }
        #endregion
    }

    public void ButtonOne()
    {
        MissionOne.SetActive(true);
        MissionTwo.SetActive(false);
        MissionThree.SetActive(false);


    }
    public void ButtonTwo()
    {
        MissionOne.SetActive(false);
        MissionTwo.SetActive(true);
        MissionThree.SetActive(false);

    }
    public void ButtonThree()
    {
        MissionOne.SetActive(false);
        MissionTwo.SetActive(false);
        MissionThree.SetActive(true);
    }
    IEnumerator ResetTimer()
    {

        yield return new WaitForSeconds(1);
        ResetCounter -= 1;
        Playing = false;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraveStones : MonoBehaviour
{

    public float ItemOne;
    public float ItemTwo;
    public float ItemThree;
    public int RandomNumber;
    public GameObject GraveOne;
    public GameObject GraveTwo;
    public GameObject GraveThree;
    public GameObject ButtonOneGO;
    public GameObject ButtonTwoGO;
    public GameObject ButtonThreeGO;

    //public Sprite ItemUnlocked2;
    //public Sprite ItemUnlocked3;
    public int ResetCounter;
    public Sprite[] ItemList;
    public bool Playing;
    

    public void reenter()
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
                RandomNumber = Random.Range(1, ItemList.Length); Debug.Log(RandomNumber);
            if (i == 1)
            {
                ItemOne = RandomNumber;
            }
            if (i == 2)
                {
                ItemTwo = RandomNumber;
                }
            if (i == 3)
                {
                ItemThree = RandomNumber;
                }
            }

            GraveOne.SetActive(false);
            GraveTwo.SetActive(false);
            GraveThree.SetActive(false);
            ButtonOneGO.SetActive(true);
            ButtonTwoGO.SetActive(true);
            ButtonThreeGO.SetActive(true);
            ResetCounter = 100;
            

        }
    

        
        if(ResetCounter >= 0 && Playing != true)
        {
            Playing = true;
            StartCoroutine(ResetTimer());
           
        }

        #endregion
        ItemSelector();
    }

    void ItemSelector()
    {
        #region ItemOne
        if (ItemOne == 1)
        {
            //GraveOne = ItemList[1] ;
            GraveOne.GetComponent<Image>().sprite = ItemList[1];

        }
        if (ItemOne == 2)
        {
            //GraveOne = ItemList[2];
            GraveOne.GetComponent<Image>().sprite = ItemList[2];
        }
        if (ItemOne == 3)
        {
            //GraveOne = ItemList[3];
            GraveOne.GetComponent<Image>().sprite = ItemList[3];
        }
        #endregion


        #region ItemTwo
        if (ItemTwo == 1)
        {
            GraveTwo.GetComponent<Image>().sprite = ItemList[1];
        }
        if (ItemTwo == 2)
        {
            GraveTwo.GetComponent<Image>().sprite = ItemList[2];
        }
        if (ItemTwo == 3)
        {
            GraveTwo.GetComponent<Image>().sprite = ItemList[3];
        }
        #endregion


        #region ItemThree
        if (ItemThree == 1)
        {
            GraveThree.GetComponent<Image>().sprite = ItemList[1];
        }
        if (ItemThree == 2)
        {
            GraveThree.GetComponent<Image>().sprite = ItemList[2];
        }
        if (ItemThree == 3)
        {
            GraveThree.GetComponent<Image>().sprite = ItemList[3];
        }
        #endregion
    }

    public void ButtonOne()
    {
        GraveOne.SetActive(true);
        GraveTwo.SetActive(false);
        GraveThree.SetActive(false);
        ButtonOneGO.SetActive(false);
        ButtonTwoGO.SetActive(false);
        ButtonThreeGO.SetActive(false);


    }
    public void ButtonTwo()
    {
        GraveOne.SetActive(false);
        GraveTwo.SetActive(true);
        GraveThree.SetActive(false);
        ButtonOneGO.SetActive(false);
        ButtonTwoGO.SetActive(false);
        ButtonThreeGO.SetActive(false);

    }
    public void ButtonThree()
    {
        GraveOne.SetActive(false);
        GraveTwo.SetActive(false);
        GraveThree.SetActive(true);
        ButtonOneGO.SetActive(false);
        ButtonTwoGO.SetActive(false);
        ButtonThreeGO.SetActive(false);
    }
    IEnumerator ResetTimer()
    {
        
        yield return new WaitForSeconds(1);
        ResetCounter -= 1;
        Playing = false;

    }
}


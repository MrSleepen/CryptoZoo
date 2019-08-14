using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    public List<string> itemList;
    public List<string> partsList;

    public int currency;

    public GameObject Parts;
    public GameObject Items;
    public GameObject Market;
    public GameObject Inventory;

    public Text[] invItems;
    public Text[] invParts;
    

	// Use this for initialization
	void Start () {
        Parts.SetActive(false);
        Items.SetActive(false);
        Market.SetActive(false);
        Inventory.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        SortInv();
	}

    public void AddItemToInv(string itemToAdd, string partOrItem)
    {
       if(partOrItem == "part")
       {
           partsList.Add(itemToAdd);
       }
       else if(partOrItem == "item")
       {
           itemList.Add(itemToAdd);
       }
       else
       {
           Debug.LogError("Cannot add " + itemToAdd + " to inventory. Not specified if part or item");
       }
    }

    private void SortInv()
    {
        for(int i = 0; i < invParts.Length; i++)
        {
            invParts[i].text = "You do not have anything in this inventory slot";
        }
        for (int i = 0; i < partsList.Count; i++)
        {
            invParts[i].text = partsList[i];
        }
    }
    
    public void BuildMonster()
    {
        if(partsList.Count == 3)
        {
            //CHANGE WHEN MONSTERS ACTUALLY REQUIRE CERTAIN PARTS. YOU LOSE ALL PARTS WHEN BUILDING
            Debug.Log("BUILD MONSTER THING");
            partsList.Clear();
        }
    }
    public void ShowItems()
    {
        Parts.SetActive(false);
        Items.SetActive(true);
    }
    public void ShowParts()
    {
        Parts.SetActive(true);
        Items.SetActive(false);
    }
    public void ShowMarket()
    {
        Market.SetActive(true);
        Parts.SetActive(false);
        Items.SetActive(false);
        Inventory.SetActive(false);
    }
    public void ShowInventory()
    {
        Market.SetActive(false);
        Inventory.SetActive(true);
    }

    public void AddCurrency(int currencyToAdd)
    {
        currency += currencyToAdd;
    }
}

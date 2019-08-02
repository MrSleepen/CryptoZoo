using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public List<string> invItem;

    public int currency;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItemToInv(string itemToAdd)
    {
        invItem.Add(itemToAdd);
    }

    public void AddCurrency(int currencyToAdd)
    {
        currency += currencyToAdd;
    }
}

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

    void AddItemToInv(string itemToAdd)
    {
        invItem.Add(itemToAdd);
    }

    void AddCurrency()
    {
        currency += 100;
    }
}

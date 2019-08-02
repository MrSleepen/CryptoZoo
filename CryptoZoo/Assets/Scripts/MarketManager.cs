using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour {
    
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text currencyText;

    private string Item1 = "finger";
    private string Item2 = "horn";
    private string Item3 = "wing";

    private int item1Cost = 50;
    private int item2Cost = 100;
    private int item3Cost = 500;

    private InventoryManager _Inventory;

    // Use this for initialization
    void Start () {
        _Inventory = gameObject.GetComponent<InventoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
        currencyText.text = _Inventory.currency.ToString();
	}

    public void buyItem1()
    {
        if(_Inventory.currency >= item1Cost && button1Text.text != "SOLD OUT")
        {
            _Inventory.currency -= item1Cost;
            _Inventory.AddItemToInv(Item1);
            button1Text.text = "SOLD OUT";
        }
    }
    public void buyItem2()
    {
        if (_Inventory.currency >= item2Cost && button2Text.text != "SOLD OUT")
        {
            _Inventory.currency -= item2Cost;
            _Inventory.AddItemToInv(Item2);
            button2Text.text = "SOLD OUT";
        }
    }
    public void buyItem3()
    {
        if (_Inventory.currency >= item3Cost && button3Text.text != "SOLD OUT")
        {
            _Inventory.currency -= item3Cost;
            _Inventory.AddItemToInv(Item3);
            button3Text.text = "SOLD OUT";
        }
    }
    public void AddCurreny()
    {
        _Inventory.AddCurrency(100);
    }
}

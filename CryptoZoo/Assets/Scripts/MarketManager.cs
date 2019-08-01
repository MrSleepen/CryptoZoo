using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour {
    
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    private string Item1 = "finger";
    private string Item2 = "horn";
    private string Item3 = "wing";

    private int item1Cost = 50;
    private int item2Cost = 100;
    private int item3Cost = 500;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void buyItem1()
    {

        button1Text.text = "SOLD OUT";
    }
    void buyItem2()
    {
        button2Text.text = "SOLD OUT";
    }
    void buyItem3()
    {
        button3Text.text = "SOLD OUT";
    }
}

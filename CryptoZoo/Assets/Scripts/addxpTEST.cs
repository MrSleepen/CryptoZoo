using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addxpTEST : MonoBehaviour {

    public bool addXP;
    public int xpNeeded;
    private int localXP;
    public int Remainder;
    
    private int localLevel = 1;

    public Slider xpBar;
    public Text xpText;
    public Text levelText;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(addXP == false)
        {
            addXP = true;
            StartCoroutine(addxp());
        }
      
        //Unlockable per player level
        if (PlayerPrefs.GetInt("playerLevel")>= 10)
        {
            Debug.Log("NewAreas");
        }
        if (PlayerPrefs.GetInt("playerLevel") >= 15)
        {
            Debug.Log("MoreCariable");
        }
        if (PlayerPrefs.GetInt("playerLevel") >= 20)
        {
            Debug.Log("MoreActiveMission");
        }
        UpdateLevel();
    }
    public void UpdateLevel()
    {
        //Update Player level and needed xp to get next level.
        xpNeeded = localLevel * localLevel * 500;
        PlayerPrefs.SetInt("playerXPMax", xpNeeded);
    }

    IEnumerator addxp()
    {
        //Remainder = xpNeeded % localXP;
        GameManager.Instance.addPlayerXP(345);

        localXP = PlayerPrefs.GetInt("playerXP");
        localLevel = PlayerPrefs.GetInt("playerLevel");
       
        xpBar.value = localXP;
        xpText.text = localXP + " /" + xpNeeded;
        levelText.text = localLevel.ToString();
        yield return new WaitForSeconds(3f);
        addXP = false;
         Debug.Log(Remainder);
    }

}

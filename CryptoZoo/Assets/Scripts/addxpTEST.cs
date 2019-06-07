using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addxpTEST : MonoBehaviour {

    public bool addXP;

    private int localXP;
    private int localLevel;

    public Slider xpBar;
    public Text xpText;
    public Text levelText;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("playerLevel", 0);
        PlayerPrefs.SetInt("playerXP", 0);
        PlayerPrefs.SetInt("playerXPMax", 1000);
    }
	
	// Update is called once per frame
	void Update () {
		if(addXP == false)
        {
            addXP = true;
            StartCoroutine(addxp());
        }
	}

    IEnumerator addxp()
    {
        GameManager.Instance.addPlayerXP(345);

        localXP = PlayerPrefs.GetInt("playerXP");
        localLevel = PlayerPrefs.GetInt("playerLevel");

        xpBar.value = localXP;
        xpText.text = localXP + "/1000";
        levelText.text = localLevel.ToString();
        yield return new WaitForSeconds(3f);
        addXP = false;
    }
}

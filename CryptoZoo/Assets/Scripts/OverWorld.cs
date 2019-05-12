using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorld : MonoBehaviour {
    public GameObject Lab;
    public GameObject Market;
    public GameObject MissionBoard;
    public GameObject Arena;
    public GameObject GraveYard;
    public GameObject Overworld;

    public void LabLoad()
    {
        Lab.SetActive(true);
        Overworld.SetActive(false);
    }
    public void MarketLoad()
    {
        Market.SetActive(true);
        Overworld.SetActive(false);
    }
    public void MissionBoardLoad()
    {
        MissionBoard.SetActive(true);
        Overworld.SetActive(false);
    }
    public void ArenaLoad()
    {
        Arena.SetActive(true);
        Overworld.SetActive(false);
    }
    public void GraveYardLoad()
    {
        GraveYard.SetActive(true);
        Overworld.SetActive(false);
    }
  
    // Use this for initialization

}

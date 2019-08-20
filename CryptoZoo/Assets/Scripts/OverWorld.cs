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
    public GameObject Crib;
    public GameObject WorkBench;
    public GraveStones SET;

  //Function to open Lab called from lab button
    public void LabLoad()
    {
        Lab.SetActive(true);
        Overworld.SetActive(false);
    }
    //function to open Market called from market button
    public void MarketLoad()
    {
        Market.SetActive(true);
        Overworld.SetActive(false);
    }
    //Function to open Mission Board From Button
    public void MissionBoardLoad()
    {
        MissionBoard.SetActive(true);
        Overworld.SetActive(false);
    }
    //function to open Arena called from button
    public void ArenaLoad()
    {
        Arena.SetActive(true);
        Overworld.SetActive(false);
    }
    //function to open GraveYard called from button
    public void GraveYardLoad()
    {
        GraveYard.SetActive(true);
        Overworld.SetActive(false);
        SET.reenter();
    }

    // Use this for initialization
    public void CribLoad()
    {
        Crib.SetActive(true);
        Lab.SetActive(false);
    }
    public void WorkBenchLoad()
    {
        WorkBench.SetActive(true);
        Lab.SetActive(false);
    }

    public void BackToOverWorld()
    {

        WorkBench.SetActive(false);
        Lab.SetActive(false);
        Crib.SetActive(false);
        GraveYard.SetActive(false);
        Arena.SetActive(false);
        MissionBoard.SetActive(false);
        Market.SetActive(false);
        Lab.SetActive(false);
        Overworld.SetActive(true);
    }
    public void BackToLab()
    {

        WorkBench.SetActive(false);
        Lab.SetActive(false);
        Crib.SetActive(false);
        GraveYard.SetActive(false);
        Arena.SetActive(false);
        MissionBoard.SetActive(false);
        Market.SetActive(false);
        Lab.SetActive(true);
        Overworld.SetActive(false);
    }
}

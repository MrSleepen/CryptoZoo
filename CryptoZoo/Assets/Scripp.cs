using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripp : MonoBehaviour {

    public GameObject Monsters;
    // Use this for initialization
    public void Spawn()
    {
        Instantiate(Monsters);
    }
}

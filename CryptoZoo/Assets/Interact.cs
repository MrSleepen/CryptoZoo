using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject AttributePanel;
    public bool Active = false;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Test");
            if (Active == false)
            {
                Active = true;
                
            }
            else {
                Active = false;
               
            }
        }
    }
    void Update()
    {
        if (Active == false)
        {
           
            AttributePanel.SetActive(false);
        }
        else
        {
            
            AttributePanel.SetActive(true);
        }
    }
}

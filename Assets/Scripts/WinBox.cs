using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        
        if(other.tag == "Player"){

            Debug.Log("OnTriggerEnter = Player");

            LevelManager.Instance.Win();
        }
    }
}
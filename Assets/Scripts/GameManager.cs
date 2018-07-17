using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance { 

      get {    
           if (instance == null) {    
                instance = FindObjectOfType (typeof(GameManager)) as GameManager;    
               if (instance == null) {    
                        GameObject obj = new GameObject();      
                        instance = (GameManager)obj.AddComponent(typeof(GameManager));    
                }
            }
            return instance;
        }    
    }

    public int Currency = 0;


	// Use this for initialization
	void Awake() {

        instance = this;
        DontDestroyOnLoad(gameObject);
	}

    public void Save(){

        PlayerPrefs.SetInt("Currency", Currency);


    }

}

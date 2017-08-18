using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour {
    public GameObject Menu;
    bool pause;
	// Use this for initialization
	void Start () {
        pause = false;
	}

    public void StopBtn()
    {
        if (pause)
        {
            pause = false;
            Menu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pause = true;
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void GoStageMenu()
    {
        Application.LoadLevel("StageMenu");
    }
}

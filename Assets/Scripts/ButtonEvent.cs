using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    static SceneData sceneData = new SceneData(); 
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                switch(hit.transform.gameObject.name)
                {
                    case "SlotPanel":

                        break;
                }
            }
            */
        }

    }

    public void Stage1Btn()
    {
        sceneData.setStageLev(1);
        Invoke("StartStage1", .1f);
    }
    public void Stage2Btn()
    {
        sceneData.setStageLev(2);
        Invoke("StartStage1", .1f);
    }
    public void Stage3Btn()
    {
        sceneData.setStageLev(3);
        Invoke("StartStage1", .1f);
    }
    public void Stage4Btn()
    {
        Invoke("StartStage1", .1f);
    }
    public void Stage5Btn()
    {
        Invoke("StartStage1", .1f);
    }
    public void Stage6Btn()
    {
        Invoke("StartStage1", .1f);
    }
    void StartStage1()
    {
        Application.LoadLevel("InPlay");
    }
    void StartStage2()
    {
        Application.LoadLevel("InPlay");
    }
    void StartStage3()
    {
        Application.LoadLevel("InPlay");
    }
    void StartStage4()
    {
        Application.LoadLevel("InPlay");
    }
    void StartStage5()
    {
        Application.LoadLevel("InPlay");
    }
    void StartStage6()
    {
        Application.LoadLevel("InPlay");
    }
}

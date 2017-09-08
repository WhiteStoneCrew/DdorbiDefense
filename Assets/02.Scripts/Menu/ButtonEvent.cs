using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour {
    static SceneData sceneData = new SceneData(); 
    // Update is called once per frame
    void Update () {

    }

    public void Stage1Btn()
    {
        sceneData.setStageLev(1);
        Application.LoadLevel("InPlay");
    }
    public void Stage2Btn()
    {
        sceneData.setStageLev(2);
        Application.LoadLevel("InPlay");
    }
    public void Stage3Btn()
    {
        sceneData.setStageLev(3);
        Application.LoadLevel("InPlay");
    }
    public void Stage4Btn()
    {
        sceneData.setStageLev(4);
        Application.LoadLevel("InPlay");
    }
    public void Stage5Btn()
    {
        sceneData.setStageLev(5);
        Application.LoadLevel("InPlay");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
    //public static List<float> DataBundle = new List<float>(4);
    public static int stageLev;
    public static int EnemyCount;
    public static float EnemysDurable;


    public void setStageLev(int value)
    {
        /*
        switch (value)
        {
            case 1:
                stageLev = value;
                break;
            case 2:
                stageLev = value;
                break;
            case 3:
                stageLev = value;
                break;
            case 4:
                stageLev = value;
                break;

        }*/
        stageLev = value;
    }
    
}

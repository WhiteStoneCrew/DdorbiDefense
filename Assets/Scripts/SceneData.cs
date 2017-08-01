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
        switch (value)
        {
            case 1:
                stageLev = value;
                EnemyCount = 10;
                EnemysDurable = 2;
                break;
            case 2:
                stageLev = value;
                EnemyCount = 15;
                EnemysDurable = 2;
                break;
            case 3:
                stageLev = value;
                EnemyCount = 30;
                EnemysDurable = 2;
                break;

        }
        /*
        DataBundle[0] = stageLev;
        DataBundle[1] = EnemyCount;
        DataBundle[2] = EnemysDurable;
        */
    }
    
}

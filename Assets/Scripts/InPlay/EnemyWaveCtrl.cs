using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 웨이브 생성시 웨이브 파라미터가 저장되는 클래스이다.
 */
public class EnemyWaveCtrl : MonoBehaviour {
    private bool waveOn;
    private float speed;
    private float maxhp;
    private float durable;
    private int gold;//처치시 플레이어가 얻는 골드
    private int exp;//처치시 플에이어가 얻는 경험치
    public GameObject spawnArea;

    public bool WaveOn
    {
        get { return waveOn; }
        set { waveOn = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    
    public float MaxHP
    {
        get { return maxhp; }
        set { maxhp = value; }
    }
    public float Durable
    {
        get { return durable; }
        set { durable = value; }
    }

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public int Exp
    {
        get { return exp; }
        set { exp = value; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

}

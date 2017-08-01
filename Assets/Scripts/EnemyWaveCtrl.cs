using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 웨이브 생성시 웨이브 파라미터가 저장되는 클래스이다.
 */
public class EnemyWaveCtrl : MonoBehaviour {
    private float speed;
    private float durable;
    private float hp;
    private string name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public float Durable
    {
        get { return durable; }
        set { durable = value; }
    }
}

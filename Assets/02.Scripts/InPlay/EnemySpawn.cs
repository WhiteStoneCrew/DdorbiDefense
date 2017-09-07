using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    bool spOn;
    public int EnemyCount;
    public int SpawnCount;
    float intervalTime;

    // Use this for initialization
    void Start () {
        spOn = false;
        SpawnCount = 0;
        EnemyCount = 10;
        intervalTime = 3.0f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (spOn)
        {
            if (SpawnCount == EnemyCount)
            {
                spOn = false;
                SpawnCount = 0;
                GameObject WaveCtrl = GameObject.Find("WaveCTRL");
                WaveCtrl.GetComponent<EnemyWaveCtrl>().WaveOn = false;//웨이브 종료도 알린다.
            }
            else
            {
                Transform Enemy = (Transform)Instantiate(enemy.transform, transform.position, transform.rotation);
                spOn = false;
                SpawnCount++;
                Invoke("Speed", intervalTime);
            }
        }
	}

    public void SpawnStart(GameObject Obj, int Count, float IntervalTime)//추가할 것: 스폰 시킬 적군transform을 받는다.(transfrom enemy,float speed,float durable)
    {
        enemy = Obj;//스폰시킬 적군 대입
        spOn = true;//적군생성 시작
        EnemyCount = Count;//리스폰 카운트
        intervalTime = IntervalTime;
    }
    void Speed()
    {
        spOn = true;
    }
}

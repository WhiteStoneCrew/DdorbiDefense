using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    bool spOn;
    public int EnemyCount;
    int SpawnCount;

	// Use this for initialization
	void Start () {
        spOn = false;
        SpawnCount = 0;
        EnemyCount = 10;
	}
	
	// Update is called once per frame
	void Update () {

        if (spOn && (SpawnCount < EnemyCount))
        {
            Transform Enemy = (Transform)Instantiate(enemy.transform, transform.position, transform.rotation);
            SpawnCount++;
            spOn = false;

            if(SpawnCount == EnemyCount)//요구되는 적군을 모두 생성했을 때
            {
                SpawnCount = 0;
                spOn = false;
            }
            else Invoke("Speed", 1.0f);

        }
	}

    public void SpawnStart(GameObject Obj, int Count)//추가할 것: 스폰 시킬 적군transform을 받는다.(transfrom enemy,float speed,float durable)
    {
        enemy = Obj;//스폰시킬 적군 대입
        spOn = true;//적군생성 시작
        EnemyCount = Count;//리스폰 카운트
    }
    void Speed()
    {
        spOn = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlayManager : MonoBehaviour {
    
    int stageLev;
    int EnemyCount;
    float EnemysDurable;
    string EnemyName;

    public GameObject spawnArea;
    // Use this for initialization
    void Start () {
        stageLev = SceneData.stageLev;
        EnemyCount = SceneData.EnemyCount;
        EnemysDurable = SceneData.EnemysDurable;
        
        //스위치로 스테이지별로 호출하는 메소드가 다르게 한다.
        switch (stageLev)
        {
            case 1:
                Stage1();

                break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: break;
            case 7: break;
            case 8: break;
            case 9: break;
            case 10: break;
            case 11: break;
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Stage1()//각 스테이지 별로 만든다.
    {
        print("스테이지 단계 : " + stageLev);
        //웨이브 호출
        StartCoroutine(Wave(Resources.Load("Pref/Enemy", typeof(GameObject)) as GameObject, 2.0f, 1.0f, 10.0f, 15, 5));
        StartCoroutine(Wave(Resources.Load("Pref/Enemy", typeof(GameObject)) as GameObject, 2.0f, 1.0f, 10.0f, 15, 15));
        StartCoroutine(Wave(Resources.Load("Pref/Enemy", typeof(GameObject)) as GameObject, 2.0f, 1.0f, 10.0f, 15, 35));
    }
    

    IEnumerator Wave(GameObject obj, float Speed, float Durable, float HP, int Count, int Time)
    {
        yield return new WaitForSeconds(Time); //Time만큼의 시간 후 에 웨이브 생성
        //웨이브는 (enemy객체, 속도, 방어, 체력, 객체수)을 파라미터로 받고
        //받은 파라미터대로 Enemy객체의 정보를 수정하여 객체수 만큼 Spawn한다.
        obj.GetComponent<EnemyWaveCtrl>().Speed = Speed;
        obj.GetComponent<EnemyWaveCtrl>().Durable = Durable;
        obj.GetComponent<EnemyWaveCtrl>().HP = HP;
        //EnemySpqwn에 Count만큼 생성하도록 호출
        spawnArea.GetComponent<EnemySpawn>().SpawnStart(obj, Count);
    }

}

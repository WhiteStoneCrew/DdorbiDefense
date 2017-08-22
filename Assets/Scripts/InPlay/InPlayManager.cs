using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlayManager : MonoBehaviour {
    
    int stageLev;
    int EnemyCount;
    float EnemysDurable;
    string EnemyName;

    public GameObject spawnArea;
    public GameObject WaveCTRL;
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
            case 2:
                Stage2();
                break;
            case 3:
                Stage3();
                break;
            case 4:
                Stage4();
                break;
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
        /*
        GameObject obj = Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject;
        obj.GetComponent<EnemyWaveCtrl>().WaveSpawn(5.0f, 1.0f, 10.0f, 8, 3.0f, 5); // 웨이브 호출
        obj.GetComponent<EnemyWaveCtrl>().WaveSpawn(5.0f, 1.0f, 10.0f, 10, 3.0f, 45); // 웨이브 호출
        obj.GetComponent<EnemyWaveCtrl>().WaveSpawn(6.5f, 1.0f, 10.0f, 10, 2.5f, 85); // 웨이브 호출
        */
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject, 1.0f, 1.0f, 10.0f, 3, 5, 8, 5.0f, 5));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject, 1.2f, 1.0f, 10.0f, 3, 6, 10, 5.0f, 55));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject, 1.4f, 1.0f, 10.0f, 3, 6, 10, 5.5f, 105));
    }
    void Stage2()
    {
        print("스테이지 단계 : " + stageLev);
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Pupalbot", typeof(GameObject)) as GameObject, 0.8f, 2.0f, 100.0f, 12, 12, 5, 6.0f, 5));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Pupalbot", typeof(GameObject)) as GameObject, 1.0f, 2.0f, 100.0f, 12, 12, 8, 6.0f, 55));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Pupalbot", typeof(GameObject)) as GameObject, 1.2f, 2.5f, 110.0f, 13, 13, 12, 6.0f, 105));
    }
    void Stage3()
    {
        print("스테이지 단계 : " + stageLev);
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject, 1.5f, 2.0f, 10.0f, 3, 5, 10, 4.5f, 5));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject, 1.7f, 1.0f, 15.0f, 5, 7, 13, 5.0f, 55));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Wormbot", typeof(GameObject)) as GameObject, 1.7f, 1.5f, 15.0f, 7, 10, 17, 4.0f, 105));
    }
    void Stage4()
    {
        print("스테이지 단계 : " + stageLev);
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Android", typeof(GameObject)) as GameObject, 1.1f, 4.0f, 25.0f, 30, 50, 5, 5.0f, 5));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Android", typeof(GameObject)) as GameObject, 1.3f, 4.0f, 25.0f, 30, 50, 7, 5.0f, 55));
        StartCoroutine(Wave(Resources.Load("Pref/Enemys/Enemy_Android", typeof(GameObject)) as GameObject, 1.5f, 4.0f, 25.0f, 30, 50, 8, 5.5f, 105));
    }

    //게임오브젝트, 이동속도, 내구력, HP, 골드, 경험치, 적군 수, 간격 시간, 웨이브 발생 시간
    IEnumerator Wave(GameObject obj, float Speed, float Durable, float MAXHP, int Gold, int Exp , int Count, float IntervalTime, int Time)
    {
        //Time만큼의 시간 후 에 웨이브 생성
        //웨이브는 (enemy객체, 속도, 방어, 체력, 객체수)을 파라미터로 받고
        //받은 파라미터대로 Enemy객체의 정보를 수정하여 객체수 만큼 Spawn한다.
        //웨이브 파라미터를 저장
        yield return new WaitForSeconds(Time); 
        WaveCTRL.GetComponent<EnemyWaveCtrl>().WaveOn = true;
        WaveCTRL.GetComponent<EnemyWaveCtrl>().Speed = Speed;
        WaveCTRL.GetComponent<EnemyWaveCtrl>().Durable = Durable;
        WaveCTRL.GetComponent<EnemyWaveCtrl>().MaxHP = MAXHP;
        WaveCTRL.GetComponent<EnemyWaveCtrl>().Gold = Gold;
        WaveCTRL.GetComponent<EnemyWaveCtrl>().Exp = Exp;
        //EnemySpqwn에 Count만큼 생성하도록 호출
        spawnArea.GetComponent<EnemySpawn>().SpawnStart(obj, Count, IntervalTime);
    }

}

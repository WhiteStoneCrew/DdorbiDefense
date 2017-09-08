using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBot : Enemy {//Enemy 상속
    public Vector3 dir;
    
    // Use this for initialization
    void Start()
    {
        WaveCTRL = GameObject.Find("WaveCTRL"); //웨이브컨트롤 게임오브젝트 찾아서 대입
        DataManager = GameObject.Find("PlayerDataManager");
        /*
         * 웨이브 파라미터값이 저장되어있으면 그것 호출
         * 그렇지 않으면 고유값으로 초기화
         */
        if (WaveCTRL.GetComponent<EnemyWaveCtrl>().WaveOn)
        {
            Speed = WaveCTRL.GetComponent<EnemyWaveCtrl>().Speed;
            HP = WaveCTRL.GetComponent<EnemyWaveCtrl>().MaxHP;
            MaxHP = WaveCTRL.GetComponent<EnemyWaveCtrl>().MaxHP;
            Durable = WaveCTRL.GetComponent<EnemyWaveCtrl>().Durable;
            Gold = WaveCTRL.GetComponent<EnemyWaveCtrl>().Gold;
            Exp = WaveCTRL.GetComponent<EnemyWaveCtrl>().Exp;
        }
        else//디폴트 웜봇 고유 스텟
        {
            Speed = 0.3f;
            HP = 20;
            MaxHP = 20;
            Durable = 1;
            Gold = 3;
            Exp = 5;
        }
        Target = Waypoint.points[0];
        WayIndex = 0;
        
    }
    
    void Update()
    {
        //print(Speed);
        dir = Target.position - transform.position;
        transform.LookAt(Target);
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);//해당방향(dir)로 움직인다.

        if (Vector3.Distance(transform.position, Target.position) <= 0.2f)//Waypoint와 거리가 0.1이하일때 전환
        {
            GetNextWaypoint();

        }
    }


    void GetNextWaypoint()
    {
        if (WayIndex >= Waypoint.points.Length - 1)
        {

            /*
             * 적을 통과시켰을 때. 플레이어에게 패널티를 가한다.
             * 해당 Enemy의 난이도를 고려하여 패널티 데미지를 InPlayDataManager에게 전달한다.
             */
            Destroy(gameObject);//마지막 웨이포인트일때 제거
            DataManager.GetComponent<InPlayDataManager>().PlayerDamaged(10.0f);
        }
        else
        {
            WayIndex++;
            Target = Waypoint.points[WayIndex];//다음 웨이포인트
        }
    }
    
    public override void TakeDamage(float amount)
    {
        HP -= amount;
        healthBar.fillAmount = HP / MaxHP;

        if (HP < 0)
        {
            Die();//죽음
        }
    }

    void Die()
    {
        DataManager.GetComponent<InPlayDataManager>().getMoney(5);//웜봇 가격 5원
        Destroy(gameObject);
    }
}

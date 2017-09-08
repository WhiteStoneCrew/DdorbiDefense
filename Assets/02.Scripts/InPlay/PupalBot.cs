using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupalBot : Enemy{

    public Vector3 dir;
    // Use this for initialization
    void Start()
    {
        WaveCTRL = GameObject.Find("WaveCTRL"); //웨이브컨트롤 게임오브젝트 찾아서 대입
        //웨이브 파라미터값이 저장되어있으면 그것 호출
        //그렇지 않으면 고유값으로 초기화
        if (WaveCTRL.GetComponent<EnemyWaveCtrl>().WaveOn)
        {
            Speed = WaveCTRL.GetComponent<EnemyWaveCtrl>().Speed;
            HP = WaveCTRL.GetComponent<EnemyWaveCtrl>().MaxHP;
            MaxHP = WaveCTRL.GetComponent<EnemyWaveCtrl>().MaxHP;
            Durable = WaveCTRL.GetComponent<EnemyWaveCtrl>().Durable;
            Gold = WaveCTRL.GetComponent<EnemyWaveCtrl>().Gold;
            Exp = WaveCTRL.GetComponent<EnemyWaveCtrl>().Exp;
        }
        else//디폴트 웜봇
        {
            Speed = 0.2f;
            HP = 100;
            MaxHP = 100;
            Durable = 3;
            Gold = 12;
            Exp = 15;
        }
        Target = Waypoint.points[0];
        WayIndex = 0;

    }

    // Update is called once per frame
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
            Destroy(gameObject);//마지막 웨이포인트일때 제거
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
        Destroy(gameObject);
    }
}

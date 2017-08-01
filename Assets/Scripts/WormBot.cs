using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBot : Enemy {//Enemy 상속
    
    // Use this for initialization
    void Start()
    {
        Speed = 1.0f;
        HP = 20;
        MaxHP = 20;
        Durable = 1;
        Gold = 3;
        Exp = 5;
        
        Target = Waypoint.points[0];
        WayIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);//해당방향(dir)로 움직인다.

        if (Vector3.Distance(transform.position, Target.position) <= 0.1f)//Waypoint와 거리가 0.1이하일때 전환
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

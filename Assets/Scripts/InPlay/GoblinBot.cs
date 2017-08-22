using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBot : Enemy {
    public Vector3 dir;
    // Use this for initialization
    void Start()
    {
        Speed = 0.1f;
        HP = 30;
        MaxHP = 30;
        Durable = 1.5f;
        Gold = 5;
        Exp = 7;

        Target = Waypoint.points[0];
        WayIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        dir = Target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);//해당방향(dir)로 움직인다.

        if (Vector3.Distance(transform.position, Target.position) <= 0.2f)//Waypoint와 거리가 0.1이하일때 전환
        {
            GetNextWaypoint();
        }
        transform.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().DirUpdate(dir);
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

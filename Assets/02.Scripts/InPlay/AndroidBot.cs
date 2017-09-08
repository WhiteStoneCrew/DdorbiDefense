using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidBot : Enemy
{//Enemy 상속
    public Vector3 dir;
    // Use this for initialization
    void Start()
    {
        DataManager = GameObject.Find("PlayerDataManager");
        Speed = 0.1f;
        HP = 50;
        MaxHP = 50;
        Durable = 1;
        Gold = 3;
        Exp = 5;

        Target = Waypoint.points[0];
        WayIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        dir = Target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);//해당방향(dir)로 움직인다.

        if (Vector3.Distance(transform.position, Target.position) <= 1.5f)//Waypoint와 거리가 0.1이하일때 전환
        {
            GetNextWaypoint();

        }
        Vector3 n_dir = 2 * Vector3.Normalize(dir);
        transform.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().DirUpdate(n_dir);
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
        DataManager.GetComponent<InPlayDataManager>().getMoney(25);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour {
    private string name;
    private float speed;
    private float hp, maxhp;
    private float durable;
    private int gold;//처치시 플레이어가 얻는 골드
    private int exp;//처치시 플에이어가 얻는 경험치

    public Image healthBar;
    private Transform target;//waypoint
    public GameObject WaveCTRL;
    private int wavepointIndex = 0;

    public GameObject DataManager;

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
    public float MaxHP
    {
        get { return maxhp; }
        set { maxhp = value; }
    }
    public float Durable
    {
        get { return durable; }
        set { durable = value; }
    }

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public int Exp
    {
        get { return exp; }
        set { exp = value; }
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }

    public int WayIndex
    {
        get { return wavepointIndex; }
        set { wavepointIndex = value; }
    }
    abstract public void TakeDamage(float amount);
}

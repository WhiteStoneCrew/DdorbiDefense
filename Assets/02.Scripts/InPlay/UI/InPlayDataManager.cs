using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPlayDataManager : MonoBehaviour {
    public Image healthBar;
    public Text MoneyView;
    float Health, MaxHealth;
    int Money;
    // Use this for initialization
    void Start () {
        MaxHealth = 100;
        Health = 100;
        Money = 0;
	}
	
	// Update is called once per frame
	void Update () {
        MoneyView.text = Money.ToString();

    }

    public void PlayerDamaged(float amount)
    {
        Health -= amount;
        healthBar.fillAmount = Health / MaxHealth;

        if (Health <= 0)
        {
            MissionFail();//죽음
        }
    }
    public void getMoney(int amount)
    {
        Money += amount;
    }

    public void MissionFail()
    {
        //미션 실패시.
    }
}

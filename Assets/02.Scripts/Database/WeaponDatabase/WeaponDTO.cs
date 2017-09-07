using UnityEngine;

public class WeaponDTO
{
    public int ID { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public float TurnSpeed { get; set; }
    public float AttackRange { get; set; }
    public float AttackPower { get; set; }
    public float AttackRate { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public WeaponDTO()
    {
        this.ID = -1;
    }

    public WeaponDTO(int id, string title, float price, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = price;
        this.TurnSpeed = 10;
        this.AttackRange = 10;
        this.AttackPower = 100;
        this.AttackRate = 1;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public WeaponDTO(int id, string title, float price, float turnSpeed, float attackRange, float attackPower, float attackRate, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = price;
        this.TurnSpeed = turnSpeed;
        this.AttackRange = attackRange;
        this.AttackPower = attackPower;
        this.Slug = slug;this.AttackRate = attackRate;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

}

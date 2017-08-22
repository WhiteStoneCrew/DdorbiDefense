using UnityEngine;

public class CoreDTO {

    public int ID { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public float AttackRange { get; set; }
    public float AttackPower { get; set; }
    public float AttackRate { get; set; }
    public string Slug { get; set; }
    /* Slug를 이용해 이미지를 담는다. */
    public Sprite Sprite { get; set; }

    public CoreDTO()
    {
        this.ID = -1;
    }

    public CoreDTO(int id, string title, float price, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = price;
        this.AttackRange = 1;
        this.AttackPower = 1;
        this.AttackRate = 1;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public CoreDTO(int id, string title, float price, float attackRange, float attackPower, float attackRate, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = price;
        this.AttackRange = attackRange;
        this.AttackPower = attackPower;
        this.AttackRate = attackRate;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }
}

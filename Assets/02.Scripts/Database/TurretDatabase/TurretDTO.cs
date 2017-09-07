using UnityEngine;

public class TurretDTO
{
    public int ID { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public float FinalAttackPower { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public TurretDTO()
    {
        this.ID = -1;
    }

    public TurretDTO(int id, string title, float price, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = price;
        this.FinalAttackPower = 10;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public TurretDTO(int id, string title, float price, float finalAttackPower, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Price = price;
        this.FinalAttackPower = finalAttackPower;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

}

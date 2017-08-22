using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/* TurretDatabase :
 * 인터페이스 ItemDatabase를 상속받는다.
 * 상속받은 두 메서드를 통해 JsonData를 가져오고, DTO리스트를 만든다.
 */
public class TurretDatabase : MonoBehaviour, ItemDatabase
{

    private List<TurretDTO> turretDatabase;
    private JsonData itemData;

    // Use this for initialization
    void Start () {
        turretDatabase = new List<TurretDTO>();
        JsonMapping();
        ConstructItemDatabase();
    }

    /* 해당파일(.json)에서 JsonData 형식의 데이터를 가져온다. */
    public void JsonMapping()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Turrets.json"));
    }

    /* List<TurretDTO>에 아이템에 대한 데이터Set들을 담는다. */
    public void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            Debug.Log("title :"+ (string)itemData[i]["title"]);
            turretDatabase.Add(new TurretDTO(
                (int)itemData[i]["id"],
                (string)itemData[i]["title"],
                float.Parse(itemData[i]["price"] + ""),
                float.Parse(itemData[i]["finalAttackPower"] + ""),
                (string)itemData[i]["slug"]
                ));
        }
    }

    /* 해당 ID를 가진 아이템DTO를 반환해준다.
     * ItemInPlay의 자식들에서 아이템 Shop 슬롯에 아이템을 넣을 때 호출된다. */
    public TurretDTO FetchItemByID(int id)
    {
        for (int i = 0; i < turretDatabase.Count; i++)
            if (turretDatabase[i].ID == id)
                return turretDatabase[i];
        return null;
    }

}

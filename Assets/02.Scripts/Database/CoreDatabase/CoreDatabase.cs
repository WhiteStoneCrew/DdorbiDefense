using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/* CoreDatabase :
 * 인터페이스 ItemDatabase를 상속받는다.
 * 상속받은 두 메서드를 통해 JsonData를 가져오고, DTO리스트를 만든다.
 */
public class CoreDatabase : MonoBehaviour, ItemDatabase
{
    private List<CoreDTO> coreDatabase;
    private JsonData itemData;

    // Use this for initialization
    void Start () {
        coreDatabase = new List<CoreDTO>();
        JsonMapping();
        ConstructItemDatabase();
    }

    /* 해당파일(.json)에서 JsonData 형식의 데이터를 가져온다. */
    public void JsonMapping()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Cores.json"));
    }

    /* List<TurretDTO>에 아이템에 대한 데이터Set들을 담는다. */
    public void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            coreDatabase.Add(new CoreDTO(
                (int)itemData[i]["id"],
                (string)itemData[i]["title"],
                float.Parse(itemData[i]["price"] + ""),
                float.Parse(itemData[i]["attackRange"] + ""),
                float.Parse(itemData[i]["attackPower"] + ""),
                float.Parse(itemData[i]["attackRate"] + ""),
                (string)itemData[i]["slug"]
                ));

        }
    }

    /* 해당 ID를 가진 아이템DTO를 반환해준다.
     * ItemInPlay의 자식들에서 아이템 Shop 슬롯에 아이템을 넣을 때 호출된다. */
    public CoreDTO FetchItemByID(int id)
    {
        for (int i = 0; i < coreDatabase.Count; i++)
            if (coreDatabase[i].ID == id)
                return coreDatabase[i];
        return null;
    }
}

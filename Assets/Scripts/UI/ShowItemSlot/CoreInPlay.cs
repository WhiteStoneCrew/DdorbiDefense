using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreInPlay : MonoBehaviour, ItemInPlay {

    /* corePanel, slotPanel : core를 보여줄 [샵판넬-슬롯판넬]
     * coreDatabase : database에서 core의 데이터를 추출해올 때 사용*/
    public GameObject corePanel;
    public GameObject slotPanel;
    public CoreDatabase coreDatabase;

    /* [슬롯판넬 - 이미지, 타이틀, 가격]의 구성을 만들기 위한 오브젝트 변수*/
    public GameObject coreSlot;
    public GameObject itemImage;
    public GameObject itemTitle;
    public GameObject itemPrice;

    /* cores : core 데이터 보관
     * slots : 각 슬롯의 오브젝트 보관
     * hashtable_Items : 각 슬롯에 들어간 데이터 보관*/
    public List<CoreDTO> cores = new List<CoreDTO>();
    public List<GameObject> slots = new List<GameObject>();
    public static Hashtable hashtable_Items = new Hashtable();

    /* 데이터베이스 스크립트의 인스턴스를 생성
     * 슬롯 초기화, 슬롯에 아이템 삽입*/
    void Start () {
        coreDatabase = GetComponent<CoreDatabase>();

        /* 슬롯 초기화 */
        InitSlot(20);

        /* 슬롯에 아이템 삽입 */
        AddItem(0);
        AddItem(1);
    }

    /* 파라미터 slotAmount의 정수값 만큼 [슬롯 오브젝트] 생성 */
    public void InitSlot(int slotAmount)
    {
        corePanel = GameObject.Find("Core Panel");
        slotPanel = corePanel.transform.Find("Slot Panel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            cores.Add(new CoreDTO());
            slots.Add(Instantiate(coreSlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }

    /* 데이터베이스의 id번째 아이템을 [슬롯]에 생성한다.
     * 1. Title
     * 2. Price
     * 3. Item Image*/
    public void AddItem(int id)
    {
        /* FetchItemByID를 통해 해당 id의 아이템 데이터를 가져온다*/
        CoreDTO itemToAdd = coreDatabase.FetchItemByID(id);

        /* loop를 사용하는 이유는 -1(아이템이 빈 슬롯)을 찾기 위해서 */
        for (int i = 0; i < cores.Count; i++)
        {
            if (cores[i].ID == -1)
            {

                GameObject coreTitle = Instantiate(itemTitle);
                coreTitle.transform.SetParent(slots[i].transform);
                coreTitle.transform.position = Vector2.zero;
                coreTitle.name = itemToAdd.Title + " Title";
                Text title = coreTitle.GetComponent<Text>();
                title.text = itemToAdd.Title;
                title.color = Color.black;

                GameObject corePrice = Instantiate(itemPrice);
                corePrice.transform.SetParent(slots[i].transform);
                corePrice.transform.position = Vector2.zero;
                corePrice.name = itemToAdd.Title + " Price";
                Text price = corePrice.GetComponent<Text>();
                price.text = itemToAdd.Price + "";
                price.color = Color.black;
            
                cores[i] = itemToAdd;
                GameObject coreImage = Instantiate(itemImage);
                coreImage.transform.SetParent(slots[i].transform);
                coreImage.GetComponent<Image>().sprite = itemToAdd.Sprite;
                coreImage.transform.position = Vector2.zero;
                coreImage.name = itemToAdd.Title + " Image";

                /* 데이터를 <DTO.Title + " Image", DTO> 형태로 hashtable에 저장 
                 * shop에서 아이템(이미지)을 누르면 해당 name이 출력되고 그 name을 key로 value를 얻어낸다.
                 * 그리고 그 value.Title의 이름을 가진 오브젝트 호출 및 생성!!*/
                hashtable_Items.Add(coreImage.name, itemToAdd);

                break;
            }
        }
    }

    /* 구매하고자 하는 아이템 클릭시 발생하는 이벤트 */
    public void PuchaseItem(GameObject item)
    {
        /* 어떤 이유에서는 pressedCombinationTurret가 null이면, 선택된 터렛이 없으므로 설치할 수 없다. */
        if (CombinationManager.GetInstance().pressedCombinationTurret == null)
        {
            Debug.Log("선택된 터렛이 없습니다.");
            return;
        }

        /* 무기가 장착되지 않았으면 보조장비를 장착할 수 없도록 한다.
         * 이유는 터렛에 무기를 달 때 무기의 능력치가 생기고,
         * 보조장비가 장착되면 그 능력치에 값에 보조장비 추가효과(*N%)를 계산해주기 때문이다. */
        if (CombinationManager.GetInstance().pressedCombinationTurret.NumberOfWeapons == 0)
        {
            Debug.Log("Weapon을 먼저 장착해주세요.");
            return;
        }

        /* 최대 착용 가능 수를 확인 */
        if (!(CombinationManager.GetInstance().pressedCombinationTurret.NumberOfCores < CombinationManager.MAX_WEARABLE_NUM_CORE))
        {
            Debug.Log("Core를 모두 착용했습니다.");
            return;
        }

        /* CombinationManager가 아직 보조장비를 건설 중이면 다른 터렛에 보조장비를 건설할 수 없다. */
        if (CombinationManager.GetInstance().isRunning)
        {
            Debug.Log("장비 건설 중입니다.. 잠시 후에 다시 시도해주세요.");
            UIManager.GetInstance().ChangeShopEnable();
            CombinationManager.GetInstance().pressedCombinationTurret = null;
            return;
        }

        /* 클릭된 오브젝트의 이름으로 코어 데이터(DTO)를 추출해낸다.*/
        string title = item.transform.name; //클릭된 아이템 name
        CoreDTO data = (CoreDTO)hashtable_Items[title];

        /* CombinationManager의 onSelectedWeapon()를 호출하면서 인자로 data(DTO)를 넘긴다. */
        CombinationManager.GetInstance().OnSelectedCore(data);
    }
}

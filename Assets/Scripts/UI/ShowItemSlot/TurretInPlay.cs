using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInPlay : MonoBehaviour, ItemInPlay {

    /* turretPanel, slotPanel : turret을 보여줄 [샵판넬-슬롯판넬]
     * turretDatabase : database에서 turre의 데이터를 추출해올 때 사용*/
    public GameObject turretPanel;
    public GameObject slotPanel;
    public TurretDatabase turretDatabase;

    /* [슬롯판넬 - 이미지, 타이틀, 가격]의 구성을 만들기 위한 오브젝트 변수*/
    public GameObject turretSlot;
    public GameObject itemImage;
    public GameObject itemTitle;
    public GameObject itemPrice;

    /* turrets : turret 데이터 보관
     * slots : 각 슬롯의 오브젝트 보관
     * hashtable_Items : 각 슬롯에 들어간 데이터 보관*/
    public List<TurretDTO> turrets = new List<TurretDTO>();
    public List<GameObject> slots = new List<GameObject>();
    public static Hashtable hashtable_Items = new Hashtable();

    /* 터렛 선택으로 구매 이벤트 발생시 turretDTO를 초기화하고,
     * turretDTO는 CombinationManager에서 사용된다. */
    public TurretDTO turretDTO;

    /* 데이터베이스 스크립트의 인스턴스를 생성
     * 슬롯 초기화, 슬롯에 아이템 삽입*/
    void Start ()
    { 
        turretDatabase = GetComponent<TurretDatabase>();

        /* 슬롯 초기화 */
        InitSlot(1);

        /* 슬롯에 아이템 삽입 */
        AddItem(0);
        AddItem(1);
    }

    /* 파라미터 slotAmount의 정수값 만큼 [슬롯 오브젝트] 생성 */
    public void InitSlot(int slotAmount)
    {
        turretPanel = GameObject.Find("Turret Panel");
        slotPanel = turretPanel.transform.Find("Slot Panel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            turrets.Add(new TurretDTO());
            slots.Add(Instantiate(turretSlot));
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
        TurretDTO itemToAdd = turretDatabase.FetchItemByID(id);

        /* loop를 사용하는 이유는 -1(아이템이 빈 슬롯)을 찾기 위해서 */
        for (int i = 0; i < turrets.Count; i++)
        {
            if (turrets[i].ID == -1)
            {
                GameObject turretTitle = Instantiate(itemTitle);
                turretTitle.transform.SetParent(slots[i].transform);
                turretTitle.transform.position = Vector2.zero;
                turretTitle.name = itemToAdd.Title + " Title";
                Text title = turretTitle.GetComponent<Text>();
                title.text = itemToAdd.Title;
                title.color = Color.black;

                GameObject turretPrice = Instantiate(itemPrice);
                turretPrice.transform.SetParent(slots[i].transform);
                turretPrice.transform.position = Vector2.zero;
                turretPrice.name = itemToAdd.Title + " Price";
                Text price = turretPrice.GetComponent<Text>();
                price.text = itemToAdd.Price + "";
                price.color = Color.black;

                turrets[i] = itemToAdd;
                GameObject turretImage = Instantiate(itemImage);
                turretImage.transform.SetParent(slots[i].transform);
                turretImage.GetComponent<Image>().sprite = itemToAdd.Sprite;
                turretImage.transform.position = Vector2.zero;
                turretImage.name = itemToAdd.Title + " Image";

                /* 데이터를 <DTO.Title + " Image", DTO> 형태로 hashtable에 저장 
                 * shop에서 아이템(이미지)을 누르면 해당 name이 출력되고 그 name을 key로 value를 얻어낸다.
                 * 그리고 그 value.Title의 이름을 가진 오브젝트 호출 및 생성!!*/
                hashtable_Items.Add(turretImage.name, itemToAdd);

                break;
            }
        }
    }

    /* 구매하고자 하는 아이템 클릭시 발생하는 이벤트 
     * 지금은 클릭만으로 터렛을 생성해놓기 때문에
     * 터치 다운때만 생성하고 뗐을때 없앨거면 후에 코딩을 수정해야함.
     * 터치 다운때 레이캐스트를 실행하도록 해야함.*/
    public void PuchaseItem(GameObject item)
    {
        string title = item.transform.name; //클릭된 아이템 name(예: Stadard Turret Image)  
        TurretDTO turretDTO = (TurretDTO)hashtable_Items[title]; //클릭된 아이템의 데이터 가져오기 (뒤에 붙은 "Image"를 뺀 순수 아이템 name을 가져오기 위해)

        CombinationManager.GetInstance().IsChoice = true;
        CombinationManager.GetInstance().CreateCombinationTurret(turretDTO); //준혁이랑 합칠 때 터치가 떼어지면 실행되게 바꿔여함
        Debug.Log(title + "이 구매할 항목으로 선택됐습니다.");
    }

}

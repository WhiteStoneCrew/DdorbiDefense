using UnityEngine;

public class CombinationManager : MonoBehaviour {

    private static CombinationManager instance;

    /* CombinationTurret에 착용 가능한 장비 수]
     * ItemInPlay 하위 클래스에서 아이템이 눌렸을 때 조건으로 사용된다.
     * 만약 Weapon 착용 가능한 수가 1보다 커지면, CombinationTurret.cs로 가서 Turret Info를 수정해야한다.*/
    public const int MAX_WEARABLE_NUM_WEAPON = 1;
    public const int MAX_WEARABLE_NUM_CORE = 2;
    public const int MAX_BUILDABLE_TURRET = 4;

    /* isRunning : 현재 무기 또는 보조장비가 건설중인지 판단, 건설중이면 다른 것을 건설할 수 없음
     * IsChoice : 설치할 터렛을 선택했는지 판단 */
    public bool isRunning;
    public bool IsChoice { get; set; }

    /* 현재 빌드된 터렛의 수
     * 최대 터렛 빌수 가능 수 제한에 사용 */
    private int numOfBuildedTurret;

    /* 현재 선택된 조합터렛을 받을 참조변수
     * 무기나, 코어 장착 시 장착되는 터렛으로 사용됨.*/
    public CombinationTurret pressedCombinationTurret;

    /* CombinationTurret Info */
    private GameObject combinationTurretObject;
    private CombinationTurret combinationTurretScript;

    /* Turret Info */
    private TurretDTO turretDTO;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already an instance!!");
        }
        instance = this;
    }

    public static CombinationManager GetInstance()
    {
        return instance;
    }

    /* Turret Shop에서 터렛 선택 시 호출
     * + CombinationTurret 오브젝트를 생성한다.*/
    public void CreateCombinationTurret(TurretDTO turretDTO)
    {
        /* CombinationTurret스크립트와 Turret스크립트에 넘겨줄 TurretDTO를 저장 */
        this.turretDTO = turretDTO;
    }

    /* 선택된 노드 위에 선택된 터렛을 설치할 때 호출
     * + CreateCombinationTurret()에서 생성한 CombinationTurret의 위치를 노드위로 이동시킨다.
     * + Turret 오브젝트를 생성해 CreateCombinationTurret 오브젝트에 붙인다.
     * + CombinationTurret 스크랩트와 Turret 스크랩트에 각종 데이터를 넘겨준다.*/
    public bool BuildTurret(Transform node, Vector3 turretPositionOffset)
    {
        /* CombinationTurret */
        combinationTurretObject = Resources.Load("Prefabs/CombinationTurret/Combiantion Turret") as GameObject;
        combinationTurretObject = Instantiate(combinationTurretObject);
        Debug.Log("combinationTurretObject :" + combinationTurretObject);
        combinationTurretObject.transform.SetParent(GameObject.Find("Combination Turret In Play").transform);
        Debug.Log("combinationTurretObject :" + combinationTurretObject);
        combinationTurretScript = combinationTurretObject.GetComponent<CombinationTurret>();
        Debug.Log("combinationTurretScript :" + combinationTurretScript);

        /* CombinationTurret의 위치를 노드 위로 이동시킨다. */
        combinationTurretObject.transform.position = node.position + turretPositionOffset;
        combinationTurretObject.transform.rotation = node.rotation;

        /* combinationTurretScript에서 터렛을 생성한다. */
        combinationTurretScript.SetTurret(turretDTO);

        /* 각종 데이터를 넘겨준다. */
        SendTheCombinationTurretData();

        /* 현재 빌드된 터렛의 수를 올린다. */
        numOfBuildedTurret++;

        /* 현재 빌드된 터렛의 수가 4이상이면 비활성화 시킨다. */
        if (numOfBuildedTurret >= 4)
        {
            GameObject turretPanel = GameObject.Find("Turret Panel");
            turretPanel.SetActive(false);
        }
        return true;
    }

    /* 각종 데이터를 넘겨준다. To 'CombinationTurret 스크랩트'와 'Turret 스크랩트' */
    private void SendTheCombinationTurretData()
    {
        IsChoice = false;

        combinationTurretScript.CombinationTurretObject = combinationTurretObject;
        combinationTurretScript.TurretDTO = turretDTO;

        turretDTO = null;
        combinationTurretObject = null;
        combinationTurretScript = null;
    }

    /* 무기 선택 시 WeaponInPlay의 PuchaseItem을 거쳐 호출 */
    public void OnSelectedWeapon(WeaponDTO dto)
    {
        /* 현재 조합중인 조합터렛에 무기를 장착한다.
         * 데이터를 넘겨야함.
         * 무슨 데이터? DTO!!
         * DTO에 모든 정보가 담겨있다!
         */
        Debug.Log("조합 매니저가 받은 데이터 :" + dto.Title);

        /* 현재 선택된 조합터렛에 무기를 장착한다.(무기 데이터를 넘겨준다.) */
        pressedCombinationTurret.SetWeapon(dto);
        pressedCombinationTurret = null;

        /* 무기 선택 후 Shop 닫음, pressedCombinationTurret의 NUll값에 의한 예외상황이 발생할 수 있음 */
        UIManager.GetInstance().ChangeShopEnable();
    }

    /* 보조장비 CoreInPlay의 PuchaseItem을 거쳐 호출 */
    public void OnSelectedCore(CoreDTO dto)
    {
        /* 현재 조합중인 조합터렛에 보조장비를 장착한다.
         * 데이터를 넘겨야함.
         * 무슨 데이터? DTO!!
         * DTO에 모든 정보가 담겨있다!
         */
        Debug.Log("조합 매니저가 받은 데이터 :" + dto.Title);

        /* 현재 선택된 조합터렛에 보조장비를 장착한다.(보조장비 데이터를 넘겨준다.) */
        pressedCombinationTurret.SetCore(dto);
        pressedCombinationTurret = null;

        /* 무기 선택 후 Shop 닫음, pressedCombinationTurret의 NUll값에 의한 예외상황이 발생할 수 있음 */
        UIManager.GetInstance().ChangeShopEnable();
    }

}

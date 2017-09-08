using UnityEngine;

public class CombinationTurret : MonoBehaviour
{
    /* Combiantion Turret */
    public GameObject CombinationTurretObject { get; set; }

    /* 장착된 장비의 수 */
    public int NumberOfWeapons { set; get; }
    public int NumberOfCores { set; get; }

    /* Turret Info
    * 장착 가능한 무기 수가 늘어난다면 배열형태로 바꾸고, 아래 SetTurretScript()는 배열에 데이터 추가하는 로직으로 바꾸면됨.*/
    public TurretDTO TurretDTO { get; set; }
    private GameObject turretObject;
    private Turret turretScript;

    /* Weapon Info */
    private Weapon weaponScript;
    private WeaponDTO weaponDTO;

    /* setters.. */
    public void SetTurretScript(Turret turretScript)
    {
        this.turretScript = turretScript;
    }



    public void SetTurret(TurretDTO turretDTO)
    {
        /* Turret : 터렛 오브젝트(__ Turret) 생성 및 스크립트 가져오기 */
        turretObject = Resources.Load("Prefabs/Items/Turrets/" + turretDTO.Title) as GameObject;
        turretObject = Instantiate(turretObject, transform.position, transform.rotation);
        turretObject.transform.SetParent(transform);
        turretScript = turretObject.GetComponent<Turret>();

        turretScript.CombinationTurret = this;
        turretScript.SetTurretDTO(turretDTO);
    }

    /* 웨폰을 장착한다. */
    public void SetWeapon(WeaponDTO dto)
    {
        /* 조합 매니저의 현재 상태를 '건설중'으로 바꾼다. */
        CombinationManager.GetInstance().isRunning = true;

        /* 현재 터렛에 무기를 붙인다. 
         * 위치는 터렛 위, 관계는 Combiantion Turret의 자식으로!*/
        GameObject weapon = Resources.Load("Prefabs/Items/Weapons/" + dto.Title) as GameObject;
        weapon = Instantiate(weapon, turretScript.weapon1Point.transform.position, turretScript.weapon1Point.transform.rotation);
        weapon.transform.SetParent(turretScript.weapon1Point.transform);

        /* Weapon Script 할당*/
        weaponScript = weapon.GetComponent<Weapon>();

        /* 최종 공격력 적용 */
        weaponScript.FinalAttackPower = TurretDTO.FinalAttackPower;

        /* 현재 능력치를 조정한다. (Weapon은 고대로 넘겨주면 됨) */
        weaponDTO = dto;

        /* 직접 공격하는 Weapon에 적용된 능력치를 업데이트 해준다. */
        UpdateWeapon();

        /* 장착한 무기 수를 기록 */
        NumberOfWeapons++;

        /* 조합 매니저의 현재 상태를 '건설 대기중'으로 바꾼다. */
        CombinationManager.GetInstance().isRunning = false;
    }

    /* 보조장비(코어)를 장착한다. */
    public void SetCore(CoreDTO dto)
    {
        /* 조합 매니저의 현재 상태를 '건설중'으로 바꾼다. */
        CombinationManager.GetInstance().isRunning = true;

        /* 현재 터렛에 보조장비를 붙인다. 
         * 위치는 터렛 뒤, 관계는 Combiantion Turret의 자식으로!*/
        GameObject core = Resources.Load("Prefabs/Items/Cores/" + dto.Title) as GameObject;
        GameObject corePoint;
        if (NumberOfCores == 0)
            corePoint = turretScript.core1Point;
        else
            corePoint = turretScript.core2Point;
        core = Instantiate(core, corePoint.transform.position, corePoint.transform.rotation);
        core.transform.SetParent(corePoint.transform);

        /* 현재 능력치를 조정한다. (Core는 고대로'% 곱하기') */
        weaponDTO.AttackPower *= dto.AttackPower;
        weaponDTO.AttackRate *= dto.AttackRate;
        weaponDTO.AttackRange *= dto.AttackRange;

        /* 직접 공격하는 Weapon에 적용된 능력치를 업데이트 해준다. */
        UpdateWeapon();

        /* 장착한 보조 장비 수를 기록 */
        NumberOfCores++;

        /* 조합 매니저의 현재 상태를 '건설 대기중'으로 바꾼다. */
        CombinationManager.GetInstance().isRunning = false;
    }

    /* 무기나 보조장비를 착용할 때 호출되며, 무기의 스탯을 업데이트한다. */
    private void UpdateWeapon()
    {
        weaponScript.WeaponDTO = weaponDTO;

        Debug.Log("--무기 이름 :" + weaponDTO.Title 
            + "\n--회전 속도 :" + weaponDTO.TurnSpeed 
            + "\n--공격 범위 :" + weaponDTO.AttackRange
            + "\n--공격 속도 :" + weaponDTO.AttackRate
            + "\n--공격력 :" + weaponDTO.AttackPower
            + "\n--최종 데미지(%)" + weaponScript.FinalAttackPower
            + "\n--최종 공격력 :" + weaponDTO.AttackPower * TurretDTO.FinalAttackPower
            + "\n--");
    }








    /* [미완] Combination Turret Info에 대한 참조변수 */
    //private GameObject combiantionTurretInfoObject;
    //private Text combiantionTurretInfoText;

    /* [미완] 'Combination Turret Info'를 생성한다. */
    private void CreateInfo()
    {
        /*
        GameObject combiantionTurretInfoCanvas = GameObject.Find("Combiantion Turret Info Canvas");
        combiantionTurretInfoObject = Resources.Load("Prefabs/CombinationTurret/Combiantion Turret Info") as GameObject;
        combiantionTurretInfoObject = Instantiate(combiantionTurretInfoObject);
        combiantionTurretInfoObject.transform.SetParent(combiantionTurretInfoCanvas.transform);
        combiantionTurretInfoText = combiantionTurretInfoObject.GetComponent<Text>();
        */
    }

    /* [미완] 'Combination Turret Info'를 업데이트한다. */
    private void UpdateInfo()
    {
       // combiantionTurretInfoText.text = "turnSpeed " + "attackRange " + "attackPower " + "attackRate " + "finalAttackPower ";
    }
}

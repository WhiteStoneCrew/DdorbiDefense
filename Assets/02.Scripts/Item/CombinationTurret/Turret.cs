using UnityEngine;

public class Turret : MonoBehaviour
{
    private TurretDTO turretDTO;

    public CombinationTurret CombinationTurret { set; get; }

    public GameObject weapon1Point;
    public GameObject core1Point;
    public GameObject core2Point;

    public void SetTurretDTO(TurretDTO turretDTO)
    {
        this.turretDTO = turretDTO;
    }
    /* 조합터렛이 눌리면 호출 */
    private void OnMouseDown()
    {
        /* Turret Shop 이외에 다른 UI가 UICamera에 잡히면 MainCamera의 오브젝트 이벤트 발생을 막는다.
         * 만약 Turret Shop UI 말고도 기본 화면에 배치할게 있다면, 다른 소스에도 활용해야한다. */
        if (null == UICamera.hoveredObject)
        {
            GameObject turretCanvas = GameObject.Find("Play UI");
            Canvas tCanvas = turretCanvas.GetComponent<Canvas>();
            if (!tCanvas.enabled)
                return;
        }

        /* Shop UI State를 Chage한다. */
        UIManager uiManager = UIManager.GetInstance();
        uiManager.ChangeShopEnable();

        /* CombinationManager의 참조변수 pressedCombinationTurret 일시적으로 눌린 조합터렛을 담는다. */
        CombinationManager.GetInstance().pressedCombinationTurret = CombinationTurret;
        Debug.Log("pressed CombinationTurret !");
    }
}

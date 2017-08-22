using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor1;
    public Color hoverColor2;
    public Vector3 turretPositionOffset;

    private Renderer rend;
    private Color startColor;

    /* 현재 노드에 터렛 설치 시 isMade에 true를 할당하여 설치되어있는가를 판단하는데 쓰임 */
    private bool isMade;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    /* 노드를 클릭, 노드에 터렛을 설치할 때 발생 */
    private void OnMouseDown()
    {
        /* 터렛 선택 창에서 터렛을 선택하면 IsChoice가 true가 된다. */
        if (!CombinationManager.GetInstance().IsChoice)
            return;
        else if (isMade)
        {
            Debug.Log("이미 터렛이 생성되었습니다.");
            return;
        }
        else
        {
            isMade = CombinationManager.GetInstance().BuildTurret(transform, turretPositionOffset);
            rend.material.color = startColor;
        }
    }

    private void OnMouseEnter()
    {
        if (CombinationManager.GetInstance().IsChoice)
        {
            /* 터렛 설치가 가능하면 파란색, 아니면 빨간색 */
            if (!isMade)
                rend.material.color = hoverColor1; //파란
            else
                rend.material.color = hoverColor2; //빨간
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}

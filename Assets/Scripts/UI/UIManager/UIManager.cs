using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already an instance!!");
        }
        instance = this;

        /* In Play.. */
        GameObject shopCanvas = GameObject.Find("Shop Canvas");
        Canvas sCanvas = shopCanvas.GetComponent<Canvas>();
        sCanvas.enabled = false;

        GameObject turretCanvas = GameObject.Find("Play UI");
        Canvas tCanvas = turretCanvas.GetComponent<Canvas>();
        tCanvas.enabled = true;
    }

    public static UIManager GetInstance() {
        return instance;
    }

    /* Play UI와 [무기, 보조장비] 상점 UI를 교체하여 보여준다. */
    public void ChangeShopEnable()
    {
        /* pressedCombinationTurret 확인 후 비어있지 않으면 비우고 UI를 끈다. */
        if (CombinationManager.GetInstance().pressedCombinationTurret != null)
            CombinationManager.GetInstance().pressedCombinationTurret = null;

        GameObject shopCanvas = GameObject.Find("Shop Canvas");
        Canvas sCanvas = shopCanvas.GetComponent<Canvas>();
        sCanvas.enabled = !sCanvas.enabled;

        GameObject turretCanvas = GameObject.Find("Play UI");
        Canvas tCanvas = turretCanvas.GetComponent<Canvas>();
        tCanvas.enabled = !sCanvas.enabled;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour {

    public Ray ray;
    public RaycastHit hitInfo;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log(hitInfo.transform.gameObject.name); //gameObject name
                if (hitInfo.transform.gameObject.name == "Enemy_Android(Clone)")
                {
                    hitInfo.transform.GetComponent<AndroidBot>().TakeDamage(2);
                }
                
            }
        }
    }
}

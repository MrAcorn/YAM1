using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimRay : MonoBehaviour
{
    public Ray aim;
    public RaycastHit hitData;
    public string colName;
    public Vector3 aimPoint;
    public Transform testCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        testCube.position = aimPoint;
        aim = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(aim, out hitData, 999))
        {
            aimPoint = hitData.point;
            colName = hitData.transform.gameObject.name;
        }
        else
        {
            aimPoint = transform.position + transform.forward * 99999;
        }
    }
}

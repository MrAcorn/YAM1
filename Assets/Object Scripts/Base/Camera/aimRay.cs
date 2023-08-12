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

    //for testing
    public GameObject testValue;
    public float testFloat;
    public Camera cam;
    public List<GameObject> lockedOn;
    // Update is called once per frame
    void Start(){
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        testCube.position = aimPoint;
        aim = cam.ScreenPointToRay(Input.mousePosition);
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
    public GameObject GetAutoAim(List<GameObject> targets){
        GameObject hold = null;
        float hold2 = Mathf.Infinity;
        for(int i = 0; i < targets.Count; i++){
            float hold3 = Mathf.Abs(Vector2.Distance(cam.WorldToScreenPoint(targets[i].transform.position), new Vector2(cam.pixelWidth/2, cam.pixelHeight/2)));

            if(hold3 < hold2 && targets[i].gameObject.GetComponent<TagsBase>().targetable){
                hold = targets[i];
                hold2 = hold3;
            }

        }
        lockedOn = targets;
        return hold;

    }

}

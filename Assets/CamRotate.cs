using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = transform.position - new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);


        if (viewDir != Vector3.zero)
        {
            transform.forward = viewDir.normalized;
        }
    }
}

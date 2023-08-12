using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam2 : MonoBehaviour
{
    public float mousey;
    public float sensy;
    public float mousex;
    public float sensx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousey = Input.GetAxis("Mouse Y") * sensy;
        mousex = Input.GetAxis("Mouse X") * sensx;
        Vector3 move = new Vector3(mousey, mousex, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + move);
    }

}

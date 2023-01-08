using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caller : MonoBehaviour
{
    private Reciver HomePhone;
    public bool announceSelf = true;
    // Start is called before the first frame update
    void Start()
    {
        HomePhone = GameObject.Find("HomePhone").GetComponent<Reciver>();
        if (announceSelf)
        {
            HomePhone.Call(this.ToString(), gameObject.name + " Is Here!", 3);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Call(string sourse, string message, int priority)
    {

        HomePhone.Call(sourse, message, priority);

    }
}


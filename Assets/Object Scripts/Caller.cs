using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caller : MonoBehaviour
{
    private Reciver HomePhone;
    // Start is called before the first frame update
    void Start()
    {
        HomePhone = GameObject.Find("HomePhone").GetComponent<Reciver>();
        HomePhone.Call(gameObject.name + " Is Here!", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Call(string message, int priority)
    {

        HomePhone.Call(message, priority);

    }
}


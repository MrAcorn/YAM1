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
    /// <summary>
    ///gameObject.name for source | what you wana say | Mute(0), All(1), Abli(2), Dev(3)
    /// </summary>
    public void Call(string sourse, string message, int priority)
    {

        HomePhone.Call(sourse, message, priority);

    }
}


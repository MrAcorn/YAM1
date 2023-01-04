using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciver : MonoBehaviour
{
    public int messageCounter = 0;
    /*Setpriority expalnation:
    0 = Mute all
    1 = All chat
    2 = Abli
    3 = Dev
     */
    public int setPriority = 3;
    // Start is called before the first frame update
    void OnEnable()
    {
        Call(gameObject.name + " Is Reciving", 2);
        Call(gameObject.name + " Is Dev Reciving", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///Mute(0), All(1), Abli(2), Dev(3)
    /// </summary>
    public void Call(string message, int priority)
    {
        messageCounter++;

        if (priority <= setPriority)
        {
            print(message + ' ' + (messageCounter));
        }
        
    }
}

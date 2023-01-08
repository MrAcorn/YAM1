using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reciver : MonoBehaviour
{
    public Text txt;
    private int messageOnScreen;
    public int messageCounter = 0;
    /*Setpriority expalnation:
    0 = Mute all
    1 = All chat
    2 = Abli
    3 = Dev
     */
    public int setPriority = 3;
    public List<string> chatTracker = new List<string>(10);
    // Start is called before the first frame update
    void OnEnable()
    {
        txt = GetComponent<Text>();
        Call(this.ToString(), gameObject.name + " Is Reciving", 2);
        Call(this.ToString(), gameObject.name + " Is Dev Reciving", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///Mute(0), All(1), Abli(2), Dev(3)
    /// </summary>
    public void Call(string sourse, string message, int priority)
    {
        messageCounter++;

        if (priority <= setPriority)
        {
            AddText("From: " + sourse + " - " + message + ", " + (messageCounter));
        }
        
    }

    private void AddText(string message)
    {
        chatTracker.Add(message);
        messageOnScreen++;
        while(messageOnScreen > 10)
        {
            chatTracker.RemoveAt(0);
            messageOnScreen--;
        }
        print();
    }
    private void print()
    {
        txt.text = "";
        for(int i = 0; i < messageOnScreen; i++)
        {
            txt.text += ('\n' + chatTracker[i]);
        }
    }
}

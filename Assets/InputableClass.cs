using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputableClass : MonoBehaviour
{
    [SerializeField] protected InputCollecter trigger;
    [SerializeField] protected Caller caller;
    [SerializeField] protected Stats stats;
    [Tooltip("1 = Fwrd, 2 = Bwrd, 3 = Lwrd, 4 = Rwrd, 5 = Up, 6 = Down, 7 = Sprint, 8 = spark, 9 = leftC, 10 = rightC, 11 = scroll")]
    [SerializeField] protected int input = 0;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        trigger = GetComponent<InputCollecter>();
        caller = GetComponent<Caller>();
        //Set button
        if (!trigger.AddInput(this, input))
        {
            print("here1");
            caller.Call(gameObject.name, "I was not set to a button!", 3);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void InputCalled()
    {
        caller.Call(gameObject.name, "inputCalled", 3);
    }
}

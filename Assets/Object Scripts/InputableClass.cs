using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputableClass : MonoBehaviour
{
    public bool castable;
    public float cooldown;
    public float setCooldown;
    protected InputCollecter trigger;
    protected Caller caller;
    protected Stats stats;
    [Tooltip("1 = Fwrd, 2 = Bwrd, 3 = Lwrd, 4 = Rwrd, 5 = Up, 6 = Down, 7 = Sprint, 8 = spark, 9 = leftC, 10 = rightC, 11 = scroll")]
    [SerializeField] protected int input = 0;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        stats = GetComponent<Stats>();
        caller = GetComponent<Caller>();
        //Set button
        if (TryGetComponent<InputCollecter>(out trigger) && input != 0 && !trigger.AddInput(this, input))
        {
            caller.Call(gameObject.name, "I was not set to a button!", 3);
        }


    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(cooldown > 0)
        cooldown -= Time.deltaTime;
    }
    public virtual void InputCalled()
    {
        caller.Call(gameObject.name, "inputCalled", 3);
    }
}

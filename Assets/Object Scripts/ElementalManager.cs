using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalManager : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    private Collider col;
    private MeshRenderer meshR;
    //
    public List<int> elementQueue = new List<int>();
    public List<GameObject> elementQueueName = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        inputC = GetComponent<InputCollecter>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        gm = GetComponent<GeneralMovement>();
        combatStats = GetComponent<CombatStats>();
        col = GetComponent<BoxCollider>();
        meshR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(elementQueue.Count >= 2)
        {
            ElementReaction();
        }
    }
    
    public void ApplyElement(int type, GameObject source)
    {
        if(type != 0)
        {
            elementQueue.Add(type);
            elementQueueName.Add(source);
            caller.Call(this.ToString(), "Element " + ElementTranslator(elementQueue[0]) + ", from: " + elementQueueName[0], 3);
        }

    }

    void ElementReaction()
    {
        caller.Call(this.ToString(), "Element " + ElementTranslator(elementQueue[0]) + " and " + ElementTranslator(elementQueue[1]) + " consumed.", 3);
        // call elemental Effect manager useing the the data from the frist 2 spots
        elementQueue.RemoveAt(1);
        elementQueue.RemoveAt(0);
        elementQueueName.RemoveAt(1);
        elementQueueName.RemoveAt(0);
    }

    public string ElementTranslator(int input)
    {
        switch (input)
        {
            case 0:
                return ("untaged");
            case 1:
                return ("fire");
            case 2:
                return ("water");
            case 3:
                return ("wood");
            case 4:
                return ("metal");
            case 5:
                return ("earth");
            case 6:
                return ("celestial");
            default:
                return ("untaged");
        }
    }
}

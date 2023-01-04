using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollecter : MonoBehaviour
{
    //Higer Up Scripts
    private Caller caller;
    //set buttons
    [SerializeField] private KeyCode FwrdBut;
    [SerializeField] private KeyCode BwrdBut;
    [SerializeField] private KeyCode LwrdBut;
    [SerializeField] private KeyCode RwrdBut;
    [SerializeField] private KeyCode upBut;
    [SerializeField] private KeyCode downBut;
    [SerializeField] private KeyCode sprintBut;
    [SerializeField] private KeyCode sparkBut;
    [SerializeField] private KeyCode leftCBut;
    [SerializeField] private KeyCode rightCBut;
    //keep it 1 thru 10, where 10 is menu stuff
    [SerializeField] private List<KeyCode> abilityBut = new List<KeyCode>();
    //Looked On variables
    public bool Fwrd;
    public bool Bwrd;
    public bool Lwrd;
    public bool Rwrd;
    public bool up;
    public bool down;
    public bool sprint;
    public bool spark;
    public float scroll;
    public bool leftC;
    public bool rightC;
    //keep it 1 thru 10, where 10 is menu stuff
    public List<bool> ability = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fwrd = Input.GetKey(FwrdBut);
        Bwrd = Input.GetKey(BwrdBut);
        Lwrd = Input.GetKey(LwrdBut);
        Rwrd = Input.GetKey(RwrdBut);
        up = Input.GetKey(upBut);
        down = Input.GetKey(downBut);
        sprint = Input.GetKey(sprintBut);
        spark = Input.GetKey(sparkBut);
        leftC = Input.GetKey(leftCBut);
        rightC = Input.GetKey(rightCBut);
        scroll = Input.mouseScrollDelta.y;
        
        for (int i = 0; i < ability.Count; i++)
        {
            if (Input.GetKey(abilityBut[i]))
            {
                ability[i] = true;
            }
            else
            {
                ability[i] = false;
            }
        }

    }
}

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
    public List<InputableClass> FwrdList;
    public bool Bwrd;
    public List<InputableClass> BwrdList;
    public bool Lwrd;
    public List<InputableClass> LwrdList;
    public bool Rwrd;
    public List<InputableClass> RwrdList;
    public bool up;
    public List<InputableClass> UpList;
    public bool down;
    public List<InputableClass> downList;
    public bool sprint;
    public List<InputableClass> sprintList;
    public bool spark;
    public List<InputableClass> sparkList;
    public float scroll;
    public List<InputableClass> scrollList;
    public bool leftC;
    public List<InputableClass> leftCList;
    public bool rightC;
    public List<InputableClass> rightCList;
    //keep it 1 thru 10, where 10 is menu stuff
    public List<bool> ability = new List<bool>();
    public Dictionary<int,List<InputableClass>> abilityList = new Dictionary<int,List<InputableClass>>();
    // Start is called before the first frame updatex
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
            if(abilityList.TryGetValue(i, out List<InputableClass> aList)){
                for(int j = 0; j < aList.Count; j++)
            {
                aList[j].InputCalled();
            }
            }

            }
            else
            {
                ability[i] = false;
            }
        }


        // Calling inputables
        if (Fwrd)
        {
            for(int i = 0; i < FwrdList.Count; i++)
            {
                FwrdList[i].InputCalled();
            }
        }
        if (Bwrd)
        {
            for (int i = 0; i < BwrdList.Count; i++)
            {
                BwrdList[i].InputCalled();
            }
        }
        if (Lwrd)
        {
            for (int i = 0; i < LwrdList.Count; i++)
            {
                LwrdList[i].InputCalled();
            }
        }
        if (up)
        {
            for (int i = 0; i < UpList.Count; i++)
            {
                UpList[i].InputCalled();
            }
        }
        if (down)
        {
            for (int i = 0; i < downList.Count; i++)
            {
                downList[i].InputCalled();
            }
        }
        if (sprint)
        {
            for (int i = 0; i < sprintList.Count; i++)
            {
                UpList[i].InputCalled();
            }
        }
        if (spark)
        {
            for (int i = 0; i < sparkList.Count; i++)
            {
                sparkList[i].InputCalled();
            }
        }
        if (leftC)
        {
            for (int i = 0; i < leftCList.Count; i++)
            {
                leftCList[i].InputCalled();
            }
        }
        if (rightC)
        {
            for (int i = 0; i < rightCList.Count; i++)
            {
                rightCList[i].InputCalled();
            }
        }
        if (scroll != 0)
        {
            for (int i = 0; i < scrollList.Count; i++)
            {
                scrollList[i].InputCalled();
            }
        }
    }
    /// <summary>
    /// 1 = Fwrd, 2 = Bwrd, 3 = Lwrd, 4 = Rwrd, 5 = Up, 6 = Down, 7 = Sprint, 8 = spark, 9 = leftC, 10 = rightC, 11 = scroll, 12+ = abilites
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="button"></param>
    /// <returns></returns>
    public bool AddInput(InputableClass subject, int button)
    {
        switch (button)
        {
            case 0:
                return false;
            case 1:
                FwrdList.Add(subject);
                break;
            case 2:
                BwrdList.Add(subject);
                break;
            case 3:
                LwrdList.Add(subject);
                break;
            case 4:
                RwrdList.Add(subject);
                break;
            case 5:
                UpList.Add(subject);
                break;
            case 6:
                downList.Add(subject);
                break;
            case 7:
                sprintList.Add(subject);
                break;
            case 8:
                sparkList.Add(subject);
                break;
            case 9:
                leftCList.Add(subject);
                break;
            case 10:
                rightCList.Add(subject);
                break;
            case 11:
                scrollList.Add(subject);
                break;
            default:
                if(abilityList.TryGetValue(button - 12, out List<InputableClass> aList)){
                    aList.Add(subject);
                }
                else{
                    abilityList.Add(button - 12, new List<InputableClass>(){subject});

                }
            break;
        }

        return true;
    }

public bool CheckInput(int button)
    {
        switch (button)
        {
            case 0:
                return false;
            case 1:
                return Fwrd;
            case 2:
                return Bwrd;
            case 3:
                return Lwrd;
            case 4:
                return Rwrd;
            case 5:
                return up;
            case 6:
                return down;
            case 7:
                return sprint;
            case 8:
                return spark;
            case 9:
                return leftC;
            case 10:
                return rightC;
            case 11:
                return scroll > 0;
            default:
                if(button - 12 < ability.Count)
                return ability[button - 12];
                return false;
        }

    }
}

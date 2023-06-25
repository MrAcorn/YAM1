using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBotAbility2 : InputableClass
{
    public GameObject smiteBolt;
    public GameObject RangeObj;
    public float range = 5;
    public List<GameObject> inRange = new List<GameObject>();

    // Start is called before the first frame update
    protected override void Start()
    {
        SphereCollider rangeSphere = RangeObj.GetComponent<SphereCollider>();
        RangeObj.GetComponent<DBA2subscript1>().DBA2 = this;
        rangeSphere.radius = range;
        

    }

    // Update is called once per frame
    protected override void Update()
    {
        
        base.Update();

        if (0 >= cooldown && castable)
        {
            StartCoroutine("Smite");
            cooldown = setCooldown;
        }
    }

    private void Smite(){
        
        if(inRange.Count > 0){
            int target = Mathf.RoundToInt(Random.Range(0, inRange.Count - 1));
            inRange[target].AddComponent<DBA2SmiteDamage>();
        }
    }
}

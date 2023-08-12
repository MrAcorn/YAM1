using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBotAbility2 : InputableClass
{
    private RangeAura RangeObj;
    public GameObject RangeObjPreFab;
    public float range = 5;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        RangeObj = Instantiate(RangeObjPreFab,gameObject.transform).GetComponent<RangeAura>();
        RangeObj.origin = this.gameObject;
        RangeObj.gameObject.transform.localScale = Vector3.one * range/10;
        base.Start();
        

    }

    // Update is called once per frame
    protected override void Update()
    {
        
        base.Update();

        if (0 >= cooldown && castable && RangeObj.inRange.Count != 0)
        {
            StartCoroutine("Smite");
            cooldown = setCooldown;
        }
    }

    private void Smite(){
        
        if(RangeObj.inRange.Count > 0){
            int target = Mathf.RoundToInt(Random.Range(0, RangeObj.inRange.Count - 1));
            DBA2SmiteDamage damageInstance = RangeObj.inRange[target].AddComponent<DBA2SmiteDamage>();
            damageInstance.AssginDamage(1,0,this.gameObject);
            RangeObj.inRange[target].GetComponent<Rigidbody>().velocity = Vector3.zero;
            caller.Call( this.gameObject.name, RangeObj.inRange[target] + " has been smited by the monkey", 2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBotAbility2 : InputableClass
{
    public GameObject smiteBolt;
    private GameObject RangeObj;
    public GameObject RangeObjPreFab;
    public float range = 5;
    public List<GameObject> inRange = new List<GameObject>();

    public SphereCollider rangeSphere;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        RangeObj = Instantiate(RangeObjPreFab,gameObject.transform);
        rangeSphere = RangeObj.GetComponent<SphereCollider>();
        RangeObj.GetComponent<DBA2subscript1>().DBA2 = this;
        rangeSphere.radius = range/10;
        base.Start();
        

    }

    // Update is called once per frame
    protected override void Update()
    {
        
        base.Update();

        if (0 >= cooldown && castable && inRange.Count != 0)
        {
            StartCoroutine("Smite");
            cooldown = setCooldown;
        }
    }

    private void Smite(){
        
        if(inRange.Count > 0){
            int target = Mathf.RoundToInt(Random.Range(0, inRange.Count - 1));
            DBA2SmiteDamage damageInstance = inRange[target].AddComponent<DBA2SmiteDamage>();
            damageInstance.AssginDamage(1,0,this.gameObject);
            caller.Call( this.gameObject.name, inRange[target] + " has been smited by the monkey", 2);
        }
    }
}

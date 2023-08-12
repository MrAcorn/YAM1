using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_SmokeToss : InputableClass
{

    public GameObject RangeObjPreFab;
    public float range = 5;
    [SerializeField] private aimRay aimR;
    [SerializeField] private GameObject bullet;
    public GameObject lockedOn;
    float lastLocked;
    public float inivsTime;
    private RangeAura RangeObj;
    private MOD_Chara charaBase;
    // Start is called before the first frame update
    protected override void Start()
    {
        charaBase = GetComponent<MOD_Chara>();
        RangeObj = Instantiate(RangeObjPreFab, gameObject.transform).GetComponent<RangeAura>();
        RangeObj.origin = this.gameObject;
        RangeObj.gameObject.transform.localScale = Vector3.one * range;
        base.Start();


    }

    public override void InputCalled()
    {

        if (cooldown <= 0 && castable)
        {
            if (charaBase.moving)
            {
                if (lockedOn)
                {
                    SmokeToss();
                }
                else
                {
                    lockedOn = aimR.GetAutoAim(RangeObj.inRange);
                    lastLocked = 0;
                }
            }
            else
            {
                SelfInivs();
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        lastLocked += Time.deltaTime;
        if (lastLocked > 2)
        {
            lockedOn = null;
        }
    }

    private void SmokeToss()
    {
        cooldown = setCooldown;
        MOD_SmokeCan thisBullet = Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity).GetComponent<MOD_SmokeCan>();
        thisBullet.setDir(lockedOn.transform.position);
        thisBullet.follow = lockedOn;
        thisBullet.dmgStat(stats.attack[0] * 0.1f, 0);
        thisBullet.origName = this.gameObject;
    }
    private void SelfInivs(){
        
        if(!gameObject.GetComponent<MOD_Invis>()){
            cooldown = setCooldown;
            MOD_Invis invisEff = gameObject.AddComponent<MOD_Invis>();
            invisEff.targetCStats = gameObject.GetComponent<CombatStats>();
            invisEff.Allignment = 1;
            invisEff.TypeOfInvis(inivsTime,null);
        }
    }
}

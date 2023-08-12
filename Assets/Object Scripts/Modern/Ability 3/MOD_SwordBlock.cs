using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_SwordBlock : InputableClass
{
    [SerializeField] private aimRay aimR;
    public GameObject swordBullet;
    public float swordCastTime;
    public Vector3 castPosition;
    public Vector3 targetPosition;
    public float range = 5;
    public float castTime;
    private float time;
    private MOD_Chara charaBase;
    
     protected override void Start()
    {
        charaBase = GetComponent<MOD_Chara>();
        base.Start();
    }
    public override void InputCalled(){
 if (cooldown <= 0 && castable)
        {
           if (true)
            {
                Sword();
            }
            else
            {
                Block();
            }
        }
    }
    private void Sword(){
        cooldown = setCooldown;
        castPosition = transform.position;
        targetPosition = Vector3.MoveTowards(castPosition, aimR.aimPoint, range);
        time = 0;
        Invoke("swordDashing",0);
        MOD_SwordBullet thisBullet = Instantiate(swordBullet, transform.position, swordBullet.transform.rotation).GetComponent<MOD_SwordBullet>();
        thisBullet.dmgStat(stats.attack[0], 0);
        thisBullet.origName = this.gameObject;
        thisBullet.activeFor = castTime;
        thisBullet.phased = GetComponent<MOD_Phased>();
    }
    private void swordDashing(){
        transform.position = Vector3.Lerp(castPosition, targetPosition, time/castTime);
        time += Time.deltaTime;
        if(time < castTime) Invoke("swordDashing",0);
    }
    private void Block(){}
}

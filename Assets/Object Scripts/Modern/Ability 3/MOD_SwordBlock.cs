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
    public bool hit;
    
     protected override void Start()
    {
        charaBase = GetComponent<MOD_Chara>();
        base.Start();
    }
    public override void InputCalled(){
 if (cooldown <= 0 && castable)
        {
           if (charaBase.moving)
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
        hit = false;
        MOD_SwordBullet thisBullet = Instantiate(swordBullet, transform.position, Quaternion.Euler(transform.rotation.eulerAngles + (Vector3.forward*90))).GetComponent<MOD_SwordBullet>();
        thisBullet.dmgStat(stats.attack[0], 0);
        thisBullet.origName = this.gameObject;
        thisBullet.activeFor = castTime;
        thisBullet.phased = GetComponent<MOD_Phased>();
        thisBullet.SB = this;
    }
    private void swordDashing(){
        transform.position = Vector3.Lerp(castPosition, targetPosition, time/castTime);
        time += Time.deltaTime;
        if(time < castTime) Invoke("swordDashing",0);
        else
        {
            if (hit)
            {
                GetComponent<CCStatus>().applySpeed(0.5f, 0.2f);
            }
            else
            {
                GetComponent<CCStatus>().applyStun(0.5f, false);
            }

        }
    }
    private void Block(){
        GetComponent<MOD_Phased>().PhaseShift();
        stats.SetSheild(stats.stunShield, 0.75f, this);
    }
}

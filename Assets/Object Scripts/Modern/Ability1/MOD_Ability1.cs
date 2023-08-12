using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_Ability1 : InputableClass
{
    [SerializeField] private aimRay aimR;
    [SerializeField] private float aimOffset;
    [SerializeField] private GameObject bullet;
    public int ammo;
    public int magSize;
    public float reloadSpeed;
    private bool pressedDown;
    public override void InputCalled()
    {
        Vector3 hold = Vector3.MoveTowards(transform.position, aimR.aimPoint, aimOffset);
        if (cooldown <= 0 && castable && ammo > 0 && !pressedDown)
        {
            pressedDown = true; 
            cooldown = setCooldown;
            ammo--;
            caller.Call(gameObject.name, "ABA1 - Dummy", 3);

            MOD_AB1Bullet thisBullet = Instantiate(bullet, hold, Quaternion.identity).GetComponent<MOD_AB1Bullet>();
            thisBullet.setDir(aimR.aimPoint);
            thisBullet.dmgStat(stats.attack[0], 0);
            thisBullet.origName = this.gameObject;
        }
        
    }
    protected override void Update(){

        cooldown -= Time.deltaTime;
        if(cooldown < -reloadSpeed){
            ammo = magSize;
        }
        if(!trigger.CheckInput(input)){
            pressedDown = false;
        }
    }
}

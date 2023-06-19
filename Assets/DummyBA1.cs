using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBA1 : BasicAbility1Class
{
    
    [SerializeField] private Camera cam;
    [SerializeField] private aimRay aimR;
    [SerializeField] private float aimOffset;
    [SerializeField] private GameObject bullet;
    public List<string> abilityTags;
    protected void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = 0;
            castable = true;
        }
    }
    protected override void ActivateBA1()
    {
        Vector3 hold = Vector3.MoveTowards(transform.position, aimR.aimPoint, aimOffset);
        if (castable)
        {
            castable = false;
            cooldown = setCooldown;
            caller.Call(gameObject.name, "ABA1 - Dummy", 3);

            BasicObjBullet thisBullet = Instantiate(bullet, hold, Quaternion.identity).GetComponent<BasicObjBullet>();
            thisBullet.setDir(aimR.aimPoint);
            thisBullet.dmgStat(stats.attack[0], 0);
            thisBullet.origName = this.gameObject;
        }
        
    }
}

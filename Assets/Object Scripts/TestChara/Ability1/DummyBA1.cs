using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBA1 : InputableClass
{
    [SerializeField] private aimRay aimR;
    [SerializeField] private float aimOffset;
    [SerializeField] private GameObject bullet;

    public override void InputCalled()
    {
        Vector3 hold = Vector3.MoveTowards(transform.position, aimR.aimPoint, aimOffset);
        if (cooldown <= 0 && castable)
        {
            cooldown = setCooldown;
            caller.Call(gameObject.name, "ABA1 - Dummy", 3);

            TestObjBullet thisBullet = Instantiate(bullet, hold, Quaternion.identity).GetComponent<TestObjBullet>();
            thisBullet.setDir(aimR.aimPoint);
            thisBullet.dmgStat(stats.attack[0], 0);
            thisBullet.origName = this.gameObject;
        }
        
    }
}

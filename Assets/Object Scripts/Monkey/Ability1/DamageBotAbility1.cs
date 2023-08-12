using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBotAbility1 : InputableClass
{
    public GameObject bullet;
    public Vector3 aimOffset;
    // Start is called before the first frame update

    // Update is called once per frame
    protected override void Update()
    {
        
        base.Update();

        if (0 >= cooldown && castable)
        {
            StartCoroutine("ShotBullet");
            cooldown = setCooldown;
        }
    }

        public void ShotBullet()
    {
        Vector3 hold = new Vector3(transform.rotation.x + aimOffset.x, transform.rotation.y + aimOffset.y, 0 + aimOffset.z);
        monkyeBullet thisbullet = Instantiate(bullet, transform.position, Quaternion.Euler(hold)).GetComponent<monkyeBullet>();
        thisbullet.dmgStat(stats.attack[0], 0);
        thisbullet.origName = gameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBot : MonoBehaviour
{
    private Caller caller;
    private InputCollecter inputC;
    private Stats stats;
    private CCStatus ccStatus;
    private CCCounterPlay ccCounterPlay;
    private Rigidbody rb;
    private GeneralMovement gm;
    private CombatStats combatStats;
    private KnockDownRespawn knockDR;
    //
    public GameObject bullet;
    public float timer;
    public Vector3 aimOffset = new Vector3(0, 0, 180);
    // Start is called before the first frame update
    void Start()
    {
        caller = GetComponent<Caller>();
        stats = GetComponent<Stats>();
        ccStatus = GetComponent<CCStatus>();
        rb = GetComponent<Rigidbody>();
        combatStats = GetComponent<CombatStats>();
        knockDR = GetComponent<KnockDownRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 && !knockDR.dead)
        {
            StartCoroutine("ShotBullet");
            timer = 0;
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

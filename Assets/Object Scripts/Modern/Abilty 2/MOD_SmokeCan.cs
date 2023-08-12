using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_SmokeCan : BasicDamageBullet
{
    public Vector3 castPos;
    public GameObject follow;
    public GameObject smokeBomb;
    private float time;
    public float bombSize = 1;
    // Update is called once per frame
    protected override void OnEnable()
    {
        base.OnEnable();
        castPos = transform.position;
        

    }
    void Update()
    {
        time += Time.deltaTime;
        transform.position = Vector3.Lerp(castPos, follow.transform.position, time * 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<TagsBase>(out TagsBase oTags);

        if (other.gameObject != origName && oTags != null &&  oTags.damageable )
        {
            BasicDamage damageInstance = other.gameObject.AddComponent<TestDamage>();
            damageInstance.AssginDamage(bulDamage, 0, origName);
            ColiReport(other.gameObject);
        }
    }

    protected override void Death(){
        MOD_SmokeBomb thisBomb = Instantiate(smokeBomb, transform.position + Vector3.up, Quaternion.identity).GetComponent<MOD_SmokeBomb>();
        thisBomb.gameObject.transform.localScale = Vector3.one * bombSize;
        thisBomb.dmgStat(bulDamage, bulElement);
        thisBomb.origName = origName;
        Destroy(gameObject);
    }
}

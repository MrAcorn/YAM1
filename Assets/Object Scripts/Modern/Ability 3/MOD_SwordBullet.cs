using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_SwordBullet : BasicDamageBullet
{ 
    public float activeFor;
    public float time;
    public MOD_Phased phased;
    // Start is called before the first frame update
    void Update(){
        transform.position = origName.transform.position;
        time += Time.deltaTime;
        Death();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<TagsBase>(out TagsBase oTags);

        if (other.gameObject != origName && oTags != null &&  oTags.damageable )
        {
            phased.ApplyPhaseStack(other.gameObject)
            .ApplyPhaseStack(other.gameObject).ApplyPhaseEffect(other.gameObject.GetComponent<MOD_PhasedEnemy>());
            BasicDamage damageInstance = other.gameObject.AddComponent<TestDamage>();
            damageInstance.AssginDamage(bulDamage, 0, origName);
            ColiReport(other.gameObject);
        }

    }
    protected override void Death()
    {
        if(time > activeFor)
        Destroy(gameObject);
    }
}

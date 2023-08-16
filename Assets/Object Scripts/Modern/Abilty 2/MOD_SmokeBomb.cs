using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_SmokeBomb : BasicDamageBullet
{
    private MOD_Invis invisEff;
    // Start is called before the first frame update
        void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0){
            Death();
        }
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
        //if(other.gameObject == origName && !other.gameObject.GetComponent<MOD_Invis>()){
        if(other.gameObject == origName){ 
            invisEff = other.gameObject.AddComponent<MOD_Invis>();
            invisEff.targetCStats = other.gameObject.GetComponent<CombatStats>();
            invisEff.source = origName;
            invisEff.Allignment = 1;
            invisEff.TypeOfInvis(0,this);

        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject == origName && other.gameObject.GetComponent<MOD_Invis>()){
            invisEff.CleanDeath();
        }
    }
    protected override void Death(){
        if(lifeTime < 0){
            if(invisEff){
                invisEff.CleanDeath();
            }
            Destroy(gameObject);
        }
    }
}

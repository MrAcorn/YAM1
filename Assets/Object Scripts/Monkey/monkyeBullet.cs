using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkyeBullet : BasicDamageBullet
{
    public Vector3 castPos;
    public float range;
    GameObject entityHit;
    // Start is called before the first frame update
    protected void Awake()
    {
        Invoke("Death", 4);
    }

    protected void OnParticleCollision(GameObject other)
    {
        other.TryGetComponent<TagsBase>(out TagsBase oTags);

        if (other != origName && oTags != null && oTags.damageable)
        {
            entityHit = other;
            applyDMG();
        }
    }

    public void applyDMG()
    {
        MonkeyDamage damageInstance = entityHit.AddComponent<MonkeyDamage>();
        damageInstance.AssginDamage(bulDamage, bulElement, origName);
        ColiReport(entityHit);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOD_AB1Bullet : BasicDamageBullet
{
    public Vector3 castPos;
    public float range;
    public float movSpeed;
    // Start is called before the first frame update
    protected override void OnEnable()
    {
        base.OnEnable();
        castPos = transform.position;
        StartCoroutine(MoveAtoB());
        

    }
    private void Start()
    {
        StartCoroutine(rangeCheck());
    }
    IEnumerator MoveAtoB()
    {
        while(transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, movSpeed * Time.deltaTime);
            yield return null;

        }
        
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, (transform.TransformDirection(Vector3.forward) + transform.position), movSpeed * Time.deltaTime);
            yield return null;
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
    }
    private IEnumerator rangeCheck()
    {
        
        while (Vector3.Distance(castPos, transform.position) < range)
        {
            
            yield return null;
        }
        Death();
    }

}

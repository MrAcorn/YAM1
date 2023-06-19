using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamageBullet : MonoBehaviour
{
    [SerializeField] protected Caller call;
    public float lifeTime = 4;
    public GameObject origName;
    public Vector3 target = Vector3.zero;
    public float bulDamage = 10;
    public int bulElement = 0;
    protected TagsBase tags;

    // Start is called before the first frame update
    protected virtual void OnEnable()
    {
        tags = GetComponent<TagsBase>();
        tags.ResetTags();
        tags.bullet = true;
        call = GetComponent<Caller>();
        
    }
    public virtual void setDir(Vector3 Dir)
    {
        target = Dir;
        transform.LookAt(Dir);
    }
    public virtual void dmgStat(float givenDmg, int givenElement)
    {
        bulDamage = givenDmg;
        bulElement = givenElement;
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }
    public virtual void ColiReport(GameObject other)
    {
        call.Call(this.gameObject.name, " death to " + other.name, 3);
        Death();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBotBullet : MonoBehaviour
{
    private Caller call;
    // Start is called before the first frame update
    void Start()
    {
        call = GetComponent<Caller>();
        Invoke("Death", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        DamageBotDamage damageInstance = other.AddComponent<DamageBotDamage>();
        Death();
        call.Call(this.ToString(), "death to " + other.name, 3);
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

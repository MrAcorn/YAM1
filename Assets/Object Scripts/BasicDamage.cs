using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : MonoBehaviour
{
    protected Caller caller;
    protected Stats stats;
    protected CombatStats combatStats;
    [SerializeField] protected ElementalManager eM;

    public float damage = 0;
    public int element = 0;
    // Start is called before the first frame update
     void OnEnable()
    {

        caller = GetComponent<Caller>();
        stats = GetComponent<Stats>();
        combatStats = GetComponent<CombatStats>();
        eM = GetComponent<ElementalManager>();
        //
    }

    public virtual void AssginDamage(float givenDamage, int givenElement, GameObject source)
    {
        eM = GetComponent<ElementalManager>();
        damage += givenDamage;
        element = givenElement;
        eM.ApplyElement((Elements)element, source);
        combatStats.InCombat();
        stats.heath -= damage * (1 - stats.defence[element] / 100);
        Destroy(this);
    }

}

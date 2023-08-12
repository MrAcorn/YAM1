using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : MonoBehaviour
{
    protected Caller caller;
    protected Stats stats;
    public CombatStats AllyCombatStats;
    protected CombatStats EnemCombatStats;
    [SerializeField] protected ElementalManager eM;

    public float damage = 0;
    public Elements element = 0;
    // Start is called before the first frame update
     void OnEnable()
    {

        caller = GetComponent<Caller>();
        stats = GetComponent<Stats>();
        EnemCombatStats = GetComponent<CombatStats>();
        eM = GetComponent<ElementalManager>();
        //
    }

    public virtual void AssginDamage(float givenDamage, Elements givenElement, GameObject source)
    {
        AllyCombatStats = source.GetComponent<CombatStats>();
        EnemCombatStats = GetComponent<CombatStats>();
        eM = GetComponent<ElementalManager>();
        AllyCombatStats.RunTriggers(triggers.AllyPreDamage, this, GetComponent<CombatStats>());
        EnemCombatStats.RunTriggers(triggers.EnemyPreDamage, this, source.GetComponent<CombatStats>());
        damage += givenDamage;
        element = givenElement;
        eM.ApplyElement((Elements)element, source);
        AllyCombatStats.InCombat();
        EnemCombatStats.InCombat();
        stats.TakeDamage(givenDamage,givenElement,false);
        AllyCombatStats.RunTriggers(triggers.AllyPostDamage, this, GetComponent<CombatStats>());
        EnemCombatStats.RunTriggers(triggers.EnemyPostDamage, this, source.GetComponent<CombatStats>());
        Destroy(this);
    }

}

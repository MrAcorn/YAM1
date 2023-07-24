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
    public Elements element = 0;
    // Start is called before the first frame update
     void OnEnable()
    {

        caller = GetComponent<Caller>();
        stats = GetComponent<Stats>();
        combatStats = GetComponent<CombatStats>();
        eM = GetComponent<ElementalManager>();
        //
    }

    public virtual void AssginDamage(float givenDamage, Elements givenElement, GameObject source)
    {
        combatStats = GetComponent<CombatStats>();
        eM = GetComponent<ElementalManager>();
        combatStats.RunTriggers(triggers.PreDamage, this);
        damage += givenDamage;
        element = givenElement;
        eM.ApplyElement((Elements)element, source);
        combatStats.InCombat();
        stats.heath -= damage * (1 - stats.defence[((int)element)] / 100);
        combatStats.RunTriggers(triggers.PostDamage, this);
        Destroy(this);
    }

}

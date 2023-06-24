using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagsBase : MonoBehaviour
{
    public bool damageable;
    public bool playerCharater;
    public bool npc;
    public bool neutral;
    public bool terrain;
    public bool bullet;
    public List<string> others;
    
    public void ResetTags()
    {
        damageable = false;
        playerCharater = false;
        npc = false;
        neutral = false;
        terrain = false;
        bullet = false;
        others.Clear();
    }
}


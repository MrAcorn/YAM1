using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAura : MonoBehaviour
{
    public GameObject origin;
    public List<GameObject> inRange  = new List<GameObject>();
    void OnTriggerEnter(Collider other){
      if(other.gameObject.TryGetComponent<TagsBase>(out var objInRange) &&
       objInRange.damageable &&
       other.gameObject.name != origin.gameObject.name){
            inRange.Add(other.gameObject);
            
      }
    }
    void OnTriggerExit(Collider other){
        if(inRange.Contains(other.gameObject))
        inRange.Remove(other.gameObject); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBA2subscript1 : MonoBehaviour
{
    public DamageBotAbility2 DBA2;
    void OnTriggerEnter(Collider other){
      DBA2.inRange.Add(other.gameObject);  
    }
    void OnTriggerExit(Collider other){
        if(DBA2.inRange.Contains(other.gameObject))
        DBA2.inRange.Remove(other.gameObject); 
    }
}

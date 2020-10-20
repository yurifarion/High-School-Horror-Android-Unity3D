using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMonster : MonoBehaviour
{
   //gm
	private GameObject  monster;
    // Start is called before the first frame update
    void Start()
    {
		monster = GameObject.FindGameObjectWithTag("Monster");
        
    }
	public void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Monster"){
			monster.GetComponent<Monster>().isOnFlashLightTrigger = true;
		}
	}
	public void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Monster"){
			monster.GetComponent<Monster>().isOnFlashLightTrigger = false;
		}
	}
	
}
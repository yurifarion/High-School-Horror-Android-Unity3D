using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
	public GameObject jumpScare_UI;
	
    public void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			jumpScare_UI.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}

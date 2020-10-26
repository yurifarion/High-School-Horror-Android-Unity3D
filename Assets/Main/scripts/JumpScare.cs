using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
	public GameObject jumpScare_UI;
	public GameObject Canvas;
	public void Start(){
		Canvas = GameObject.FindGameObjectWithTag("Canvas");
		jumpScare_UI = Canvas.transform.Find( "JumpScare" ).gameObject;
	}
    public void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			jumpScare_UI.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}

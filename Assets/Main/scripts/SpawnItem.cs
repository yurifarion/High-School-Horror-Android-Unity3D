using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
	public string kindofItem = "none";
	public GameObject pageprefab;
	public GameObject keyprefab;
	
	public void spawnItem(){
		//Spawn gameObjects depending on the TAG
		if(kindofItem == "Key"){
			Instantiate(keyprefab,transform.position, transform.rotation);
		}
		else if(kindofItem == "Page"){
			Instantiate(pageprefab,transform.position, transform.rotation);
		}
	}
}

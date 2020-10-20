using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
  //gm
	private GameObject  _gm;
	public GameObject openDoor_UI;
    // Start is called before the first frame update
    void Start()
    {
		_gm = GameObject.FindGameObjectWithTag("GameManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(_gm.GetComponent<GameManager>().keysfound == 3){
				openDoor_UI.SetActive(true);
			}
		}
	}
	public void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			openDoor_UI.SetActive(false);
		}
	}
	public void GameWin(){
		Debug.Log("GameWin");
	}
}
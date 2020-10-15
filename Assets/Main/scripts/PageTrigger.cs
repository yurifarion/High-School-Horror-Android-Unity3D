using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTrigger : MonoBehaviour
{
  //gm
	private GameObject  _gm;
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
			_gm.GetComponent<GameManager>().isOnPageTrigger_ = true;
			_gm.GetComponent<GameManager>().currentPage = this.gameObject;
		}
	}
	public void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			_gm.GetComponent<GameManager>().isOnPageTrigger_ = false;
			_gm.GetComponent<GameManager>().currentKey = null;
		}
	}
}
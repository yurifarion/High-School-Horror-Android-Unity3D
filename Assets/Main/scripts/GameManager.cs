using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//UI
	public GameObject pickUp_UI;
	public Text keyCounter_txt;
	//controllers
	private int keysfound = 0;
	
	//trigger
	public bool isOnKeyTrigger_ = false;
	public GameObject currentKey = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickUp_UI.SetActive(isOnKeyTrigger_);
    }
	public void pick(){
		if(currentKey != null){
			keysfound++;
			isOnKeyTrigger_ = false;
			Destroy(currentKey);
			keyCounter_txt.text = keysfound+" keys found";
		}
	}
}

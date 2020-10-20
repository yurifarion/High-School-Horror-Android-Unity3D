using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//UI
	public GameObject pickUp_UI;
	public GameObject outro_UI;
	public Text keyCounter_txt;
	//controllers
	public int keysfound = 0;
	public bool isGamePaused = false;
	
	//trigger
	public bool isOnKeyTrigger_ = false;
	public bool isOnPageTrigger_ = false;
	public GameObject currentKey = null;
	public GameObject currentPage = null;
	public int currentPageNumber = 0;
	//Counters
	public int amountOfPagesIngame = 0;
	public int amountOfKeysIngame = 0;
	//pages
	public GameObject page1;
	public GameObject page2;
	public GameObject page3;
	public GameObject page4;
	public GameObject page5;
	public GameObject page6;
	
	
	//Audio from pages
	
    // Start is called before the first frame update
    void Start()
    {
        initSpawns();
    }

    // Update is called once per frame
    void Update()
    {
        pickUp_UI.SetActive(isOnKeyTrigger_ || isOnPageTrigger_);
		if(keysfound == 3){
			outro_UI.SetActive(true);
		}
    }
	void initSpawns(){
		GameObject[] spawns = GameObject.FindGameObjectsWithTag("SpawnItem");
		
		while(amountOfPagesIngame < 6 || amountOfKeysIngame < 3 ){
			
			foreach(GameObject i in spawns){
				int rand = Random.Range(1,5);
				if(amountOfPagesIngame < 6 && rand == 2 && i.GetComponent<SpawnItem>().kindofItem == "none"){
					i.GetComponent<SpawnItem>().kindofItem = "Page";
					i.GetComponent<SpawnItem>().spawnItem();
					amountOfPagesIngame++;
				}
				if(amountOfKeysIngame < 3 && rand == 3 && i.GetComponent<SpawnItem>().kindofItem == "none"){
					i.GetComponent<SpawnItem>().kindofItem = "Key";
					i.GetComponent<SpawnItem>().spawnItem();
					amountOfKeysIngame++;
				}
			}
		}
	}
	public void closePage(){
		page1.SetActive(false);
		page2.SetActive(false);
		page3.SetActive(false);
		page4.SetActive(false);
		page5.SetActive(false);
		page6.SetActive(false);
	}
	public void pick(){
		if(currentKey != null){
			keysfound++;
			isOnKeyTrigger_ = false;
			Destroy(currentKey);
			keyCounter_txt.text = keysfound+" keys found";
		}
		else if(currentPage != null){
			currentPageNumber++;
			isOnPageTrigger_ = false;
			Destroy(currentPage);
			switch(currentPageNumber){
				case 1:
					//Change audio clip and play
					page1.SetActive(true);
					isGamePaused = true;
					break;
				case 2:
					//Change audio clip and play
					page2.SetActive(true);
					isGamePaused = true;
					break;
				case 3:
					//Change audio clip and play
					page3.SetActive(true);
					isGamePaused = true;
					break;
				case 4:
					//Change audio clip and play
					page4.SetActive(true);
					isGamePaused = true;
					break;
				case 5:
					//Change audio clip and play
					page5.SetActive(true);
					isGamePaused = true;
					break;
				case 6:
					//Change audio clip and play
					page6.SetActive(true);
					isGamePaused = true;
					break;
				 default:
				break;
			}
		}
	}
}

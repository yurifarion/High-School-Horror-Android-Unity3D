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
	//JumpScare Spawn
	public GameObject monsterprefab;
	public Transform spawnPosition1;
	public Transform spawnPosition2;
	public Transform spawnPosition3;
	public Transform spawnPosition4;
	public Transform spawnPosition5;
	public Transform spawnPosition6;
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
		spawnJumpScare();
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
	void spawnJumpScare(){
		int rand = Random.Range(1,6);
		switch(rand)
		{
			case 1: 
			Instantiate(monsterprefab,spawnPosition1.position,spawnPosition1.rotation);
				break;
			case 2:
			Instantiate(monsterprefab,spawnPosition2.position,spawnPosition2.rotation);
				break;
			case 3:
			Instantiate(monsterprefab,spawnPosition3.position,spawnPosition3.rotation);
				break;
			case 4:
			Instantiate(monsterprefab,spawnPosition4.position,spawnPosition4.rotation);
				break;
			case 5:
			Instantiate(monsterprefab,spawnPosition5.position,spawnPosition5.rotation);
				break;
			case 6:
			Instantiate(monsterprefab,spawnPosition6.position,spawnPosition6.rotation);
				break;
			default:
			Instantiate(monsterprefab,spawnPosition6.position,spawnPosition6.rotation);
			break;
			
			
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

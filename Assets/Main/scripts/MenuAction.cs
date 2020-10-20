using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour
{
	public GameObject music_on;
	public GameObject music_off;
	public bool isMusicOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	void Update(){
		if(isMusicOn && music_on != null){
			music_on.SetActive(true);
			music_off.SetActive(false);
			AudioListener.volume = 1;
		}
		if(!isMusicOn && music_off != null){
			music_on.SetActive(false);
			music_off.SetActive(true);
			AudioListener.volume = 0;
		}
	}
	public void goToMainMenu(){
		Application.LoadLevel("Menu");
	}
	public void goToGame(){
		Application.LoadLevel("MainLevel");
	}
	public void Quit(){
		Application.Quit();
	}
	public void ToggleMusic(){
		isMusicOn =  !isMusicOn;
	}
}

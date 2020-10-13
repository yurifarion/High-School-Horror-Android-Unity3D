using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
	public Light f_Light;
	public bool isFlashlightOn = true;
	public float battery = 100f;
	public Text battery_UI;
	
	public float starttime;
	public float timeOfBatteryLeft;
	
	public AudioSource flash_source;
	public AudioClip flash_clip;
	
    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
		timeOfBatteryLeft = ((starttime + battery) - Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        FlashControl();
		//batteryControl();
		//battery_UI.text = "Battery:"+timeOfBatteryLeft;
    }
	
	void FlashControl(){
		
		if(Input.GetKeyDown(KeyCode.F)){
			isFlashlightOn = !isFlashlightOn;
			//play the sourd
			//flash_source.clip = flash_clip;
			//flash_source.Play();
		}
		if(isFlashlightOn && timeOfBatteryLeft > 0){
			f_Light.intensity = 1;
		}else{
			f_Light.intensity = 0;
		}
	}
	void batteryControl(){
		if((Time.time < starttime + battery) && isFlashlightOn){
			timeOfBatteryLeft = ((starttime + battery) - Time.time);
		}else{
			isFlashlightOn = false;
		}
		
	}
	public void on_Off(){
		isFlashlightOn = !isFlashlightOn;
			//play the sourd
			//flash_source.clip = flash_clip;
			//flash_source.Play();
	}
	public void Addbattery(float n){
		starttime = (((starttime + battery) - Time.time) +n);
	}
}

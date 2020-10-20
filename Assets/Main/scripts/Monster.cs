using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
	public GameObject player;
	public Transform player_transform;
	
	public float facePlayerfactor = 20f;
	public bool inView;
	public bool isOnFlashLightTrigger = false;
	public bool nearPlayer;
	public float distancePlayer = 12f;
	
	
	public GameObject cube;
	public Transform cube_transform;
	public Vector3 spawnOrigin;
	public float distanceRayMax;
	
	public float spawnRate =80f;
	public float nextTeleport = 10f;
	public float currentTime;
	
	public float danger = 0f;
	public float dangertemp;
	public float pointInTime_Damage;
	public float pointInTime_health;
	public float lifeDuration = 10f;
	public bool onDanger = false;
	
	public Image deathscreen;
	public float alpha;
	public float deathTime;
	
    // Start is called before the first frame update
    void Start()
    {
        nextTeleport = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
		FacePlayer();
		Damage();
        currentTime = Time.time;
		
		RaycastHit hit;
		 if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit"+hit.transform.gameObject.tag);
        }
		
		inView = Vector3.Dot(Vector3.forward,player_transform.InverseTransformPoint(transform.position)) > 0;
		
		spawnOrigin.Set(cube_transform.position.x,cube_transform.position.y,cube_transform.position.z);
		
		if( !(nearPlayer || inView)){
			if(currentTime > nextTeleport){
				transform.position = new Vector3(Random.Range(spawnOrigin.x - distanceRayMax,spawnOrigin.x + distanceRayMax),-0.59f,Random.Range(spawnOrigin.z - distanceRayMax,spawnOrigin.z + distanceRayMax));
				nextTeleport += spawnRate;
			}
		}
		
		if(Vector3.Distance(transform.position, player_transform.position) <= distancePlayer){
			nearPlayer = true;
			//if(!GetComponent<AudioSource>().isPlaying && inView){
			//	GetComponent<AudioSource>().Play();
			//}
		}else{
			nearPlayer = false;
		}
    }
	void FacePlayer(){
		Vector3 diretion = (player_transform.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation( new Vector3(diretion.x,0,diretion.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerfactor);
	}
	void Damage(){
		if(nearPlayer && inView && !onDanger){
			onDanger = true;
			dangertemp = danger;
		}
		if(onDanger && (!nearPlayer || ! inView)){
			onDanger = false;
			dangertemp = danger;
		}
		if(onDanger && pointInTime_Damage <= lifeDuration){
			danger = Mathf.Lerp(dangertemp,10, pointInTime_Damage/lifeDuration);
			pointInTime_Damage += Time.deltaTime;
			if(pointInTime_health > 0){
				pointInTime_health -= Time.deltaTime;
			}
		}
		if(!onDanger && pointInTime_health <= lifeDuration){
			danger = Mathf.Lerp(dangertemp,0,pointInTime_health/lifeDuration);
			pointInTime_health += Time.deltaTime;
			if(pointInTime_Damage > 0){
				pointInTime_Damage -= Time.deltaTime;
			}
		}
		if(pointInTime_Damage > lifeDuration){
			Cursor.lockState = CursorLockMode.None;
			Application.LoadLevel("GameOver");
			
		}
		if(danger >= (lifeDuration -0.1f)){
			Cursor.lockState = CursorLockMode.None;
			Application.LoadLevel("GameOver");
		}
		alpha = danger/lifeDuration;
		deathscreen.color = Color.red;
		deathscreen.canvasRenderer.SetAlpha(alpha);
		
	}
}
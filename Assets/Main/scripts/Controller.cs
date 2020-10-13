using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public float walkspeed = 2.5f;
	public float runspeed = 6f;
	
	public float rotationX;
	public float rotationY;
	
	public AudioSource _audiosource;
	public AudioClip   walkaudio;
	CharacterController characterController;
	
	//Touch Controls
	public bl_Joystick movement_joystick;
	public bl_Joystick camera_joystick;
	
	public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
		_audiosource = this.GetComponent<AudioSource>();
		//Cursor.lockState = CursorLockMode.Locked;
		_audiosource.clip = walkaudio;
    }

    // Update is called once per frame
    void Update()
    {
        FPSCamera();
		PlayerControls();
		//quit
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
    }
	void PlayerControls(){
		if(movement_joystick.Horizontal != 0f || movement_joystick.Vertical != 0){
			float hInput = movement_joystick.Horizontal;
			float vInput = movement_joystick.Vertical;
			
			Vector3 fwdMovement = Vector3.zero;
			Vector3 rightMovement = Vector3.zero;
			_audiosource.pitch = 0.7f;
			
			float speed = walkspeed;
			if(characterController.isGrounded == true){
				fwdMovement = this.transform.forward * vInput;
				rightMovement = this.transform.right * hInput;
			}
			if(Input.GetButton("Run")){
				speed = runspeed;
				_audiosource.pitch = 1f;
			}
			
			if(!_audiosource.isPlaying){
				_audiosource.Play();
			}
			
			characterController.SimpleMove(Vector3.ClampMagnitude(fwdMovement + rightMovement, 1f)* speed);
		}
		else{
			_audiosource.Stop();
		}
	}
	void FPSCamera(){
		rotationX += camera_joystick.Horizontal * 0.70f;
		rotationY += camera_joystick.Vertical * 0.70f;
		
		rotationX = AngleCorrection(rotationX,-360,360);
		rotationY = AngleCorrection(rotationY,-70,90);
		
		Quaternion xQuat = Quaternion.AngleAxis(rotationX,Vector3.up);
		Quaternion yQuat = Quaternion.AngleAxis(rotationY,-Vector3.right);
		
		Quaternion finalQuat = Quaternion.identity * xQuat * yQuat;
		
		cam.transform.localRotation = Quaternion.Lerp(cam.transform.localRotation, finalQuat, Time.deltaTime * 20f);
		
	}
	float AngleCorrection(float angle,float min,float max){
		if(angle > 360){
			angle -= 360;
		}
		if(angle < -360){
			angle += 360;
		}
		
		return Mathf.Clamp(angle,min,max);
	}
}

using UnityEngine;
using System.Collections;

public class KikyScripts : MonoBehaviour {

	Animator myAnimator;
	public float speed = 10.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	CharacterController controller;
		float currSpeed, Param1;
		bool Param2, Param3;
	void Start () {
		controller = GetComponent<CharacterController>();
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Param1 = 0;
		Param2 = false;
		Param3 = false;
		if(controller.isGrounded){
			currSpeed = speed;
		}
		if(Input.GetKey(KeyCode.LeftShift)){
			Param2 = true;
			currSpeed = speed / 2;
		}
		if(Input.GetKey(KeyCode.LeftControl)){
			Param3 = true;
			Param1 = Mathf.Abs(Input.GetAxis("Vertical"));
			transform.Rotate(0, Input.GetAxis("Horizontal"),0);

			myAnimator.SetFloat("Speed",Param1);
			myAnimator.SetBool("Shift",Param2);
			myAnimator.SetBool("Attack",Param3);
			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= currSpeed;
			if(Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
				Param1 = 0.2f;
			}
		}
		if(!myAnimator.IsInTransition(0)){
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
		}
	}

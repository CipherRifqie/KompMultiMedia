﻿using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to change the pitch of an Audio Source according to the 
 * speed of the object's animator component
 */ 
public class ChangePitch : MonoBehaviour{

	// Float variable for incrementing the Animation speed
	public float accel = 0.05f;

	// Float for keeping speed bottom limit;
	public float minSpeed = 0.0f;

	// Float for keeping speed top limit;
	public float maxSpeed = 2.0f;

	// Float for the ratio between animation speed and sound pitch. 
	public float animationSoundRatio = 1.0f;

	// Float for keeping the animation's speed
	private float speed = 0.0f;

	// A variable for accessing the object's Animator component
	private Animator animator;

	// A variable for accessing the object's AudioSource component
	private AudioSource audioSource;

	/* ----------------------------------------
	 * At Start, assign the object's Animator component to animator, assign AudioSource component to audioSource,
	 * get the animation speed and call the AccelRocket function to adjust the audio pitch without accelerating it
	 */ 
	void Start(){
		// Set Animator component as 'animator'
		animator = 	GetComponent<Animator>();
		// Set AudioSource component as 'audioSource'
		audioSource = GetComponent<AudioSource>();
		// Set the current animator's speed as 'speed'
		speed = animator.speed;
		// Call AccelRocket() function to adjust sound to initial Animator's speed
		AccelRocket (0f);
	}	

	/* ----------------------------------------
	 * Whenever keys '1' and '2' are pressed on the alphanumeric keyboard, 
	 * call AccelRocket() to readjust speed 
	 */
	void Update(){
		if (Input.GetKey (KeyCode.Alpha1))
			// IF key '1' is pressed, THEN call AccelRocket to increase speed 
			AccelRocket(accel);
		
		if (Input.GetKey (KeyCode.Alpha2))
			// IF key '2' is pressed, THEN call AccelRocket to decrease speed
			AccelRocket(-accel);
	}

	/* ----------------------------------------
	 * A function that receives float value to be summed   
	 * to speed 
	 */
	public void AccelRocket(float accel){
		// Increment 'speed' with 'accel'
		speed += accel;
		// Clamp the new speed value to minimum and maximum allowed.
		speed = Mathf.Clamp(speed,minSpeed,maxSpeed);
		// Clamp 'speed' variable to avoid negative numbers and set the Animator's speed to that value 
		animator.speed = speed = Mathf.Clamp (speed, 0, maxSpeed);
		// A variable for keeping the new sound pitch: the animator speed multiplied by the animation/sound ratio
		float soundPitch = animator.speed * animationSoundRatio;
		// Update AudioSource pitch with absolute value of 'soundPitch'
		audioSource.pitch = soundPitch;
	}
}

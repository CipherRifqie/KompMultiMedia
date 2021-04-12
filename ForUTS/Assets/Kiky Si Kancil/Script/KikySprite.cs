using UnityEngine;
using System.Collections;

public class KikySprite : MonoBehaviour {

	public int Speed, Jump;
	Animator animator;
	Rigidbody2D rigid2d;
	Vector3 temp, firstScale;
	bool onGround;
	float keyValue;

	// Use this for initialization
	void Start () {
		firstScale = transform.localScale;
		animator = GetComponent<Animator>();
		rigid2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		keyValue = Input.GetAxis("Horizontal");
		if (keyValue!=0){
			animator.SetFloat("Speed", Mathf.Abs(keyValue));
			transform.Translate(Speed * keyValue * Vector3.right * Time.deltaTime);
			ChangeFacing(keyValue);
		}
		if (onGround && Input.GetKeyUp(KeyCode.Space)){
			onGround = false;
			rigid2d.AddForce(Vector3.up * Jump);
		}
		if (rigid2d.velocity.y == 0){
			onGround = true;
		}
	}

	void ChangeFacing(float value){
		temp = firstScale;
		if (value > 0){
			transform.localScale = temp;
		} else {
			temp.x = temp.x * -1;
			transform.localScale = temp;
		}
	}
}

using UnityEngine;
using System.Collections;

public class KikyPower : MonoBehaviour {

	public GameObject TelekinetikBall;
	public GameObject SpawnPoint;
	GameObject temp;
	float scale = 1, maxscale = 10;

	// Use this for initialization
	void Start () {
		TelekinetikBall.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftControl)){
			scale = 0;
		}
		if (Input.GetKey(KeyCode.LeftControl)){
			if (scale <= maxscale){
				scale += 0.1f;
			}
		}
		if (Input.GetKeyUp(KeyCode.LeftControl)){
			if (temp == null){
				temp = (GameObject) GameObject.Instantiate(TelekinetikBall, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
				temp.transform.localScale = new Vector3(scale, scale, scale);
				Destroy(temp,2);
			}
		}
		if (temp){  
			temp.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);  
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lean.Touch;

public class TestScript : MonoBehaviour {
	public int inputMagnitude;
	public int verticalMagnitude;
	public int horizontalMagnitude;
	public int shootIndex;
	public int isStopRU;
	public int isStopLU;
	private Animator anim;
	public Transform arms;
	public float speed = 15f;
//	Quaternion temp = Quaternion.Inverse(Quaternion.identity);
//	Quaternion temp2 = Quaternion.Inverse(Quaternion.identity);
	private bool walked = false;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Fixedupdate () {

	}

	void Update () {
//		//Debug.Log (anim.GetCurrentAnimatorStateInfo (0).fullPathHash);
//		if (Input.GetAxis("LeftAnalogVertical") <= -1.0f) {
//			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
//			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 1.0f);
//		} else if (Input.GetAxis("LeftAnalogVertical") <= 0.0f && Input.GetAxis("LeftAnalogVertical") >= -1.0f) {
//			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
//		}
//
//		if (Input.GetAxis("LeftAnalogVertical") >= 1.0f) {
//			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
//			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, -1.0f);
//		} else if (Input.GetAxis("LeftAnalogVertical") >= 0.0f && Input.GetAxis("LeftAnalogVertical") <= 1.0f) {
//			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
//		}
//		if (Input.GetAxis("LeftAnalogHorizontal") <= -1.0f) {
//			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
//			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, -1.0f);
//		} else if (Input.GetAxis("LeftAnalogHorizontal") <= 0.0f && Input.GetAxis("LeftAnalogHorizontal") >= -1.0f) {
//			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
//		}
//		if (Input.GetAxis("LeftAnalogHorizontal") >= 1.0f) {
//			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
//			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 1.0f);
//		} else if (Input.GetAxis("LeftAnalogHorizontal") >= 0.0f && Input.GetAxis("LeftAnalogHorizontal") <= 1.0f) {
//			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
//		}
//		if (Input.GetButton("AButton")) {
//			anim.SetBool (anim.GetParameter (shootIndex).nameHash, true);
//		} else {
//			anim.SetBool (anim.GetParameter (shootIndex).nameHash, false);
//		}
//		temp.eulerAngles += new Vector3(0f, Mathf.Floor(Input.GetAxis("RightAnalogHorizontal")) * speed, 0f);
//		temp2.eulerAngles += new Vector3 (Mathf.Clamp(Input.GetAxis("RightAnalogVertical") * speed, -45.0f, 60f), 0f, 0f);
//		arms.rotation = temp2;
//		transform.rotation = temp;
		if (Input.GetKey (KeyCode.W)) {
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 1.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
			walked = true;
		} else if (!Input.GetKey(KeyCode.W) && walked) {
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
			walked = false;
		}
	}
}
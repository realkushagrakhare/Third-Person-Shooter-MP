using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {
	public int inputMagnitude;
	public int verticalMagnitude;
	public int horizontalMagnitude;
	public int walkStartAngle;
	public int walkStopAngle;
	public int shootIndex;
	public int isStopRU;
	public int isStopLU;
	public int horizAngle;
	public int vertAngle;
	public int isSprint;
	public Transform arms;
	public float speed = 15f;
	public float sensitivity = 1f;
	public float yAimOffset;
	public float xAimOffset;

	private Animator anim;
	private float previousXRot = -1.0f;
	private float previousYRot = -1.0f;

	private bool walked = false;
	private bool walkedBack = false;
	private bool walkedLeft = false;
	private bool walkedRight = false;
	private bool isSprinting = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) {
			anim.SetBool (anim.GetParameter (isSprint).nameHash, true);
			isSprinting = true;
		} else if (!Input.GetKey (KeyCode.LeftShift) && isSprinting) {
			anim.SetBool (anim.GetParameter (isSprint).nameHash, false);
			isSprinting = false;
		}
		if (Input.GetKey (KeyCode.W) && !isSprinting) {
			anim.SetFloat (anim.GetParameter (walkStartAngle).nameHash, 0.0f);
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 1.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
			walked = true;
		} else if (!Input.GetKey(KeyCode.W) && walked) {
			anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, 0.0f);
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
			walked = false;
		}

		if (Input.GetKey (KeyCode.S) && !isSprinting) {
			anim.SetFloat (anim.GetParameter (walkStartAngle).nameHash, 180.0f);
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, -1.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
			walkedBack = true;
		} else if (!Input.GetKey(KeyCode.S) && walkedBack) {
			anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, 180.0f);
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
			anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
			walkedBack = false;
		}

		if (Input.GetKey (KeyCode.D) && !isSprinting) {
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 1.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
			walkedRight = true;
		} else if (!Input.GetKey(KeyCode.D) && walkedRight) {
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
			walkedRight = false;
		}

		if (Input.GetKey (KeyCode.A) && !isSprinting) {
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, -1.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
			walkedLeft = true;
		} else if (!Input.GetKey (KeyCode.A) && walkedLeft) {
			anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
			anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
			walkedLeft = false;
		}

		if (Input.GetMouseButton (0)) {
			anim.SetBool (anim.GetParameter (shootIndex).nameHash, true);
		} else {
			anim.SetBool (anim.GetParameter (shootIndex).nameHash, false);
		}

		if (Input.GetAxis ("Vertical") != previousYRot && !isSprinting) {
			yAimOffset += Input.GetAxis ("Vertical") * sensitivity;
			anim.SetFloat (anim.GetParameter (vertAngle).nameHash, yAimOffset);
			previousYRot = Input.GetAxis ("Vertical");
		} 

		transform.Rotate (0f, Input.GetAxis("Horizontal") * sensitivity, 0f);
	}
}
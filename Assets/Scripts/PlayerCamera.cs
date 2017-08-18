using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	private const float Y_ANGLE_MIN = -500.0f;
	private const float Y_ANGLE_MAX = 500.0f;

	public Transform lookAt;
	public Transform camTransform;
	public float sensitivity;

	private float distance = 2.5f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;

	private void start() {
		camTransform = transform;
	}

	private void Update() {
		currentX += Input.GetAxis("Horizontal");
		currentY += Input.GetAxis("Vertical");

		currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
	}

	private void LateUpdate() {
		Vector3 dir = new Vector3(1f, 0.1f, -distance);
		Quaternion rotation = Quaternion.Euler(-currentY * sensitivity, currentX * sensitivity, 0);
		camTransform.position = lookAt.position + rotation * dir;

		camTransform.LookAt(lookAt.position);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crosshair : MonoBehaviour {

	void Start () {
		GetComponent<Image> ().rectTransform.localPosition = new Vector3 (Screen.width/2.0f, Screen.height/2.0f, 0f);
	}
}

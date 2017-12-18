using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rtnHeight : MonoBehaviour {

	public Slider slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Mathf.Clamp(transform.position.y, slider.minValue, slider.maxValue);
	}
}

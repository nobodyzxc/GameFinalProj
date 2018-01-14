﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class setRoute : MonoBehaviour {
	StreamWriter writer;
	bool fileOpen = false;
	int rec_gap = 0;
	int ring_gap = 30;
	int ring_show_gap = 10;

	bool SETROUTE = false;
	bool ENABLE = true;
	public GameObject coin;
	public GameObject ring;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

		print (SceneManager.GetActiveScene ().name);

		string path = "Assets/routes/" + SceneManager.GetActiveScene ().name + ".txt";
		//Write some text to the test.txt file

		if (ENABLE && SETROUTE) {
			writer = new StreamWriter (path, true);
			fileOpen = true;
		} else if(ENABLE){
			/* generate rings , balls */
			int counter = 0;
			StreamReader reader = new StreamReader (path);
			while (true) {
				var str = reader.ReadLine ();
				if (str == null)
					break;
				var parts = str.Split (' ');
				Vector3 pos = new Vector3 (float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
				Quaternion rot = Quaternion.Euler(float.Parse(parts[3]), float.Parse(parts[4]), float.Parse(parts[5]));
				if (counter == ring_show_gap)
					Instantiate (ring, pos, rot);
				else
					Instantiate (coin, pos , rot);
				counter++;
				counter %= ring_gap;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha1)) {
			writer.Close ();
			print ("close file");
		}
		if (GameObject.Find("Player").GetComponent<jump>().state == 2 && SETROUTE) {
			if (rec_gap == 0) {
				rec_gap = 3;
				writer.WriteLine (player.transform.position.x + " " + player.transform.position.y + " " + player.transform.position.z
					+ " " + player.transform.rotation.x + " " + player.transform.rotation.y + " " + player.transform.rotation.z);
				print ("write file");
			}
			rec_gap--;
		}
		if (GameObject.Find("Player").GetComponent<jump>().state > 4 && fileOpen && SETROUTE) {
			fileOpen = false;
			writer.Close();
			print ("close file");
		}
	}
}

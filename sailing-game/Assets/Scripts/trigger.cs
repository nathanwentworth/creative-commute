﻿using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

	public GameObject canvas;
	public GameObject book;
	public GameObject mainMenu;

	public BoatControl BoatControl;
	public dialogue dialogue;

	private float alphaTimer;
	private bool startTimer;

	private int activateT4;

	public CanvasGroup fadeCanvasGroup;

	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject trigger4;

	private bool textDisp;

	// Use this for initialization
	void Start () {
		activateT4 = 0;
		BoatControl.inputEnabled = false;
		BoatControl.boatSpeedSet = 0;
	}

	void Update() {
		if (startTimer) {
			alphaTimer += Time.deltaTime;
	    	fadeCanvasGroup.alpha -= speed * Time.deltaTime;
		}
		if (alphaTimer >= 2) {
			textDisp = true;
			canvas.GetComponent<Animator>().SetBool("textDisplay", textDisp);
			mainMenu.SetActive(false);
			startTimer = false;
			alphaTimer = 0;
		}

		if (activateT4 == 3) {
			trigger4.SetActive(true);
			activateT4 = 0;
		}
	}

	public void GameStart() {
		startTimer = true;
		// dialogue.S1();
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "trigger-1") {
			activateT4++;
			BoatControl.inputEnabled = false;
			BoatControl.boatSpeedSet = 0;
			book.SetActive(true);
			Debug.Log("trigger 1 activated");
			textDisp = true;
			Debug.Log(textDisp);
			canvas.GetComponent<Animator>().SetBool("textDisplay", textDisp);
			dialogue.K1();
			Destroy(target.gameObject);
		}
		if (target.gameObject.tag == "trigger-2") {
			activateT4++;
			BoatControl.inputEnabled = false;
			BoatControl.boatSpeedSet = 0;
			book.SetActive(true);
			Debug.Log("trigger 2 activated");
			textDisp = true;
			canvas.GetComponent<Animator>().SetBool("textDisplay", textDisp);
			dialogue.V1();
			Destroy(target.gameObject);
		}
		if (target.gameObject.tag == "trigger-3") {
			activateT4++;
			BoatControl.inputEnabled = false;
			BoatControl.boatSpeedSet = 0;
			book.SetActive(true);
			Debug.Log("trigger 3 activated");
			textDisp = true;
			canvas.GetComponent<Animator>().SetBool("textDisplay", textDisp);
			dialogue.B1();
			Destroy(target.gameObject);
		}
		if (target.gameObject.tag == "trigger-4") {
			BoatControl.inputEnabled = false;
			BoatControl.boatSpeedSet = 0;
			book.SetActive(true);
			Debug.Log("trigger 4 activated");
			textDisp = true;
			canvas.GetComponent<Animator>().SetBool("textDisplay", textDisp);
			dialogue.K1();
			Destroy(target.gameObject);
		}
	}
	public void ClosePanel() {
		Debug.Log("cool");
		textDisp = false;
		canvas.GetComponent<Animator>().SetBool("textDisplay", textDisp);
		BoatControl.inputEnabled = true;
		BoatControl.boatSpeedSet = 0;
	}
}
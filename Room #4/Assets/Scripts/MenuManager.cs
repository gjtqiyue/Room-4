using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public AudioSource aud;
	public Button startButton;
	public Text startText;
	public Text titleText;

	public bool menuEnabled = false;

	Animator anim;

	void Start () {
		menuEnabled = true;
		aud = GetComponent <AudioSource> ();
		startButton = GetComponent <Button> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (titleText.color.a == 0) {
			Destroy (titleText);
			Destroy (startText);
			menuEnabled = false;
		}
	}

	public void enterButton () {
		aud.Play ();

		anim.SetTrigger ("Start");
	}



}

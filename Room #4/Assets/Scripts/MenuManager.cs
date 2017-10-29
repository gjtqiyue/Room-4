using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public AudioSource aud;
	public Button startButton;
	public Text startText;
	public Text titleText;

	Animator anim;

	void Start () {
		aud = GetComponent <AudioSource> ();
		startButton = GetComponent <Button> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enterButton () {
		aud.Play ();

		anim.SetTrigger ("Start");

	}

}

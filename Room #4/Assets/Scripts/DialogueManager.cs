using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	DialogueParser parser;

	public MenuManager menu;
	public Animator anim;

	public string dialogue, characterName, day;
	public int lineNum;
	string[] options;
	public float delayTime = 0.3f;
	List<Button> buttons = new List<Button> ();
	//not sure if I need it
	public bool playerTalking;
	public bool hasChoice = false;

	public Text dialogueBox;
	public Text dayBox;
	public Text nameBox;
	public GameObject choiceBox;
	public AudioSource aud;
	public AudioClip typeSound;

	void Start () {
		dialogue = "";
		characterName = "";
		day = "";
		playerTalking = false;
		parser = GameObject.Find ("DialogueParser").GetComponent<DialogueParser> ();
		lineNum = 0;
		menu = GetComponent<MenuManager> ();
		anim.GetComponent<Animator> ();
		aud.GetComponent <AudioSource> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Y) && playerTalking == false && menu.menuEnabled == false) {

			ShowDialogue();



			lineNum++;


		}

		UpdateUI ();
	}

	public void ShowDialogue () {
		ParseLine ();
	}

	void ParseLine () {
		if (parser.GetName (lineNum) == "Day") {
			playerTalking = false;
			ClearText ();
			day = parser.GetContent (lineNum);
			ShowDay ();
		}
		else if (parser.GetName (lineNum) != "Player" && parser.GetName (lineNum) != "Day") {
			playerTalking = false;
			characterName = parser.GetName (lineNum);
			dialogue = parser.GetContent (lineNum);
			//dialogue = dialogue.Replace ('$', '\n');
			StartCoroutine (TypeWriterEffect());
		} else {
			playerTalking = true;
			options = parser.GetOptions (lineNum);
			CreateButtons ();
		}
	}

	void CreateButtons() {
		for (int i = 0; i < options.Length; i++) {
			hasChoice = true;
			GameObject button = (GameObject)Instantiate (choiceBox);
			Button b = button.GetComponent<Button> ();
			ChoiceButton cb = button.GetComponent<ChoiceButton> ();
			cb.SetText (options [i].Split (':') [0]);
			cb.option = options [i].Split (':') [1];
			cb.box = this;
			b.transform.SetParent (this.transform);
			b.transform.localPosition = new Vector3 (-200 + (i*400), -100);
			b.transform.localScale = new Vector3 (1, 1, 1);
			buttons.Add (b);
		}
	}

	void UpdateUI () {
		if (!playerTalking) {
			ClearButtons ();
		}




		//dialogueBox.text = dialogue;
		nameBox.text = characterName;


	}

	void ClearButtons () {
		for (int i = 0; i < buttons.Count; i++) {
			//print ("Clearing buttons");
			Button b = buttons [i];
			buttons.Remove (b);
			Destroy (b.gameObject);
		}
	}

	public void ClearText () {
		dialogue = "";
		characterName = "";
	}

	IEnumerator TypeWriterEffect(){
		for (int i=0; i<dialogue.Length+1; i++) {
			dialogueBox.text = dialogue.Substring (0, i);
			aud.clip = typeSound;
			aud.Play ();
			yield return new WaitForSeconds (delayTime);
		}
		StopCoroutine (TypeWriterEffect ());
	}

	public void ShowDay (){
		dayBox.text = day;
		anim.Play ("DayFade");
	}
}

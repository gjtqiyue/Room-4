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
    public int pillTaken = 0;
	string[] options;
	public float delayTime = 0.3f;
	List<Text> buttons = new List<Text> ();
	//not sure if I need it
	public bool playerTalking;
	public bool hasChoice = false;

	public Text dialogueBox;
	public Text dayBox;
	public Text nameBox;
	public GameObject choiceBox;
	public AudioSource aud;
	public AudioClip typeSound;

    private bool intro = false;

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
        if (menu.menuEnabled == false && menu.gameStart == true) {
            if (intro == false)
            {
                dialogueBox.text = "Press Y to start";
                intro = true;
            }

            // Pill ending condition
            if (lineNum == 184)
            {
                if (pillTaken < 4)
                {
                    lineNum = 189;
                }
                else
                {
                    lineNum = 185;
                }
            }

            if (Input.GetKeyDown(KeyCode.Y) && playerTalking == false && intro == true)
            {
                ShowDialogue();



                lineNum++;
            }

		}

		UpdateUI ();
	}

	public void ShowDialogue () {
		ParseLine ();
	}

	void ParseLine () {
        if (parser.GetName(lineNum) == "Day")
        {
            playerTalking = false;
            dialogueBox.text = "";
            ClearText();
            day = parser.GetContent(lineNum);
            ShowDay();
        }
        else if (parser.GetName(lineNum) != "Player" && parser.GetName(lineNum) != "Day")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            dialogue = dialogue.Replace('$', '\n');
            StartCoroutine(TypeWriterEffect());


        }
        else
        {
            playerTalking = true;
            options = parser.GetOptions(lineNum);
            CreateButtons();
        }
	}

	void CreateButtons() {
        if (options.Length == 1)
        {

        }
		for (int i = 0; i < options.Length; i++) {
			hasChoice = true;
			GameObject button = (GameObject)Instantiate (choiceBox);
			Text b = button.GetComponent<Text> ();
			ChoiceButton cb = button.GetComponent<ChoiceButton> ();
			cb.SetText (options [i].Split (':') [0]);
			cb.option = options [i].Split (':') [1];
			cb.box = this;
			b.transform.SetParent (this.transform);
            if (options.Length == 1)
            {
                b.transform.localPosition = new Vector3(0, -170);
            }
            else
                b.transform.localPosition = new Vector3 (-250 + (i*500), -170);
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
			Text b = buttons [i];
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

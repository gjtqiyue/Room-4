using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public DialogueManager dialogueManager;
    public CreditButton credit;
	public Light Lolight;
	public AudioSource aud;
	public Button startButton;
	public Text startText;
	public Text titleText;
    public Text creditText;

	public bool menuEnabled = false;
    public bool gameStart = false;

	Animator anim;

	void Start () {
		menuEnabled = true;
		aud = GetComponent <AudioSource> ();
		startButton = GetComponent <Button> ();
		anim = GetComponent <Animator> ();
        credit = creditText.GetComponent<CreditButton>();
	}
	
	// Update is called once per frame
	void Update () {
		if (titleText.color.a == 0) {
			Destroy (Lolight);
			Destroy (titleText);
			Destroy (startText);
            Destroy(creditText);
			menuEnabled = false;
		}
	}

	public void enterButton () {
		aud.Play ();
        
		anim.SetTrigger ("Start");
        gameStart = true;
    }

    public void showCredit()
    {
        if (gameStart == false)
        {
            credit.creditText.enabled = true;
            credit.backText.enabled = true;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Main");
    }


}

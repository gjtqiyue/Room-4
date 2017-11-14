using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour {

    public AudioSource aud;
    public Text creditText;
    public Text backText;
    public Animator anim;
    public Button backButton;
    public AudioClip clip;

    void Start()
    {
        creditText.enabled = false;
        backText.enabled = false;
    }

    void Update()
    {
        
    }

    public void getCredit()
    {
        anim.Play("MenuFade");
        aud.Play(); 
    }

    public void backToMenu()
    {
        anim.Play("CreditMove");
        aud.clip = clip;
        aud.Play();
       
    }

    
}

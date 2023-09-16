using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject player;
    public GameObject tapToInteract;
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            audioManager.playSFX(audioManager.pressButton);

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
                
            }
            else
            {
                dialoguePanel.SetActive(true); 
                StartCoroutine(typing());
            }
        }

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);


        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
          if(dialoguePanel.activeInHierarchy)
            {
                tapToInteract.SetActive(false);
            }

            else
            {
                tapToInteract.SetActive(true);
            }

               

            
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false ;
            tapToInteract.SetActive(false);
        }
    }
}

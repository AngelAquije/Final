using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Dialogues List
    public List<string> dialogues;
    //writting speed
    public float writtingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //wait for next boolean
    private bool waitForNext;
    //Text component
    public TMP_Text dialogueText;

    public void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }
    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show) 
    {
        indicator.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue() 
    {
        if (started) 
        {
            return;
        }

        //boolean to indicate that we have started
        started = true;
        //Shoe the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //start index at zero
        index = 0;
        //start writing
        GetDialogue(0);
    }

    private void GetDialogue(int i) 
    {
        //start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writting
        StartCoroutine (Writing());
    }
    //End Dialogue
    public void EndDialogue() 
    {
        //Hide the window
        ToggleWindow(false);
    }
    //Writing logic
    IEnumerator Writing() 
    {
        string currentDialogue = dialogues[index];
        //write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;
        //Make sure you have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //Wait x seconds
            yield return new WaitForSeconds(writtingSpeed);
            //Restart the same process
            StartCoroutine(Writing());
        }
        else 
        {
            waitForNext = true;
        }             
    }

    private void Update()
    {
        if (!started)
        {
            return;
        }
        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else 
            {
                EndDialogue();
            }          
        }
    }
}

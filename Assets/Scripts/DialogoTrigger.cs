using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    private bool playerDetected;
    public Dialogo dialogueScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player") 
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }
    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E)) 
        {
            dialogueScript.StartDialogue();
        }
    }
}

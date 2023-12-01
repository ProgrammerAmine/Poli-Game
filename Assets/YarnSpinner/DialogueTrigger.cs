using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    
    // Start is called before the first frame update
    public DialogueRunner dialogueRunner;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
                dialogueRunner.StartDialogue("Geert");
    }
}

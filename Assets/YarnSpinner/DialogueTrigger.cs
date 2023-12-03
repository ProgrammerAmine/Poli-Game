using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public enum DialogueTypes{
    Geert, Ali_B,
}

public class DialogueTrigger : MonoBehaviour
{
    public DialogueTypes dialogueType;

    // Start is called before the first frame update
    public DialogueRunner dialogueRunner;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
            switch (dialogueType){
                case DialogueTypes.Geert:
                    dialogueRunner.StartDialogue("Geert");
                    break;
                case DialogueTypes.Ali_B:
                    dialogueRunner.StartDialogue("Ali_B");
                    break;
            }
    }
}

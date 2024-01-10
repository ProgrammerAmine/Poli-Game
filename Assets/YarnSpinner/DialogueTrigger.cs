using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public enum DialogueTypes{
    Geert, Ali_B, Japie, Joost, Karel, Nienke, Paul, Hugo, Janneke, Microfoonpersoon,
}

public class DialogueTrigger : MonoBehaviour
{
    public DialogueTypes dialogueType;

    // Start is called before the first frame update
    public DialogueRunner dialogueRunner;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true){
                switch (dialogueType){
                case DialogueTypes.Geert:
                    dialogueRunner.StartDialogue("Geert");
                    break;
                case DialogueTypes.Ali_B:
                    dialogueRunner.StartDialogue("Ali_B");
                    break;
                case DialogueTypes.Karel:
                    dialogueRunner.StartDialogue("Karel");
                    break;
                case DialogueTypes.Japie:
                    dialogueRunner.StartDialogue("Japie");
                    break;
                case DialogueTypes.Joost:
                    dialogueRunner.StartDialogue("Joost");
                    break;
                case DialogueTypes.Nienke:
                    dialogueRunner.StartDialogue("Nienke");
                    break;
                case DialogueTypes.Paul:
                    dialogueRunner.StartDialogue("Paul");
                    break;
                case DialogueTypes.Hugo:
                    dialogueRunner.StartDialogue("Hugo");
                    break;
                case DialogueTypes.Janneke:
                    dialogueRunner.StartDialogue("Janneke");
                    break;
                case DialogueTypes.Microfoonpersoon:
                    dialogueRunner.StartDialogue("Microfoonpersoon");
                    break;
            }
        }
    }
}

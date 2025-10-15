using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public string message = "Salut ! Bienvenue dans la ville.";
    public GameObject interactionPromptUI;

    public void Interact()
    {

        Debug.Log("Dialogue déclenché : " + message);
       
       // interactionPrompt.text = "Appuyez sur [E]";
        // Ici tu peux appeler ton système de dialogue :
        // DialogueManager.Instance.StartDialogue(dialogueData);

       // DialogueManager.Instance.ShowMessage(message);
    }
}

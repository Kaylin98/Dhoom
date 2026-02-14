using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
   [SerializeField] TMP_Text dialogueText;
   [SerializeField] string[] lines;
   int currentLine = 0; 

   public void NextDialogueLine()
   {
    if (currentLine < lines.Length)
    {
        currentLine++;
        dialogueText.text = lines[currentLine];
    }
    else
    {
        dialogueText.text = "";
        currentLine = 0; 
    }
   }    
}

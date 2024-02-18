using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueScroll : MonoBehaviour
{
    public TMP_Text dialogueText;
    [TextArea(3, 10)] public string fullDialogue; 
    public float textScrollSpeed = 0.05f; 

    private int characterIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        StartScrolling();
    }

    void StartScrolling()
    {
        StartCoroutine(ScrollText());
    }

    void Update()
    {
        if (isTyping && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            characterIndex = fullDialogue.Length;
        }
    }

    IEnumerator ScrollText()
    {
        isTyping = true;
        dialogueText.text = ""; 

        while (characterIndex < fullDialogue.Length)
        {
            dialogueText.text += fullDialogue[characterIndex];
            characterIndex++;
            yield return new WaitForSeconds(textScrollSpeed);
        }

        isTyping = false;
    }
}

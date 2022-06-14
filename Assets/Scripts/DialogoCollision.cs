using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoCollision : MonoBehaviour
{
    [SerializeField] private GameObject ayuraMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)]private string[] dialogueLines;
    private bool estaEnRango;
    private bool dialogueStarted;
    private int lineIndex;
    [SerializeField]  private float typingTime;

    private void Update()
    {
        if (estaEnRango && Input.GetButtonDown("Ataque"))
        {
            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    private void StartDialogue() {
        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char h in dialogueLines[lineIndex])
        {
            dialogueText.text += h;
            yield return new WaitForSeconds(typingTime);
        }
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogueStarted = false;
            dialoguePanel.SetActive(false);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador Entró");
            //ayura.SetActive(true);
            estaEnRango = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador Salió");
            //ayura.SetActive(false);
            estaEnRango = false;
        }
    }
}

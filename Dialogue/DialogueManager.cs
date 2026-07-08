using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject TextUI;
    public Dialogue textScript;
    public TMP_Text text;

    public void StartDialogue()
    {
        //TextUI.SetActive(true);
        textScript.UpdateText();
    }


    public void EndDialogue()
    {
        //TextUI.SetActive(false);
        Debug.Log("end dialogue");
        textScript.inUse = false;
    }
}

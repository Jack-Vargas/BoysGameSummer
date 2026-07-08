using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public string[] strings;
    private TextMeshProUGUI textObject;
    private int position;
    public DialogueManager manager;

    public bool inUse;
    public Sprite[] sprites;
    public Image image;

    public InputAction TextAction;

    private void Update()
    {
        if (inUse)
        {
            TextAction.started += ctx => UpdateText();

            if (Input.GetKeyDown(KeyCode.E))
            {
                UpdateText();
            }
        }
    }


    public void UpdateText()
    {
        if (position == strings.Length)
        {
            manager.EndDialogue();
        }
        else
        {
            textObject.text = strings[position];
            image.sprite = sprites[position];
            position++;
        }



    }

    public void Trigger()
    {
        textObject = manager.TextUI.GetComponent<TextMeshProUGUI>();
        manager.textScript = this;
        manager.StartDialogue();
        inUse = true;
    }

    public void Start()
    {
        TextAction = InputSystem.actions.FindAction("ProgressText");
        Trigger();
    }
}

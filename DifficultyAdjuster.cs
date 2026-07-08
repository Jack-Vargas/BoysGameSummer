using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class DifficultyAdjuster : MonoBehaviour
{

    public InputAction HPUp;
    public InputAction HPDown;
    public InputAction DmgUp;
    public InputAction DmgDown;

    public bool canEdit;
    public TMP_Text textUI;


    public void Update()
    {
        if (canEdit)
        {
            HPUp.started += ctx => RaiseHP();
            HPDown.started += ctx => LowerHP();
            DmgUp.started += ctx => RaiseDmg();
            DmgDown.started += ctx => LowerDmg();            
        }        
    }

    public void RaiseHP()
    {
        float f1 = PlayerPrefs.GetFloat("difficultyHp");
        PlayerPrefs.SetFloat("difficultyHp", f1 + 0.3f);
        UdateText();
    }

    public void LowerHP()
    {
        float f1 = PlayerPrefs.GetFloat("difficultyHp");
        PlayerPrefs.SetFloat("difficultyHp", f1 - 0.3f);
        UdateText();
    }

    public void RaiseDmg()
    {
        float f1 = PlayerPrefs.GetFloat("difficultyDmg");
        PlayerPrefs.SetFloat("difficultyDmg", f1 + 0.5f);
        UdateText();
    }

    public void LowerDmg()
    {
        float f1 = PlayerPrefs.GetFloat("difficultyDmg");
        PlayerPrefs.SetFloat("difficultyDmg", f1 - 0.5f);
        UdateText();
    }

    public void UdateText()
    {
        textUI.text = PlayerPrefs.GetFloat("difficultyHp").ToString() + " / " + PlayerPrefs.GetFloat("difficultyDmg").ToString();
    }

    public void Start()
    {
        HPUp = InputSystem.actions.FindAction("AddHP");
        HPDown = InputSystem.actions.FindAction("LoseHP");
        DmgUp = InputSystem.actions.FindAction("AddDmg");
        DmgDown = InputSystem.actions.FindAction("LoseDmg");
    }
}

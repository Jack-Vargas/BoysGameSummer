using UnityEngine;

public class StartNonsense : MonoBehaviour
{
     void Awake()
    {
        PlayerPrefs.SetFloat("difficultyHp", 1);
        PlayerPrefs.SetFloat("difficultyDmg", 1);
        PlayerPrefs.SetFloat("upgradedGuns", 0);
        PlayerPrefs.SetInt("checkpoint", 0);
    }

   
}

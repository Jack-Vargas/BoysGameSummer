using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform Player;
    public int checkpointIndex;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerPrefs.SetInt("checkpoint" , checkpointIndex);
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            //Player.transform.position = new Vector2(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"));
            //PlayerPrefs.GetFloat("checkpointX");
        }
    }
}

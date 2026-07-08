using UnityEngine;
using UnityEngine.SceneManagement;

public class RKey : MonoBehaviour
{

    void Update()
    {
      if (Input.GetKeyDown (KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

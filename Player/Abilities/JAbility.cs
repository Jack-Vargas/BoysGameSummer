using System.Collections;
using UnityEngine;

public class JAbility : MonoBehaviour
{
    public GameObject marker;
    private bool ready = true;
    public void ActivateAbility()
    {
        if (ready)
        {
            StartCoroutine(Anim());
            StartCoroutine(Cool());
        }
    }

    public IEnumerator Anim()
    {
        marker.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        marker.SetActive(false);
    }

    public IEnumerator Cool()
    {
        ready = false;
        yield return new WaitForSeconds(0.7f);
        ready = true;
    }
}

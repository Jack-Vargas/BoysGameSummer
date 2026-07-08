using UnityEngine;
using UnityEngine.Timeline;
using System.Collections;

public class KAbility : MonoBehaviour
{
    public PStats ps;
    private bool ready = true;
    public GameObject marker;
    public void ActivateAbility()
    {
        if (!ready ) { return; }

        ps.Heal(2);

        StartCoroutine(Cool());
        StartCoroutine(Anim());
    }

    public IEnumerator Cool()
    {
        ready = false;
        yield return new WaitForSeconds(3f);
        ready = true;
    }
    public IEnumerator Anim()
    {
        marker.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        marker.SetActive(false);
    }
}

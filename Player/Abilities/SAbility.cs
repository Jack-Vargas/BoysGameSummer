using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class SAbility : MonoBehaviour
{
    private bool ready = true;
    public Gun g;
    public GameObject marker;

    public void ActivateAbility()
    {
        if (!ready) { return; }
        StartCoroutine(buff());
        StartCoroutine(Cool());
    }

    public IEnumerator buff()
    {
        g.activeBullet = g.bigBullet;
        yield return new WaitForSeconds(0.7f);
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

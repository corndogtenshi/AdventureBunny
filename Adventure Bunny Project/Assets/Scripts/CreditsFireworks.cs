using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsFireworks : MonoBehaviour
{
    private AudioSource fireworks;
    
    // Start is called before the first frame update
    void Start()
    {
        fireworks = this.gameObject.GetComponent<AudioSource>();
        StartCoroutine(playDelayedFireworksAudio());
    }
    IEnumerator playDelayedFireworksAudio()
    {
        yield return new WaitForSeconds(2.5f);
        fireworks.Play();
    }
}

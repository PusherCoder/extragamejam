using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathInBreathOutSFX : MonoBehaviour
{
    [SerializeField] private AudioClip breathIn;
    [SerializeField] private AudioClip breathOut;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = .125f;
        audioSource.playOnAwake = false;
        audioSource.loop = false;

        StartCoroutine(Breath_Co());
    }

    private IEnumerator Breath_Co()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            audioSource.clip = breathIn;
            audioSource.Play();

            yield return new WaitForSeconds(3f);
            audioSource.clip = breathOut;
            audioSource.Play();
        }
    }
}

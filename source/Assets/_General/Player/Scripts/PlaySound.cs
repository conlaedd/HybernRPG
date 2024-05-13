using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioClip footFall1;
    public AudioClip footFall2;

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the GameObject if it doesn't already have one
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Add reverb effect
        audioSource.spatialBlend = 1.0f; // Ensure sound is 3D spatialized
        audioSource.spatialize = true; // Enable spatialization
        audioSource.reverbZoneMix = 1.0f; // Adjust the amount of reverb applied
    }
    
    void PlaySoundOfFootstep1()
    {
        // Play footstep sound with reverb
        audioSource.PlayOneShot(footFall1);
        // Start fade out coroutine with a duration of 0.05 seconds
        StartCoroutine(FadeOut(audioSource, 0.05f)); // Adjust fade-out duration as needed
    }

    void PlaySoundOfFootstep2()
    {
        // Play footstep sound with reverb
        audioSource.PlayOneShot(footFall2);
        // Start fade out coroutine with a duration of 0.05 seconds
        StartCoroutine(FadeOut(audioSource, 0.05f)); // Adjust fade-out duration as needed
    }

    IEnumerator FadeOut(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }

        // Ensure volume is set to 0 at the end of the fade-out
        audioSource.volume = 0f;

        // Reset the volume to its original value
        audioSource.volume = startVolume;
    }
}

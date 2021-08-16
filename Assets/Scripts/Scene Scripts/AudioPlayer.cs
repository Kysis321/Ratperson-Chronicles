using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips = null;
    AudioSource audioSource;

    private void Start() {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void ChangeSong(int clipInt) {
        //*B debug.log("changing song");
        audioSource.Stop();
        audioSource.clip = audioClips[clipInt];
        audioSource.Play();
    }
}

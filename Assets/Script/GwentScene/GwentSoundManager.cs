using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GwentSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    /*
    public void setAudioSource(GameObject tempObj)
    {
        audioSource = tempObj.GetComponent<AudioSource>();
    }
    */
    public void playAudioSource(GameObject tempObj)
    {
        audioSource = tempObj.GetComponent<AudioSource>();
        audioSource.Play();
    }
}

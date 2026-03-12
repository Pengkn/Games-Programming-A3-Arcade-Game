using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

//This will automatically attach a required component and will throw up an error message/ prevent you from removing the component.
[RequireComponent(typeof(AudioSource))]
public class OnKeyPlayAudio : MonoBehaviour
{

    [Tooltip("Add a sound you want played when a key is pressed")]
    public AudioClip soundToPlay;
    [Tooltip("When this key is pressed, the above sound will play")]
	public KeyCode key;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //when key is pressed play audio
        if (Input.GetKeyDown(key)) {
            if (soundToPlay != null) {
              playerAudio.PlayOneShot(soundToPlay, 1.0f);
            }
        }
    }
}

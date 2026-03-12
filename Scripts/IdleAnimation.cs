using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
	[Tooltip("Object that will play the idle animation. If left null, will attempt to play animation on THIS object")]
	public GameObject animationTarget;	// if null, animate me
	[Tooltip("Exact name of the idle animation")]
	public string idleAnimationName;

	void Update ()
	{
		// if no key is currently being pressed 
		if (!Input.anyKey) {
            // animate something
            GameObject toAnimate = animationTarget ? animationTarget : gameObject;
            toAnimate.GetComponent<Animator>().Play (idleAnimationName);
        }
	}
}

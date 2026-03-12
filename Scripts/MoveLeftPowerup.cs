using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using static Unity.Burst.Intrinsics.X86.Avx;

public class MoveLeftPowerup : MonoBehaviour
{
    public float basespeed = 5f;
    public float speedgain = 0.2f;
    public float maxspeed = 20f;
    public float leftBounds = -11f;
    public AudioClip soundToPlay;
    bool collected;
   

    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

    }

    void Update()
    {
        //moves object

        float currentspeed = Mathf.Min(basespeed + speedgain * Time.timeSinceLevelLoad, maxspeed);
        transform.Translate(Vector2.left * currentspeed * Time.deltaTime);
        if (transform.position.x < leftBounds)
        {
            //destroys the object once it leaves the screen
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.tag == "Player" && !collected)
            {
                //does these actions on collision: particle, sound effect, destory object.
                collected = true;
                

                GetComponent<Renderer>().enabled = false;
                
                if (soundToPlay != null)
                {
                    playerAudio.PlayOneShot(soundToPlay, 1.0f);
                }

                Destroy(gameObject, 5f);
            }
    }
}
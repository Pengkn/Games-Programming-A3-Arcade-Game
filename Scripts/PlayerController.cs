using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpforce = 5f;
    public int score;
    private float startTime;
    private bool isGrounded;
    public HeartSystem heartSystem;
    public float speed = 5f;
    public float xLimit = 11f;
    public Animator animator;
    

    public AudioClip jumpSound;
    public AudioClip dmgSound;
    Vector3 start;

    


    private AudioSource playerAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        start = Camera.main.transform.localPosition;
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            //if the character is grounded and presses the space bar these actions happen: the player jumps, jump audio is played
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isGrounded = false;
            if (jumpSound != null)
            {
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }


        }


            animator.SetBool("IsGrounded", isGrounded); 
            float move = Input.GetAxis("Horizontal"); // A/D or ←/→
            transform.Translate(Vector2.right * move * speed * Time.deltaTime); //allows player to move left or right across screen
            float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit); //stops the player from moving off the screen
            transform.position = new Vector2(clampedX, transform.position.y);
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //when the player collides with an obstacle these things happen: player loses a life, dmg sound plays, screen shakes
            float totalTime = Time.time - startTime;
            PlayerPrefs.SetFloat("WinTime", totalTime);
            heartSystem.LoseLife(1);
            if (dmgSound != null)
            {
                playerAudio.PlayOneShot(dmgSound, 1.0f);
            }
            StartCoroutine(ScreenShake(0.15f, 0.1f));
        }

        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Powerup" )
        {
            
            Debug.Log("heart collided");
        
            heartSystem.GainLife(1);
            



        }



    }

    private IEnumerator ScreenShake(float duration, float magnitude) //screenshake coroutine
    {
        var cam = Camera.main.transform;
        float t = 0f;

        while (t < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            cam.localPosition = start + new Vector3(x, y, 0f);

            t += Time.deltaTime;
            yield return null;
        }
        cam.localPosition = start;
    }

}

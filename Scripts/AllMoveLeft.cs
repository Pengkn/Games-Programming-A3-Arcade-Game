using UnityEngine;

public class AllMoveLeft : MonoBehaviour
{
    [Header("Speed")]
    public float baseSpeed = 5f;
    public float Speedgain = 0.2f;
    public float maxSpeed = 20f;

    [Header("Offscreen Behaviour")]
    public float leftBounds = -11f;
    public bool Background = false;
    public float StartPos = 23f;             

    [Header("Optional Bob")]
    public bool bob = false;
    public float bobAmp = 0.5f;
    public float bobFreq = 2f;

    float startY;

    void Start()
    {
        startY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        float currentspeed = Mathf.Min(baseSpeed + Speedgain * Time.timeSinceLevelLoad, maxSpeed); //sets the speed the object moves left at with it progressively increasing as time passes to a cap
        MoveLeft(currentspeed);
        if (bob) ApplyBob();  //if bob is checked applys bob

        Offscreen(); //uses offscreen 
    }
    void MoveLeft(float currentspeed)
    {
        transform.Translate(Vector2.left * currentspeed * Time.deltaTime); //move left
    }

    
    void ApplyBob()
    {
        float y = startY + Mathf.Sin(Time.time * bobFreq) * bobAmp; //moves object up and down slowly 
        transform.position = new Vector2(transform.position.x, y);
    }

    void Offscreen()
    {
        if (transform.position.x < leftBounds) // if outside certain cords
        {
            if (Background)
                transform.position = new Vector2(StartPos, transform.position.y); // teleports back to start pos
            else
                Destroy(gameObject); 
        }


    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    // config para
    [Header("Ball")]
    [SerializeField] int ballValue = 1;

    [Header("Ball Movement")]
    [SerializeField] float xPush = -10f;
    [SerializeField] float yPush = 10f;
    [SerializeField] float randomFactor = .3f;

    [Header("Ball Audio")]
    [SerializeField] AudioClip ballSound;
    [SerializeField] [Range(0, 3)] float ballBounceSound = 0.45f;

    // state
    bool hasStarted;

    //cached ref
    AudioSource myAudio;
    Rigidbody2D myRigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartNewRound();
    }

    public void StartNewRound()
    {
        if (!hasStarted)
        {
            LockBallToCenter();
            LaunchBallOnStartGame();
        }
    }

    private void LaunchBallOnStartGame()
    {
        int startSide = Random.Range(1, 3);

        if(Input.GetButtonDown("Start Game"))
        {
            hasStarted = true;
            if (startSide == 1 )
            {
                myRigidbody2d.velocity = 
                new Vector2(xPush, yPush);
                Debug.Log("Player 1 Gets Advantage: " + startSide);
            }else if(startSide == 2)
            {
                myRigidbody2d.velocity =
                new Vector2(-xPush, +yPush);
                Debug.Log("Player 2 Gets Advantage: "+ startSide);
            }
        }
    }
    private void LockBallToCenter()
    {
            Vector2 ballPos = new Vector2(0,0);
            transform.position = ballPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioSource.PlayClipAtPoint(ballSound,
                transform.position,
                ballBounceSound);
            myRigidbody2d.velocity += velocityTweak;
        }
    }
    public int GetBallValue()
    {
        return ballValue;
    }
    public void ResetBallPos()
    {
        hasStarted = false;
    }
}

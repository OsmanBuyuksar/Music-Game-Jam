using UnityEngine;
using System.Collections;

public class SlimeScript : MonoBehaviour {

    //health&stuff
    public float slimeDmg = 10f;

    private float slimeHealth = 20f;


    //movement variables
    public float moveSpeed = 50f;
    public int changeDirectionBeatCount = 1;

    private Rigidbody2D rb;
    private bool goingRight;
    private int index = 0;

    //music&fx
    private BeatTimer beatCode;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        goingRight = true;
        beatCode = GameObject.FindGameObjectWithTag("Timer").GetComponent<BeatTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        ChangeDirection();
        Move(goingRight);
	}
    void Move(bool goingRight)
    {
        if (goingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = (Vector2.right * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = (Vector2.left * moveSpeed * Time.fixedDeltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("SlimeCheckPoint"))
        //{
        //    if (goingRight)
        //    {
        //        goingRight = false;
        //    }
        //    else
        //    {
        //        goingRight = true;
        //    }
        //}
        if (other.gameObject.CompareTag("Spell"))
        {
            if (slimeHealth <= 0)
            {
                Destroy(gameObject, 0.5f);
                Destroy(other.gameObject, 0.1f);
            }
            else
            {
                slimeHealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerDmg;
                Destroy(other.gameObject,0.1f);
            }
        }
    }

    void ChangeDirection()
    {
        if(beatCode.beat)
        {
            index++;
        }
        if(index>=changeDirectionBeatCount)
        {
            index = 0;
            if (goingRight)
            {
                goingRight = false;
            }
            else
            {
                goingRight = true;
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //animations
    public Animator animator;
    public AnimationState idle;
    public AnimationState castLeft;
    public AnimationState castRight;

    //Input Values
    private float verticalInput;
    private float horizontalInput;

    //physic variables
    public float speed = 20f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool onGround;

    //health&Damage variables
    public float playerHealth = 100f;
    public float playerDmg = 10f;
    public float spellSpeed;

    public float spellDissappearTime = 2f;

    public GameObject spell;
    public Transform spellCastPoint;
    public float attackCooldown = 0.5f;

    private float t = 0f;

    //sound fx s
    public AudioSource audioSource;
    public AudioClip[] walkSounds;
    public AudioClip jumpSound;

    private int i = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //taking ınputs
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        animator.SetFloat("SpeedInput",Mathf.Abs(horizontalInput));

    }
    void FixedUpdate()
    {
        Move();
        Jump();
        Attack();
    }
    void Move()
    {
        //changing rotation
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //adding speed
        rb.velocity = new Vector2(horizontalInput * speed * Time.fixedDeltaTime,rb.velocity.y);

        //changing clip
        if (!audioSource.isPlaying&&horizontalInput!=0)
        {
            audioSource.clip = walkSounds[i];
            audioSource.PlayOneShot(walkSounds[i]);
            switch(i)
            {
                case 0:
                    i = 1;
                    break;
                case 1:
                    i = 0;
                    break;
            }
        }
        else
        {

        }
    }
    void Jump()
    {
        if (verticalInput > 0.01f && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce); //adding jumpForce to jump ı dont know why i typed that :P
            audioSource.clip = jumpSound;   //changing clip
            audioSource.Play();             //playing clip
        }
        if(onGround)
        {
            animator.SetFloat("JumpInput", Mathf.Abs(verticalInput));
        }
        else
        {
            animator.SetFloat("JumpInput", 0);
        }
    }
    void Attack()
    {
        if (Input.GetAxis("Jump") > 0.1f && Time.time - t > attackCooldown)
        {
            animator.SetBool("IsCasting", true);
            t = Time.time;
            GameObject fyu = (GameObject)Instantiate(spell, spellCastPoint.transform.position, spellCastPoint.transform.rotation); //createing the spell
            fyu.GetComponent<Rigidbody2D>().AddForce(spellCastPoint.right * spellSpeed);                           //adding force to spell
            Destroy(fyu, spellDissappearTime);                                                                     //destroying the spell after a time
        }
        else
        {
            animator.SetBool("IsCasting", false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        onGround = true;
        if (other.gameObject.tag == "SlimeEnemy")
        {
            if (playerHealth <= 0)
            {
                GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<SceneUI>().gameEndMenu.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                playerHealth -= other.gameObject.GetComponent<SlimeScript>().slimeDmg;
                GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Image>().fillAmount = playerHealth / 100;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        onGround = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor Tile" && gameObject.transform.position.y < other.transform.position.y)
        {
            other.GetComponent<TileScript>().DisableTile();
        }
        if (other.gameObject.tag == "SlimeEnemy")
        {
            if (playerHealth <= 0)
            {
                GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<SceneUI>().gameEndMenu.enabled = true;
            }
            else
            {
                playerHealth -= other.gameObject.GetComponent<SlimeScript>().slimeDmg;
                GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Image>().fillAmount = playerHealth / 100;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor Tile")
        {
            other.GetComponent<TileScript>().EnableTile();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Floor Tile" && verticalInput < 0)
        {
            other.GetComponent<TileScript>().DisableTile();
        }
    }
}

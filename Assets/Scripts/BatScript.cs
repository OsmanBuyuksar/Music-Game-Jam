using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatScript : MonoBehaviour
{
    //movement variables
    public float moveSpeed = 100f;
    public float moveDistance = 5f;

    private Rigidbody2D rb;
    private bool goingRight;
    private float startPointX;

    //health&dmg variables
    public float batDamage = 10f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goingRight = true;
        startPointX = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        MoveHorizontal();
    }
    void MoveHorizontal()
    {
        float maxX = startPointX + moveDistance;
        if (goingRight)
        {
            if (rb.position.x < maxX)
            {
                goingRight = true;
            }
            else
            {
                goingRight = false;
            }
        }
        else
        {
            if (rb.position.x > startPointX)
            {
                goingRight = false;
            }
            else
            {
                goingRight = true;
            }
        }
        if (goingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y) * Time.fixedDeltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y) * Time.fixedDeltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerHealth <= 0)
            {
                GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<SceneUI>().gameEndMenu.enabled = true;
            }
            else
            {
                other.gameObject.GetComponent<PlayerMovement>().playerHealth -= batDamage;
                GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Image>().fillAmount = other.gameObject.GetComponent<PlayerMovement>().playerHealth / 100;
            }
        }
        else if (other.gameObject.CompareTag("Spell"))
        {
            Destroy(gameObject);
        }
    }
}

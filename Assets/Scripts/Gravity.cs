using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    public float gravityModifier = 1f;

    private bool onground;
    private float gravity;

	// Use this for initialization
	void Start () {
        gravity = Physics2D.gravity.y;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if(onground)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale += gravityModifier * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        onground = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        onground = false;
    }
}

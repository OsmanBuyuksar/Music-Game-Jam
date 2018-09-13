using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

    private Transform player;

    private float currentX;



	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentX = gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

	}
    void Scroll()
    {
        Vector2 offset = new Vector2(player.position.x-currentX, 0);
        gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset = offset/10;
    }
    void FixedUpdate()
    {
        Scroll();
    }
}

using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public float followSpeed=5f;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
	    if(target==null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            target = player.GetComponent<Transform>();
        }
        offset = gameObject.transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Slerp(transform.position, target.position + offset + new Vector3(target.GetComponent<Rigidbody2D>().velocity.x, 0,0), followSpeed * Time.fixedDeltaTime);
    }
}

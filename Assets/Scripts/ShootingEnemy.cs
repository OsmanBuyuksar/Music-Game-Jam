using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour {

    private Transform player;
    private BeatTimer beatCode;

    public Transform barrel;
    public GameObject bullet;
    public float bulletSpeed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        beatCode = GameObject.FindGameObjectWithTag("Timer").GetComponent<BeatTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        LookTowards(player);
        ShootPlayer();
	}
    void LookTowards(Transform target)
    {
        float rot_z = Mathf.Atan2(target.position.y-transform.position.y, target.position.x- transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    void ShootPlayer()
    {
        if(beatCode.beat)
        {
            GameObject bb=(GameObject)Instantiate(bullet, barrel.transform.position,barrel.rotation);
            bb.GetComponent<Rigidbody2D>().AddForce(barrel.transform.up * bulletSpeed);
            Destroy(bb, 6f);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Spell"))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            Destroy(gameObject);
        }
    }
}

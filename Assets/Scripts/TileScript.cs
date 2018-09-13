using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

    public BoxCollider2D trigger;
    public BoxCollider2D tileCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DisableTile()
    {
        tileCollider.enabled = false;
    }
    public void EnableTile()
    {
        tileCollider.enabled = true;
    }
}

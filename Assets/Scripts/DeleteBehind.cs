using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBehind : MonoBehaviour {

    private Transform deleteBehindPoint;

	// Use this for initialization
	void Start () {
        deleteBehindPoint=GameObject.Find("DeletePoint").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x < deleteBehindPoint.position.x)
            Destroy(gameObject);
	}
}

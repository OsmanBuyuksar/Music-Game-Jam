using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject spawningObject;

    private BeatTimer beatCode;

	// Use this for initialization
	void Start () {
        beatCode = GameObject.FindGameObjectWithTag("Timer").GetComponent<BeatTimer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Spawn()
    {
        foreach (Transform t in spawnPoints)
            Instantiate(spawningObject, t);
    }
}

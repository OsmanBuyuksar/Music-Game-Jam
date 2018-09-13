using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatImage : MonoBehaviour {

    private BeatTimer beatCode;

	// Use this for initialization
	void Start () {
        beatCode = GameObject.FindGameObjectWithTag("Timer").GetComponent<BeatTimer>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Image>().fillAmount = beatCode.difference/beatCode.beatTime;
	}
}

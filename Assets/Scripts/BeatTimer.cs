using UnityEngine;
using System.Collections;

public class BeatTimer : MonoBehaviour {

    public float beatTime;
    public float minusDeadline;
    public float maxDeadline;

    private float t;

    public float difference;

    public bool beat;

	// Use this for initialization
	void Start () {
        t = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        difference = Time.time - t;
        if(Time.time-t>=beatTime)
        {
            t = Time.time;
            beat = true;
        }
        else
        {
            beat = false;
        }
	}
    public bool AttackBeatTime()
    {
        if(difference<minusDeadline||difference>maxDeadline)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

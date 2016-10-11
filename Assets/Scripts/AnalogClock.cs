using UnityEngine;
using System;
using System.Collections;

public class AnalogClock : MonoBehaviour {
    [SerializeField]
    private GameObject hand;
    private float count = 0.0f;

    [SerializeField]
    private bool isStarted = false;

    void Start () {
    }

    void FixedUpdate () {
        if (isStarted) {
            count += Time.deltaTime * 30 / 10 * 12;
            hand.transform.rotation = Quaternion.Euler (0, 0, -count);
            Debug.Log(Time.deltaTime);
        }
    }


    public void CountStart() {
        isStarted = true;
    }

    public void CountStop() {
        isStarted = false;
    }
}

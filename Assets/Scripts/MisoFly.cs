using UnityEngine;
using System.Collections;

public class MisoFly : MonoBehaviour {
    private Vector3 euler;
    private float speed;
    private float destroyTime = 4.0f;
    private float oldTime;
    private Vector3 vec;

	// Use this for initialization
	void Start () {
        euler = Random.Range(-30.0f, 30.0f)*Vector3.forward;
        speed = Random.Range(3.0f, 10.0f);
        vec = Quaternion.Euler(euler) * Vector3.up * speed;
        oldTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += vec * Time.deltaTime;
        if (Time.time - oldTime > destroyTime)
        {
            Destroy(gameObject);
        }
	}
}

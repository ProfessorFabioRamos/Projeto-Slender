using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {
    public Light luz;
    public AudioSource aud;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            luz.enabled = !luz.enabled;
            aud.Play();
        }
	}
}

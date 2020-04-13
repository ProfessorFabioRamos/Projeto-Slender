using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float range = 15;
    private Camera fpsCam;
    private AudioSource aud;
    public AudioClip shootingSound;
    public GameObject explodingParticle;

    // Start is called before the first frame update
    void Start()
    {
        aud = transform.parent.parent.GetComponent<AudioSource>();
        fpsCam = transform.GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            aud.PlayOneShot(shootingSound);

            RaycastHit hit;

            Vector3 origin = fpsCam.ViewportToWorldPoint(new Vector3(0,0,0));

            if(Physics.Raycast(origin, fpsCam.transform.forward, out hit, range)){
                Debug.Log(hit.transform.name);
                if(hit.transform.name == "Slenderman"){
                    Instantiate(explodingParticle, hit.transform.position, Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                }
            }    
        }
    }
}

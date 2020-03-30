using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animation anim;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player" && !isOpen){
            if(other.gameObject.GetComponent<Collect>().completed){
                anim.Play("OpenDoor");
                isOpen = true;
            }
        }
    }
}

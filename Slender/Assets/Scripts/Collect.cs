using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public int score = 0;
    public bool completed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Collectible"){
            //score = score +1;
            //score += 1;
            score++;
            Destroy(other.gameObject);
            if(score >= 8)
                completed = true;
        }
    }
}

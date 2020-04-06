using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public int score = 0;
    public bool completed = false;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score+"/8 Caveiras";
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Collectible"){
            //score = score +1;
            //score += 1;
            score++;
            scoreText.text = score+"/8 Caveiras";
            Destroy(other.gameObject);
            if(score >= 8)
                completed = true;
        }
    }
}

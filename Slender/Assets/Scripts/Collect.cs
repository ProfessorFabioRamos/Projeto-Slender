using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    public int score = 0;
    public bool completed = false;
    public Text scoreText;
    public GameObject hintTextPanel;
    [SerializeField]
    private GameObject gun;
    private AudioSource aud;
    public AudioClip reloadClip;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score+"/8 Caveiras";
        gun.SetActive(false);
        aud = GetComponent<AudioSource>();
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

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Gun"){
            hintTextPanel.SetActive(true);
            hintTextPanel.transform.GetComponentInChildren<Text>().text = "Pressione E para pegar";
            //if(Input.GetButtonDown("Interact"))
            if(Input.GetKeyDown(KeyCode.E)){
                Destroy(other.gameObject);
                hintTextPanel.SetActive(false);
                gun.SetActive(true);
                aud.clip = reloadClip;
                aud.Play();
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Gun"){
            hintTextPanel.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "Slenderman"){
            SceneManager.LoadScene("gameover");
        }
    }
}

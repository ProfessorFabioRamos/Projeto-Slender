using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    Animation anim;
    bool isOpen = false;
    public GameObject panelHelp;
    public float totalTime = 3;
    private float currentTime =0;
    private bool isShowing;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animation>();
        panelHelp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShowing){
            currentTime += Time.deltaTime;
            if(currentTime >= totalTime){
                panelHelp.SetActive(false);
                isShowing  = false;
                currentTime = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player" && !isOpen){
            if(other.gameObject.GetComponent<Collect>().completed){
                anim.Play("OpenDoor");
                isOpen = true;
            }
            else{
                panelHelp.SetActive(true);
                panelHelp.transform.GetComponentInChildren<Text>().text = 
                "Colete 8 caveiras para abrir a porta. Você possui "+other.gameObject.GetComponent<Collect>().score+" caveiras.";
                isShowing = true;
            }
        }
    }
}

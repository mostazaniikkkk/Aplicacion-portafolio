using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertBox : MonoBehaviour{
    public string msg;
    public Material texture;
    public bool exitAnim = false;
    [SerializeField] GameObject text, img;
    void Start(){
        text.GetComponent<TextMeshProUGUI>().text = msg;
        img.GetComponent<Renderer>().material = texture;
    }
    void Update(){
        if(exitAnim == true){
            exitAnim = false;
            this.gameObject.SetActive(false);
        }
    }
}
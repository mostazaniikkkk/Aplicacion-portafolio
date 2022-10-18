using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewButton : UIElements{
    [SerializeField] UnityEvent uniEvent = new UnityEvent();
    void Start(){

    }
    void Update(){
        ButtonManager(uniEvent);
    }
}
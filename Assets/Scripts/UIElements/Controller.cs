using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{
    Animator topAnim;
    [SerializeField] string id, nameUser;
    [SerializeField] GameObject login, topBar, mainMenu;
    void Start(){
        login.SetActive(true);
        topAnim = topBar.GetComponent<Animator>();
    }
    void Update(){
        if (login.GetComponent<Login>().logged == true){
            login.SetActive(false);
            topBar.SetActive(true);
            mainMenu.SetActive(true);
            login.GetComponent<Login>().logged = false;
        }
        
        if (topBar.GetComponent<TopBar>().logout == true){
            Debug.Log("Cerrando sesion");
            login.SetActive(true);
            topBar.SetActive(false);
            topBar.GetComponent<TopBar>().logout = false;
        }
    }
}

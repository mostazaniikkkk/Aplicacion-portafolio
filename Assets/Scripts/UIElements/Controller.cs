using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{
    Animator topAnim;
    public string username;
    public GameObject login, topBar, gestClientes, gestProfesionales, addCliente, addWorker, listCliente, listWorker, ajustes;
    void Start(){
        TurnerOff();
        login.SetActive(true);
        topAnim = topBar.GetComponent<Animator>();
    }
    void Update(){
        if (login.GetComponent<Login>().logged == true){
            login.SetActive(false);
            topBar.SetActive(true);
            gestClientes.SetActive(true);
            login.GetComponent<Login>().logged = false;
        }

        if (topBar.GetComponent<TopBar>().logout == true){
            Debug.Log("Cerrando sesion");
            login.SetActive(true);
            topBar.SetActive(false);
            TurnerOff();

            topBar.GetComponent<TopBar>().logout = false;
        }
    }
    public void TurnerOff(){
        gestClientes.SetActive(false);
        addCliente.SetActive(false);
        gestProfesionales.SetActive(false);
        addWorker.SetActive(false);
        listCliente.SetActive(false);
        listWorker.SetActive(false);
        ajustes.SetActive(false);
    }
}
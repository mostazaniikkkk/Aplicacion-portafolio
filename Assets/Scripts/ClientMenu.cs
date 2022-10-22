using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ClientMenu : MonoBehaviour {
    [SerializeField] bool ingCliente, listCliente, genCliente, exitAnim;
    [SerializeField] GameObject ingCli, listCli;
    string[] atrasoClienteNombre, atrasoClienteRUT;
    string[] pagoClienteNombre, pagoClienteRUT;
    int pago, deuda;
    DateTime fechaPago, fechaRegistro;
    void Start(){
        
    }
    public void Goto(GameObject triggered){
        triggered.SetActive(true);
        triggered.GetComponent<Animator>().Play(StartupAnim(triggered.name));
    }

    string StartupAnim(string gameObject){
        string animName = "";
        switch (gameObject){
            case "AddClient":
                animName = "StartupClient";
                break;
        }
        return animName;
    }
}
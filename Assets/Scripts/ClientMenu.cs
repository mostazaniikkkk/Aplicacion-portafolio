using System;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class ClientMenu : MonoBehaviour {
    bool ingCliente, listCliente, genCliente, exitAnim;
    [SerializeField] GameObject ingCli, listCli;
    string[] atrasoClienteNombre, atrasoClienteRUT;
    string[] pagoClienteNombre, pagoClienteRUT;
    int pago, deuda;
    public int totalCliPago, totalCliNoPago;
    DateTime fechaPago, fechaRegistro;
    void Start(){
        
    }
    public void Goto(GameObject triggered){
        triggered.SetActive(true);
        triggered.GetComponent<Animator>().Play(StartupAnim(triggered.name));
    }
    public void GlobalInform(){


        File.WriteAllText(@"GeneradorInforme\data.csv", data);
        Process.Start(@"GeneradorInforme\GeneradorCliente.py");
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
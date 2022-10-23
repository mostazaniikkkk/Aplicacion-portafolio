using System;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class ClientMenu : MonoBehaviour {
    bool ingCliente, listCliente, genCliente, exitAnim;
    [SerializeField] GameObject ingCli, listCli;
    string[] atrasoClienteNombre, atrasoClienteRUT;
    string[] pagoClienteNombre, pagoClienteRUT;
    int[] pago, deuda, newClientes, totalDeuda;
    public int totalCliPago, totalCliNoPago;
    DateTime fechaPago, fechaRegistro;
    void Start(){
        
    }
    public void Goto(GameObject triggered){
        triggered.SetActive(true);
        triggered.GetComponent<Animator>().Play(StartupAnim(triggered.name));
    }
    public void GlobalInform(){
        string varCasos, varAtrasos;

        //Datos para clientes nuevos
        int porcentajeClientes = newClientes[0] * 100 / newClientes[1];
        if(newClientes[0] < newClientes[1]){
            varCasos = "decremento";
        } else {
            varCasos = "incremento";
        }

        //Datos para atrasos


        string data = varCasos + "," + newClientes[0] + "," + porcentajeClientes + "," + totalDeuda[0];

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
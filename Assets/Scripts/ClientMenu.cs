using System;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class ClientMenu : MonoBehaviour {
    [SerializeField] bool exitAnim;
    [SerializeField] GameObject ingCli, listCli, nextObj;
    bool ingCliente, listCliente, genCliente;
    string[] atrasoClienteNombre, atrasoClienteRUT;
    string[] pagoClienteNombre, pagoClienteRUT;
    int[] pago, deuda, newClientes, totalDeuda;
    public int totalCliPago, totalCliNoPago;
    DateTime fechaPago, fechaRegistro;
    void Start(){
        
    }
    private void Update(){
        if(exitAnim == true){
            Changing(nextObj);
        }
    }
    public void Goto(){
        GetComponent<Animator>().Play("ClientExit");
        nextObj = ingCli;
    }
    void Changing(GameObject newWin){
        exitAnim = false;
        ingCli.SetActive(true);
        this.gameObject.SetActive(false);
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
}
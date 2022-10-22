using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
public class ClientProfile : MonoBehaviour{
    int cantAccidentes, porcentaje;
    string nomEmpresa;
    bool comp;
    void Start(){
    }
    void Update(){
    }
    public void ClientInform() {
        string compString;

        if(comp == true){
            compString = "aumento";
        } else {
            compString = "descendio";
        }
        string data = nomEmpresa + "," + cantAccidentes + "," + porcentaje + "," + compString;

        File.WriteAllText(@"GeneradorInforme\data.csv", data);
        Process.Start(@"GeneradorInforme\GeneradorCliente.py");
    }
}
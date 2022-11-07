using System;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

public class ClientMenu : Window {
    string[] atrasoClienteNombre, atrasoClienteRUT;
    string[] pagoClienteNombre, pagoClienteRUT;
    int[] pago, deuda, newClientes, totalDeuda;
    public int totalCliPago, totalCliNoPago;
    DateTime fechaPago, fechaRegistro;
    string varCasos, clienteNuevos, porcentaje, cantAtrasos, varAtrasos, porAtrasos;
    void Start() {
        Initialize();
    }
    void Update() {
        NextWin();
    }
    public void GotoAdd() {
        GetComponent<Animator>().Play("ClientExit");
        nextObj = addCliente;
    }
    public void GotoClientes() {
        GetComponent<Animator>().Play("ClientExit");
        nextObj = listCliente;
    }
    public void GlobalInform() {
        /*
        string route = controller.GetComponent<Controller>().dataUrl + "/Ejecutivo";
        string apiData = File.ReadAllText(route);
        UnityEngine.Debug.Log(apiData);

        string data = varCasos + "," + newClientes[0] + "," + porcentaje + "," + totalDeuda[0];

        List<DataGlobal> pyData = new List<DataGlobal> {
            new DataGlobal{
                varCasos = varCasos,
                clienteNuevos = clienteNuevos,
                porcentaje = porcentaje,
                cantAtrasos = cantAtrasos,
                varAtrasos = varAtrasos,
                porAtrasos = porAtrasos
             }
        };
        string globalData = JsonConvert.SerializeObject(pyData, Formatting.Indented);

        File.WriteAllText(@"GeneradorInforme\data.json", globalData);
        Process.Start(@"GeneradorInforme\GeneradorCliente.py");
        */
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WorkerData : TableData {
    string apeMaterno, apePaterno;
    [SerializeField] GameObject apeMatTxt, apePatTxt;
    void Update(){
        rutTxt.GetComponent<TextMeshProUGUI>().text = rut;
        nombreTxt.GetComponent<TextMeshProUGUI>().text = nombre;
        direccionTxt.GetComponent<TextMeshProUGUI>().text = direccion;
        rubroTxt.GetComponent<TextMeshProUGUI>().text = strRubro;
        emailTxt.GetComponent<TextMeshProUGUI>().text = email;
        telefonoTxt.GetComponent<TextMeshProUGUI>().text = strTelefono;

        apeMatTxt.GetComponent<TextMeshProUGUI>().text = apeMaterno;
        apePatTxt.GetComponent<TextMeshProUGUI>().text = apePaterno;

        rubro = Int32.Parse(strRubro);
        telefono = Int32.Parse(strTelefono);
    }
    public override void Goto(){
        throw new System.NotImplementedException();
    }
}

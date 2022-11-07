using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerData : TableData {
    string apeMaterno, apePaterno;
    [SerializeField] GameObject apeMatTxt, apePatTxt;
    void Start(){
        rutTxt.GetComponent<TextMeshProUGUI>().text = rut;
        nombreTxt.GetComponent<TextMeshProUGUI>().text = nombre;
        direccionTxt.GetComponent<TextMeshProUGUI>().text = direccion;
        rubroTxt.GetComponent<TextMeshProUGUI>().text = rubro;
        emailTxt.GetComponent<TextMeshProUGUI>().text = email;
        telefonoTxt.GetComponent<TextMeshProUGUI>().text = telefono;

        apeMatTxt.GetComponent<TextMeshProUGUI>().text = apeMaterno;
        apePatTxt.GetComponent<TextMeshProUGUI>().text = apePaterno;
    }
    public override void Goto(){
        throw new System.NotImplementedException();
    }
}

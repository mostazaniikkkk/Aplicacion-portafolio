using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClientData : TableData {
    [SerializeField] string deuda;
    string active, fechaCreacion, fechaInicio;
    int id, pos;
    [SerializeField] GameObject deudaTxt;
    void Start(){
        rutTxt.GetComponent<TextMeshProUGUI>().text = rut;
        nombreTxt.GetComponent<TextMeshProUGUI>().text = nombre;
        direccionTxt.GetComponent<TextMeshProUGUI>().text = direccion;
        rubroTxt.GetComponent<TextMeshProUGUI>().text = rubro.ToString();
        emailTxt.GetComponent<TextMeshProUGUI>().text = email;
        telefonoTxt.GetComponent<TextMeshProUGUI>().text = telefono.ToString();
        deudaTxt.GetComponent<TextMeshProUGUI>().text = deuda;
    }
    public override void Goto(){
        this.GetComponent<GameObject>().SetActive(false);
        nextWin.SetActive(true);
    }
}
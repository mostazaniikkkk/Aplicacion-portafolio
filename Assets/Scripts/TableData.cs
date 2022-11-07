using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableData : MonoBehaviour{
    public string rut, nombre, direccion, rubro, email, telefono;
    public GameObject rutTxt, nombreTxt, direccionTxt, rubroTxt, emailTxt, telefonoTxt, boton, nextWin;
    public abstract void Goto();
}

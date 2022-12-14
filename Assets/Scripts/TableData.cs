using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableData : MonoBehaviour{
    public int telefono, rubro;
    public string rut, nombre, direccion, email, strTelefono, strRubro;
    public GameObject rutTxt, nombreTxt, direccionTxt, rubroTxt, emailTxt, telefonoTxt, boton, nextWin;
    public abstract void Goto();
}

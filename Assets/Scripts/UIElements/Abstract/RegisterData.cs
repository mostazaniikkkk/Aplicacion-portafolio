using System;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
public abstract class RegisterData : MonoBehaviour{
    public string rut, nombre, email, dir, comuna;
    public GameObject rutBox, nomBox, mailBox, dirBox, comBox;
    public UnityEvent next;
    public string GlobalValidador(){
        string errorReturn = "No se ha ingresado el rut del usuario";

        bool rutVal = true, mailVal = true, dirVal = true, comVal = true, nomVal = true;
        int rutLength = 0, rutNum, rutInt;
        string rutVer = "", rutExtract = "";

        try{
            rutLength = rut.Length;
            rutVer = rut.Substring(rutLength - 2, 1);
            rutExtract = rut.Substring(0, rutLength - 2);
        } catch {
            return "Se ha ingresado un rut no valido";
        }

        string defaultRutMSG = "Se ha ingresado un RUT no valido";
        //Validador RUT
        try{
            rutInt = Convert.ToInt32(rutVer);
        }
        catch (Exception e){
            if (rutVer != "k"){
                errorReturn = defaultRutMSG;
                Debug.Log(e);
            }
        }
        try{
            rutNum = Convert.ToInt32(rutExtract);
        }
        catch (Exception e){
            errorReturn = defaultRutMSG;
            Debug.Log(e);
        }
        if (rutLength > 11){
            errorReturn = defaultRutMSG;
        }
        //Otros validadores
        if (email.IndexOf("@") < 1 && email.IndexOf(".") < 1){
            errorReturn = "Se debe ingresar un email valido";
        }
        if (nombre.Length < 2){
            errorReturn = "Se debe ingresar un nombre";
        }
        if (dir.Length < 2) {
            errorReturn = "Se debe ingresar su direccion";
        }
        if (comuna == "-Seleccione su comuna-"){
            errorReturn = "Se debe seleccionar una comuna";
        }

        if (rutVal == true && mailVal == true && dirVal == true && comVal == true && nomVal == true){
            errorReturn = null;
        }
        return errorReturn;
    }
    public bool ErrorMSG(GameObject error, string errorMSG){
        error.SetActive(true);
        error.GetComponent<TextMeshProUGUI>().text = errorMSG;
        return false;
    }

    public abstract void Goto();
}

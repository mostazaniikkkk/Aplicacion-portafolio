using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Threading.Tasks;
using System.Text;
public abstract class RegisterData : Window{
    public int comuna, fono;
    public string rut, nombre, email, dir, provincia, region, rutExtract, rutVer, userType, collectedData, apiDir, url, strComuna, strFono;
    public GameObject rutBox, nomBox, mailBox, dirBox, comBox, provBox, regBox, checkObj, fonBox, error;
    public string GlobalValidador(){
        string errorReturn = "No se ha ingresado el rut del usuario";

        bool rutVal = true, mailVal = true, dirVal = true, comVal = true, nomVal = true, provVal = true, regVal = true, telVal = true;
        int rutLength = 0, rutNum, rutInt;

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
                return defaultRutMSG;
            }
        }
        try{
            rutNum = Convert.ToInt32(rutExtract);
        }
        catch (Exception e){
            return defaultRutMSG;
        }
        if (rutLength > 11){
            return defaultRutMSG;
        }
        //Validadores del numero de telefono
        /* try {
            fonoInt = Convert.ToInt32(fono);
        } catch {
            telVal = ErrorMSG(error, "Se ha ingresado un numero de telefono no valido");
            Debug.Log("Efectivamente, hoy gana el nazismo");
        } */
        if (strFono.Length != 12){
            return "Se ha ingresado un numero de telefono no valido";
        }
        //Otros validadores
        if (email.IndexOf("@") < 1 && email.IndexOf(".") < 1){
            return "Se debe ingresar un email valido";
        }
        if (nombre.Length < 2){
            return "Se debe ingresar un nombre";
        }
        if (dir.Length < 2) {
            return "Se debe ingresar su direccion";
        }
        if (strComuna == "-Seleccione su comuna-"){
            return "Se debe seleccionar una comuna";
        }
        if (provincia == "-Seleccione su provincia-"){
            return "Se debe seleccionar una comuna";
        }
        if (region == "-Seleccione su region-"){
            return "Se debe seleccionar una comuna";
        }

        if (rutVal == true && mailVal == true && dirVal == true && comVal == true && nomVal == true && provVal == true && regVal == true && telVal == true){
            errorReturn = null;
        }
        return errorReturn;
    }
    public bool ErrorMSG(GameObject error, string errorMSG){
        error.SetActive(true);
        error.GetComponent<TextMeshProUGUI>().text = errorMSG;
        return false;
    }
    public void SendData(){
        string data = JsonConstructor();
        File.WriteAllText("cliente.json", data);
    }
    IEnumerator Request(string json, string url){
        using UnityWebRequest request = UnityWebRequest.Post(url, "POST");
        request.SetRequestHeader("Content-Type", "application/json");
        byte[] jsonData = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(jsonData);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        switch (request.result){
            case UnityWebRequest.Result.InProgress:
                Debug.Log("Subiendo archivo...");
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("SIUUUUUUUUUUUUUUUUUUUUUU");
                break;
            default:
                Debug.Log("Toca revisar que paso xdn´t");
                break;
        }
    }
    public void SendRequest(string json, string url) => StartCoroutine(Request(json, url));
    public abstract string JsonConstructor();
    public abstract void Goto();
}

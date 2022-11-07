using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class WorkerRegister : RegisterData{
    string apeMaterno, apePaterno;
    [SerializeField] GameObject apeMatBox, apePatBox;
    void Start(){
        url = "ejecutivoSave";
        userType = "ejecutivo";
        error.SetActive(false);
    }
    void Update(){
        rut = rutBox.GetComponent<TextMeshProUGUI>().text;
        nombre = nomBox.GetComponent<TextMeshProUGUI>().text;
        email = mailBox.GetComponent<TextMeshProUGUI>().text;
        dir = dirBox.GetComponent<TextMeshProUGUI>().text;
        comuna = comBox.GetComponent<TextMeshProUGUI>().text;
        provincia = provBox.GetComponent<TextMeshProUGUI>().text;
        region = regBox.GetComponent<TextMeshProUGUI>().text;
        fono = fonBox.GetComponent<TextMeshProUGUI>().text;

        apeMaterno = apeMatBox.GetComponent<TextMeshProUGUI>().text;
        apePaterno = apePatBox.GetComponent<TextMeshProUGUI>().text;
    }
    public override void Goto(){
        bool apMatVal = true, apPatVal = true, workActivo = true;
        string errorMsg = GlobalValidador();

        ErrorMSG(error, errorMsg);
        //Validadores
        if (apeMaterno.Length < 2){
            apMatVal = ErrorMSG(error, "Se debe ingresar su apellido materno");
        }
        if (apePaterno.Length < 2){
            apPatVal = ErrorMSG(error, "Se debe ingresar su apellido paterno");
        }

        if (apMatVal == true && apPatVal == true && errorMsg == null){
            error.SetActive(false);
            SendData();
        }
    }

    public override string JsonConstructor() {
        List<Trabajador> trabajador = new List<Trabajador> {
            new Trabajador{
                idEjecutivo = 0,
                idComuna = comuna,
                ejeRut = rutExtract,
                ejeDvRut = rutVer,
                ejeName = nombre,
                ejePaterno = apePaterno,
                ejeMaterno = apeMaterno,
                ejeTelefono = fono,
                flagActivo = "1",
                ejeMail = email,
                ejeDireccion = dir
            }
        };
        string generatedJson = JsonConvert.SerializeObject(trabajador.ToArray(), Formatting.Indented);
        SendRequest(generatedJson, controller.GetComponent<Controller>().dataUrl + url);

        Debug.Log(generatedJson);
        return generatedJson;
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.Networking;
public class ClientRegister : RegisterData {
    int rubro;
    string strRubro;
    [SerializeField] GameObject rubBox;
    private void Start() {
        userType = "cliente";
        error.SetActive(false);
        url = "/empresa/save";
    }
    void Update() {
        rut = rutBox.GetComponent<TextMeshProUGUI>().text;
        nombre = nomBox.GetComponent<TextMeshProUGUI>().text;
        email = mailBox.GetComponent<TextMeshProUGUI>().text;
        dir = dirBox.GetComponent<TextMeshProUGUI>().text;
        strComuna = comBox.GetComponent<TextMeshProUGUI>().text;
        provincia = provBox.GetComponent<TextMeshProUGUI>().text;
        region = regBox.GetComponent<TextMeshProUGUI>().text;
        strFono = fonBox.GetComponent<TextMeshProUGUI>().text;

        strRubro = rubBox.GetComponent<TextMeshProUGUI>().text;

        rubro = Int32.Parse(strRubro);
        comuna = Int32.Parse(strComuna);
        fono = Int32.Parse(strFono);

        if (exitAnim == true){
            NextWin();
        }
    }
    public override void Goto() {
        string errorMsg = GlobalValidador();
        bool rubVal = true, empActiva = true;

        ErrorMSG(error, errorMsg);
        //Validadores
        if (strRubro.Length < 2) {
            rubVal = ErrorMSG(error, "Se debe ingresar el rubro de la empresa");
        }

        if (rubVal == true && errorMsg == null) {
            error.SetActive(false);
            SendData();
        }
    }
    public override string JsonConstructor(){
        List<Cliente> cliente = new List<Cliente> {
            new Cliente{
                nomEmpresa = nombre,
                fechaInicio = DateTime.Today,
                email = email,
                telefono = fono,
                direccion = dir,
                idComuna = comuna,
                flagActivo = "1",
                fechaCreacion = DateTime.Today,
                rutEmpresa = rutExtract,
                dvEmpresa = rutVer,
                idRubro = rubro,
                estado = null
            }
        };
        string generatedJson = JsonConvert.SerializeObject(cliente.ToArray(), Formatting.Indented);

        SendRequest(generatedJson, controller.GetComponent<Controller>().dataUrl + url);
        Debug.Log(generatedJson);
        return generatedJson;
    }
}
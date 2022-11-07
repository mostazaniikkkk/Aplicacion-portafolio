using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.Networking;
public class ClientRegister : RegisterData {
    string rubro;
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
        comuna = comBox.GetComponent<TextMeshProUGUI>().text;
        provincia = provBox.GetComponent<TextMeshProUGUI>().text;
        region = regBox.GetComponent<TextMeshProUGUI>().text;
        fono = fonBox.GetComponent<TextMeshProUGUI>().text;

        rubro = rubBox.GetComponent<TextMeshProUGUI>().text;

        if (exitAnim == true){
            NextWin();
        }
    }
    public override void Goto() {
        string errorMsg = GlobalValidador();
        bool rubVal = true, empActiva = true;

        ErrorMSG(error, errorMsg);
        //Validadores
        if (rubro.Length < 2) {
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
                estado = "aaaa"
            }
        };
        string generatedJson = JsonConvert.SerializeObject(cliente.ToArray(), Formatting.Indented);

        SendRequest(generatedJson, controller.GetComponent<Controller>().dataUrl + url);
        Debug.Log(generatedJson);
        return generatedJson;
    }
}
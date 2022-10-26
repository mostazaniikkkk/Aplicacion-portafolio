using System;
using System.Linq;
using UnityEngine;
using TMPro;
public class ClientRegister : RegisterData {
    string rubro;
    [SerializeField] GameObject rubBox;
    private void Start() {
        userType = "cliente";
        error.SetActive(false);
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
    }
    public override void Goto() {
        DateTime fecha = DateTime.Today;
        string errorMsg = GlobalValidador();
        bool rubVal = true, empActiva = true;

        ErrorMSG(error, errorMsg);
        //Validadores
        if (rubro.Length < 2) {
            rubVal = ErrorMSG(error, "Se debe ingresar el rubro de la empresa");
        }

        if (rubVal == true && errorMsg == null) {
            collectedData = userType + "," + rutExtract + "," + rutVer + "," + nombre + "," + email + "," + dir + "," + comuna + "," + provincia + "," + region + "," + fono + "," + rubro + "," + empActiva + "," + fecha;

            error.SetActive(false);
            SendData(collectedData);
        }
    }
    public override void JsonConstructor(){
        List
    }
}
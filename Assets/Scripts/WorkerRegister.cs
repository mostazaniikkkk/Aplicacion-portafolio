using UnityEngine;
using TMPro;

public class WorkerRegister : RegisterData{
    string apeMaterno, apePaterno;
    [SerializeField] GameObject apeMatBox, apePatBox;
    void Start(){
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
            collectedData = userType + "," + rutExtract + "," + rutVer + "," + nombre + "," + email + "," + dir + "," + comuna + "," + provincia + "," + region + "," + apeMaterno + "," + apePaterno + "," + workActivo;

            error.SetActive(false);
            SendData(collectedData);
        }
    }
}
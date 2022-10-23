using System;
using UnityEngine;
using TMPro;
public class ClientRegister : RegisterData {
    string fono, rubro;
    [SerializeField] GameObject fonBox, rubBox, clientMenu, error;
    private void Start() {
        error.SetActive(false);
    }
    void Update() {
        rut = rutBox.GetComponent<TextMeshProUGUI>().text;
        nombre = nomBox.GetComponent<TextMeshProUGUI>().text;
        email = mailBox.GetComponent<TextMeshProUGUI>().text;
        dir = dirBox.GetComponent<TextMeshProUGUI>().text;
        comuna = comBox.GetComponent<TextMeshProUGUI>().text;

        fono = fonBox.GetComponent<TextMeshProUGUI>().text;
        rubro = rubBox.GetComponent<TextMeshProUGUI>().text;
    }
    public override void Goto(){
        string errorMsg = GlobalValidador();
        bool telVal = true, rubVal = true;
        int fonoInt;

        //Validadores del numero de telefono
        try{
            fonoInt = Convert.ToInt32(fono);
        } catch {
            telVal = ErrorMSG(error, "Se ha ingresado un numero de telefono no valido");
        }
        if (fono.Length != 12){
            telVal = ErrorMSG(error, "Se ha ingresado un numero de telefono no valido");
        }
        //Otros validadores
        if (rubro.Length < 2){
            rubVal = ErrorMSG(error, "Se debe ingresar el rubro de la empresa");
        }

        if (telVal == true && rubVal == true && errorMsg == null){
            error.SetActive(false);
            next.Invoke();
        } else {
            ErrorMSG(error, errorMsg);
        }
    }
}
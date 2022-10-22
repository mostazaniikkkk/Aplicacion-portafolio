using System;
using UnityEngine;
using TMPro;
public class ClientRegister : RegisterData {
    string fono, rubro;
    [SerializeField] GameObject fonBox, rubBox, clientMenu, error;
    private void Start() {
        clientMenu.SetActive(false);
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
        bool telVal = true, rubVal = true, globalVal = GlobalValidador(error);
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
            rubVal = ErrorMSG(error, "Se debe ingresar su direccion");
        }

        if (telVal == true && rubVal == true && globalVal == true){
            error.SetActive(false);
            next.Invoke();
        }
    }
}
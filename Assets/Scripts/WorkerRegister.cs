using UnityEngine;
using TMPro;

public class WorkerRegister : RegisterData{
    [SerializeField] string apeMaterno, apePaterno;
    [SerializeField] GameObject fonBox, rubBox, error;
    void Start(){
        
    }
    void Update(){
        rut = rutBox.GetComponent<TextMeshProUGUI>().text;
        nombre = nomBox.GetComponent<TextMeshProUGUI>().text;
        email = mailBox.GetComponent<TextMeshProUGUI>().text;
        dir = dirBox.GetComponent<TextMeshProUGUI>().text;
        comuna = comBox.GetComponent<TextMeshProUGUI>().text;

        apeMaterno = fonBox.GetComponent<TextMeshProUGUI>().text;
        apePaterno = rubBox.GetComponent<TextMeshProUGUI>().text;
    }
    public override void Goto(){
        bool apMatVal = true, apPatVal = true, globalVal = GlobalValidador(error);

        //Validadores
        if (apeMaterno.Length < 2){
            apMatVal = ErrorMSG(error, "Se debe ingresar su apellido materno");
        }
        if (apePaterno.Length < 2){
            apPatVal = ErrorMSG(error, "Se debe ingresar su apellido materno");
        }

        if (apMatVal == true && apPatVal == true && globalVal == true){
            error.SetActive(false);
            next.Invoke();
        }
    }
}
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour{
    Animator anim;
    string mail, forMail;
    protected string password;
    public bool logged;
    [SerializeField] GameObject errorMSG, recError, txtboxMail, txtboxPassword, txtboxForgMail;
    void Start() {
        anim = GetComponent<Animator>();
    }
    void Update() {
        mail = txtboxMail.GetComponent<TextMeshProUGUI>().text;
        forMail = txtboxForgMail.GetComponent<TextMeshProUGUI>().text;
        password = txtboxPassword.GetComponent<TextMeshProUGUI>().text;

        if (Input.GetKey(KeyCode.Return)){
            LoginTry();
        }
        Debug.Log("Contraseña registrada = " + password);
    }

    public void LoginTry(){
        Debug.Log(password);
        if (mail == "admin​" && password == "admin1​" || Input.GetKey(KeyCode.LeftControl)){
            errorMSG.SetActive(false);
            anim.Play("ToExit");
        } else {
            errorMSG.SetActive(true);
            errorMSG.GetComponent<TextMeshPro>().text = ErrorFunct(mail, password);
        }
    }

    public void ForPassTry(){
        if(mail == "admin"){
            errorMSG.SetActive(false);
        } else {
            recError.SetActive(true);
            recError.GetComponent<TextMeshPro>().text = ErrorFunct(forMail, "windows system32");
        }
    }

    string ErrorFunct(string mail, string password){
        string error;
        switch (mail, password){
            case (null, null):
                error = "No se ha ingresado ningun dato.";
                break;
            case ("", "windows system32"):
                error = "No se encuentra registrada la direccion de correo solicitada.";
                break;
            default:
                error = "Correo electronico o contraseña no son validos.";
                break;
        }
        return error;
    }
}
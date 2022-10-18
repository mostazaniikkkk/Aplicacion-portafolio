using UnityEngine;
using TMPro;
public class TopBar : MonoBehaviour{
    [SerializeField] GameObject resumenGeneral, gestionClientes, gestionProfesionales, ajustes, cerrarSesion, user;
    [SerializeField] GameObject resWin, gestCliWin, gestProWin, settingWin;
    string username = "Administrador";
    public bool logout;
    void Start(){
        user.GetComponent<TextMeshPro>().text = username;
    }
    public void Goto(GameObject triggered){
        resWin.SetActive(false);
        gestCliWin.SetActive(false);
        gestProWin.SetActive(false);
        settingWin.SetActive(false);

        triggered.SetActive(true);
        triggered.GetComponent<Animator>().Play(StartupAnim(triggered.name));
    }
    string StartupAnim(string gameObject){
        string animName = "";
        switch(gameObject){
            case "AddClient":
                animName = "StartupClient";
                break;
        }
        return animName;
    }

    void Logout(){
        resWin.SetActive(false);
        gestCliWin.SetActive(false);
        gestProWin.SetActive(false);
        settingWin.SetActive(false);
    }
}

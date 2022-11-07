using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour {
    public bool exitAnim;
    public GameObject controller, login, topBar, gestClientes, gestProfesionales, addCliente, addWorker, listCliente, listWorker, ajustes, nextObj;
    
    public void Initialize(){
        login = controller.GetComponent<Controller>().login;
        topBar = controller.GetComponent<Controller>().topBar;
        gestClientes = controller.GetComponent<Controller>().gestClientes;
        gestProfesionales = controller.GetComponent<Controller>().gestProfesionales;
        addCliente = controller.GetComponent<Controller>().addCliente;
        addWorker = controller.GetComponent<Controller>().addWorker;
        listCliente = controller.GetComponent<Controller>().listCliente;
        listWorker = controller.GetComponent<Controller>().listWorker;
        ajustes = controller.GetComponent<Controller>().ajustes;
    }
    public void NextWin(){
        if (exitAnim == true){
            exitAnim = false;
            Changing(nextObj);
        }
    }
    public void Changing(GameObject newWin){
        try {
            exitAnim = false;
            newWin.SetActive(true);
            this.gameObject.SetActive(false);
        } catch {
            exitAnim = false;
            this.gameObject.SetActive(false);
        }
    }
    public string StartupCheck(GameObject component){
        switch (component.GetComponent<Animator>().name){
            case ("ClientMenu"):
                return "StartUpClient";
            case ("ClientTable"):
                return "UIStartup";
            case (""):
                return "";
            default:
                return "";
        };
    }
}
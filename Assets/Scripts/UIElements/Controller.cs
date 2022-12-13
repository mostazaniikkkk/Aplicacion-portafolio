using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.Events;

public class Controller : MonoBehaviour{
    #region Global
    Animator topAnim;
    public string username, dataID, dataUrl;
    public GameObject login, topBar, gestClientes, gestProfesionales, addCliente, addWorker, listCliente, listWorker, ajustes;
    public bool turnerOff;
    private void Awake(){
        Application.targetFrameRate = 60;
    }
    void Start(){
        dataID = NgrokReader();
        dataUrl = "https://" + dataID + ".sa.ngrok.io";
        TurnerOff();
        login.SetActive(true);
        topAnim = topBar.GetComponent<Animator>();
    }
    void Update(){
        string info;
        try{
            info = topBar.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
        } catch {
            info = "";
        }
        if (login.GetComponent<Login>().logged == true){
            login.SetActive(false);
            topBar.SetActive(true);
            gestClientes.SetActive(true);
            login.GetComponent<Login>().logged = false;
        }

        if(info == "DespawnBarAnim"){
            TurnerOff();
        }

        if (topBar.GetComponent<TopBar>().logout == true){
            Debug.Log("Cerrando sesion");
            login.SetActive(true);
            topBar.SetActive(false);

            topBar.GetComponent<TopBar>().logout = false;
        }
    }
    public void TurnerOff(){
        gestClientes.GetComponent<Animator>().Play("ClientExit");
        addCliente.GetComponent<Animator>().Play("EndAnim");
        gestProfesionales.GetComponent<Animator>().Play("ClientExit");
        addWorker.GetComponent<Animator>().Play("EndAnim");

        gestClientes.SetActive(false);
        addCliente.SetActive(false);
        gestProfesionales.SetActive(false);
        addWorker.SetActive(false);
        listCliente.SetActive(false);
        listWorker.SetActive(false);
        ajustes.SetActive(false);
    }
    IEnumerator GetInfo(string url, GameObject window, UnityEvent nextEvent){
        using(UnityWebRequest request = UnityWebRequest.Get(url)){
            yield return request.SendWebRequest();
            if(request.isNetworkError || request.isHttpError){
                Debug.Log("No se ha podido conectar a la red, entrando al modo Debug...");
            } else {
                switch (window.name) {
                    case "ClientTable":
                    case "ClientMenu":
                        window.GetComponent<ClientTable>().jsonData = request.downloadHandler.text;
                        break;
                    case "ProTable":
                    case "ProMenu":
                        window.GetComponent<WorkerTable>().jsonData = request.downloadHandler.text;
                        Debug.Log("aaaa");
                        break;
                }
            }
            nextEvent.Invoke();
        }
    }
    string NgrokReader(){
        string archivo = "Ngrok.txt", url;
        if (!File.Exists(archivo)){
            File.Create(archivo);
        }
        url = File.ReadAllText(archivo);
        Debug.Log(url);

        return url;
    }
    public void SendInfo(string url, GameObject window, UnityEvent nextEvent) => StartCoroutine(GetInfo(url, window, nextEvent));
    #endregion

    #region MenuController
    void ClientMenuManager(){

    }
    void ProMenuManager(){

    }
    #endregion
}
using UnityEngine;
using TMPro;
public class TopBar : Window{
    [SerializeField] GameObject user;
    AnimatorClipInfo[] info;
    public bool logout;
    void Start(){
        gestClientes = controller.GetComponent<Controller>().gestClientes;
        gestProfesionales = controller.GetComponent<Controller>().gestProfesionales;
        addCliente = controller.GetComponent<Controller>().addCliente;
        addWorker = controller.GetComponent<Controller>().addWorker;
        listCliente = controller.GetComponent<Controller>().listCliente;
        listWorker = controller.GetComponent<Controller>().listWorker;
        ajustes = controller.GetComponent<Controller>().ajustes;

        user.GetComponent<TextMeshPro>().text = controller.GetComponent<Controller>().username;
    }
    public void Goto(GameObject triggered){
        controller.GetComponent<Controller>().TurnerOff();
        info = this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);

        triggered.SetActive(true);
    }
}

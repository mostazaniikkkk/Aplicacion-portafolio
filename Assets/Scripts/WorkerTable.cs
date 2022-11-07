using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json;

public class WorkerTable : WorkerData{
    [SerializeField] GameObject controller, dataColumn, table;
    [SerializeField] UnityEvent nextEvent;
    WorkerData columnInfo;
    string url;
    public string jsonData;
    void Start(){
        url = controller.GetComponent<Controller>().dataUrl + "/ejecutivo";
        controller.GetComponent<Controller>().SendInfo(url, this.gameObject, nextEvent);
    }

    public void ProccessJson(){
        var data = JsonConvert.DeserializeObject<List<Trabajador>>(jsonData);
        Debug.Log(data);
        for (int counter = 0; counter < data.Count; counter++){
            GameObject column = Instantiate(dataColumn, table.transform);
            columnInfo = column.GetComponent<WorkerData>();
            column.name = string.Format(data[counter].ejeName);
            column.transform.position = new Vector3(316.16f, 240.05f - .5f * counter, 0);

            columnInfo.rut = string.Format(data[counter].ejeRut) + "-" + string.Format(data[counter].ejeDvRut);
            columnInfo.nombre = string.Format(data[counter].ejeName);
            columnInfo.direccion = string.Format(data[counter].ejeDireccion);
            columnInfo.email = string.Format(data[counter].ejeMail);
            columnInfo.telefono = string.Format(data[counter].ejeTelefono);
        }
    }
}
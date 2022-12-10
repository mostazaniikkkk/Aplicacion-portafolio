using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json;

public class ClientTable : ClientData {
    [SerializeField] GameObject controller, dataColumn, table;
    [SerializeField] UnityEvent nextEvent;
    ClientData columnInfo;
    string url;
    public string jsonData;
    void Start(){
        url = controller.GetComponent<Controller>().dataUrl + "/empresa/all";
        controller.GetComponent<Controller>().SendInfo(url, this.gameObject, nextEvent);
    }

    public void ProccessJson(){
        jsonData = jsonData.Replace("\"fechaInicio\":null", "\"fechaInicio\":\"2022-10-10T03:00:00.000+00:00\"");
        Debug.Log(jsonData);
        var data = JsonConvert.DeserializeObject<List<Cliente>>(jsonData);
        for (int counter = 0; counter < data.Count; counter++) {
            GameObject column = Instantiate(dataColumn, table.transform);
            columnInfo = column.GetComponent<ClientData>();
            column.name = string.Format(data[counter].nomEmpresa);
            column.transform.position = new Vector3(316.16f,240.05f - .5f * counter,0);

            columnInfo.rut = string.Format(data[counter].rutEmpresa) + "-" + string.Format(data[counter].dvEmpresa);
            columnInfo.nombre = string.Format(data[counter].nomEmpresa);
            columnInfo.direccion = string.Format(data[counter].direccion);
            columnInfo.email = string.Format(data[counter].email);
            columnInfo.telefono = string.Format(data[counter].telefono);
        }
    }
}
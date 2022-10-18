using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerRegister : RegisterData{
    [SerializeField] string apeMaterno, apePaterno;
    [SerializeField] GameObject fonBox, rubBox;
    void Update(){
        GameObjectAssign();
        apeMaterno = fonBox.GetComponent<TextMeshProUGUI>().text;
        apePaterno = rubBox.GetComponent<TextMeshProUGUI>().text;
    }
    public override void SaveData(){
        throw new System.NotImplementedException();
    }
}
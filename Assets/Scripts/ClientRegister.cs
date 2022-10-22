using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClientRegister : RegisterData{
    [SerializeField] string fono, rubro;
    [SerializeField] GameObject fonBox, rubBox, clientMenu;
    private void Start(){
        clientMenu.SetActive(false);
    }
    void Update(){
        GameObjectAssign();
        fono = fonBox.GetComponent<TextMeshProUGUI>().text;
        rubro = rubBox.GetComponent<TextMeshProUGUI>().text;
    }
    public override void SaveData(){
        throw new System.NotImplementedException();
    }
}
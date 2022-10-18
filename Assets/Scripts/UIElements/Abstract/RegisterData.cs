using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public abstract class RegisterData : MonoBehaviour{
    public string rut, nombre, email, dir, comuna;
    public GameObject rutBox, nomBox, mailBox, dirBox, comBox;
    public void GameObjectAssign(){
        rut = rutBox.GetComponent<TextMeshProUGUI>().text;
        nombre = nomBox.GetComponent<TextMeshProUGUI>().text;
        email = mailBox.GetComponent<TextMeshProUGUI>().text;
        dir = dirBox.GetComponent<TextMeshProUGUI>().text;
        comuna = comBox.GetComponent<TextMeshProUGUI>().text;
    }
    public abstract void SaveData();
}

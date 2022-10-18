using UnityEngine;
using UnityEngine.Events;
using TMPro;
public abstract class UIElements : MonoBehaviour{
    public void ButtonManager(UnityEvent uniEvent){
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0) && Physics.Raycast(raycast, out RaycastHit data) && data.collider.gameObject == gameObject){
            uniEvent.Invoke();
        }
    }
    public void ErrorMSG(TextMeshProUGUI textBox, string errorMsg){
        
    }
}
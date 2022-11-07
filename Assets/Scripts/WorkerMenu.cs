using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerMenu : Window {
    void Start(){
        Initialize();
    }
    void Update(){
        NextWin();
    }
    public void GotoAdd(){
        GetComponent<Animator>().Play("ClientExit");
        nextObj = addWorker;
    }
    public void GotoList(){
        GetComponent<Animator>().Play("ClientExit");
        nextObj = listWorker;
    }
}

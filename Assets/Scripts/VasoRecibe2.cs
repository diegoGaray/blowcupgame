using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasoRecibe2 : MonoBehaviour {

    public GameObject obj;
    public float numx;

    // Use this for initialization
    void Start()
    {
        numx = Random.Range(-2.8f, 2.8f);
        obj.transform.position = new Vector3(numx, obj.transform.position.y, obj.transform.position.z);
        //Generar();
        //NotificationCenter.DefaultCenter().AddObserver(this, "FuncionarGenerator");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Generar()
    {

    }
}

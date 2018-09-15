using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScore : MonoBehaviour {

    public TextMesh marcador;

    // Use this for initialization
    void Start () {
        EstadoJuego.estadoJuego.Cargar();
        marcador.text = "BEST: " + EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

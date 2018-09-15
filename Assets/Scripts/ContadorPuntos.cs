using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorPuntos : MonoBehaviour {

    private int key = 0;
    private int puntuacion;
    public TextMesh marcador;
    
    public int flag = 0;

    // Use this for initialization
    void Start()
    {
        puntuacion = EstadoJuego.estadoJuego.puntuacionActual;
        //puntuacion = 0;
        marcador.text = puntuacion.ToString();
        NotificationCenter.DefaultCenter().AddObserver(this, "Incrementar");
        // NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        //ActualizarMarcador();

    }

    void Incrementar()
    {
        puntuacion = puntuacion + 1;
        marcador.text = puntuacion.ToString();
        EstadoJuego.estadoJuego.puntuacionActual = puntuacion;
        if (puntuacion >= EstadoJuego.estadoJuego.puntuacionMaxima)
        {
            EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
            EstadoJuego.estadoJuego.Guardar();
        }
        flag = 2;
    }

    void ActualizarMarcador()
    {
     //   marcador.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

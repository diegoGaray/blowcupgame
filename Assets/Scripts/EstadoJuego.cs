using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;
//using GooglePlayGames;

public class EstadoJuego : MonoBehaviour {

    public static EstadoJuego estadoJuego;
    public int puntuacionMaxima = 0;
    public int puntuacionActual = 0;
    private String nombreArchivo;

    void Awake()
    {
        nombreArchivo = Application.persistentDataPath + "/datos.dat";
        Debug.Log(Application.persistentDataPath);
        if (estadoJuego == null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);

          //  PlayGamesPlatform.DebugLogEnabled = true;
          //  PlayGamesPlatform.Activate();
        }
        else if (estadoJuego != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        Cargar();

      //  ((PlayGamesPlatform)Social.Active).Authenticate((bool success) => { }, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(nombreArchivo);
        DatosAGuardar datos = new DatosAGuardar();
        datos.puntuacionMaxima = puntuacionMaxima;
        bf.Serialize(file, datos);
        file.Close();
    }
    public void Cargar()
    {
        if (File.Exists(nombreArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(nombreArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
            puntuacionMaxima = datos.puntuacionMaxima;
            file.Close();
        }
        else
        {
            puntuacionMaxima = 0;
        }
    }
}
[Serializable]
class DatosAGuardar
{
    public int puntuacionMaxima;

}
using AppTrackerUnitySDK;
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveVaso : MonoBehaviour {

    float factor = 45.0f;
    private float startTime;
    private Vector3 startPos;
    public GameObject startPosObject;
    private Vector3 startPosUno;
    public float num;
    public TextMesh marcadorBest;
    public Button rate;
    public Button share;
    private int flagMove = 0;
    public float speed = 0.1F;
    public int countPub = 0;
    string adUnitId = "ca-app-pub-9633322892131227/3283175997";
    InterstitialAd interstitial;

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0.0f, -30.0F, 0.0f);
        startPosUno = startPosObject.transform.position;
        // Initialize an InterstitialAd.
         interstitial = new InterstitialAd(adUnitId);
         // Create an empty ad request.
         AdRequest request = new AdRequest.Builder().Build();
         // Load the interstitial with the request.
         interstitial.LoadAd(request);

    }
    private void GameOver()
    {
          if (interstitial.IsLoaded())
          {
              interstitial.Show();
          }
          
    }

    IEnumerator ReturnBall()
    {
        yield return new WaitForSeconds(4.0f);
        transform.position = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
            Application.Quit();
                    
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
            startPos = Input.mousePosition;
            //startPos = startPosObject.transform.position;
            startPos.z = transform.position.z - Camera.main.transform.position.z;
            startPos = Camera.main.ScreenToWorldPoint(startPos);
            flagMove = 0;

        }


        if (Input.GetMouseButtonUp(0))
        {
            flagMove = 0;
            marcadorBest.text = "";
            rate.gameObject.SetActive(false);
            share.gameObject.SetActive(false);
            Vector3 endPos = Input.mousePosition;
            endPos.z = transform.position.z - Camera.main.transform.position.z;
            endPos = Camera.main.ScreenToWorldPoint(endPos);
            Vector3 force = endPos - startPos;
            //force.z = force.magnitude + 1f;
            //force.y = force.y + 8.5f;
            // force.z = 2f;
            // force /= (Time.time - startTime);
            force.z = 2.8f;
            force.y = 13f;
            force /= 0.2f;
            GetComponent<Rigidbody>().AddForce(force * factor);
            ReturnBall();
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "objetivo")
        {
            
            Debug.Log("llego al cuadrado");
        }
        else if (collision.other.tag == "Finish")
        {
            if (EstadoJuego.estadoJuego.puntuacionActual >= 2)
            {
                GameOver();
            }
          
            EstadoJuego.estadoJuego.puntuacionActual = 0;
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "objetivo")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "Incrementar");
            other.enabled = false;
            SceneManager.LoadScene("MainScene");
        }
    }
}

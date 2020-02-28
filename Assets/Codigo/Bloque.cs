using UnityEngine;
using System.Collections;
using System;

public class Bloque : MonoBehaviour {

    public bool parar;
    public float velocidad = 0.5f;
    public GameObject efectoParticulas;

    float tiempo;
    int aux;
    float posX;
    bool salir;
    
    Rigidbody rig;
    GameObject panel;
    Pantalla pantalla;
    GameObject generar;
    Generador generador;
    GameObject MovPla;
    MovPlayer movpla;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        panel = GameObject.FindGameObjectWithTag("Panel");
        pantalla = panel.GetComponent<Pantalla>();
        generar = GameObject.FindGameObjectWithTag("Generador");
        generador = generar.GetComponent<Generador>();
        MovPla = GameObject.FindGameObjectWithTag("MovPlayer");
        movpla = MovPla.GetComponent<MovPlayer>();
        posX = transform.position.x;
        aux = 1;

        gameObject.name = "Bloque"+generador.contadorBloques;
    }

    private void name(object ol, object bloque)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
        posX = transform.position.x;

        float distancia = 5.5f;

        if (gameObject.tag == "Rectangulo") distancia = 6;
        

        if(posX <= distancia && posX >= -distancia - 1)
        {
            tiempo += 5 * Time.deltaTime;
            int segundo = Convert.ToInt32(tiempo);

            if (segundo > aux && !parar)
            {
                aux = segundo;

                posX = transform.position.x - 1;

                transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            }

            if ((Input.GetButton("Fire1") || pantalla.pulsado) && posX <= 4.5 && posX >= -4.5)
            {
                rig.isKinematic = false;
                parar = true;
            }

            if (Math.Abs(transform.rotation.z * 360) > 30 && gameObject.tag == "Rectangulo")
            {
                Instantiate(efectoParticulas, transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = new Vector3(posX - velocidad, transform.position.y, transform.position.z);
        }      
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(efectoParticulas, transform.position, Quaternion.Euler(0, 180, 0));
            Destroy(gameObject);
            generador.QuitarBloque();
            generador.Generar();
        }
        //Al tocar suelo u otro bloque comprobaremos el movimiento del personaje si es posible y hacia a donde se mueve
        if (!salir && (other.gameObject.tag == "Suelo" || other.gameObject.tag == "Cubo" || other.gameObject.tag == "Rectangulo"))
        {
            movpla.ComprobarMovimiento();
            generador.Generar();
            salir = true;
        }  
    }
   
}

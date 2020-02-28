using UnityEngine;
using System.Collections;
using System;

public class Plataforma : MonoBehaviour
{
    public bool parar;
    public float velocidad = 0.1f;

    int i;

    float tiempo;
    int aux;
    float posX;

    GameObject panel;
    Pantalla pantalla;

    // Use this for initialization
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("Panel");
        pantalla = panel.GetComponent<Pantalla>();
        posX = transform.position.x;
        aux = 1;
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;

        float distancia = 5.5f;

        if (gameObject.tag == "PlataformaR") distancia = 6;

        if (posX <= distancia && posX >= -distancia - 1 && !parar)
        {
            tiempo += 5 * Time.deltaTime;
            int segundo = Convert.ToInt32(tiempo);

            if (segundo > aux)
            {
                aux = segundo;

                posX = transform.position.x - 1;

                transform.position = new Vector3(posX, transform.position.y, transform.position.z);
            }

            if ((Input.GetButton("Fire1") || pantalla.pulsado) && posX <= 4.5 && posX >= -4.5)
            {
                parar = true;
            }
        }
        else
        {
            transform.position = new Vector3(posX - velocidad, transform.position.y, transform.position.z);
        }
    }
}

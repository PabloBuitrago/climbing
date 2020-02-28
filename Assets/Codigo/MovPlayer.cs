using UnityEngine;
using System.Collections;

public class MovPlayer : MonoBehaviour {

    GameObject Bloque;
    Bloque bloque;
    Vector3 posicionPlayer;
    float subida = 1.5f;
    float iNumeroMayorY, iNumeroMayorX, iPosicion;

    float[] elevaciones = new float[100];
    float[] elevacionesX = new float[100];


    GameObject generar;
    Generador generador;

    // Use this for initialization
    void Start () {
        generar = GameObject.FindGameObjectWithTag("Generador");
        generador = generar.GetComponent<Generador>();
        elevaciones[0] = 0f;
        elevacionesX[0] = 0f;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ComprobarMovimiento()
    {
        Bloque = GameObject.Find("Bloque" + generador.contadorBloques);
        bloque = Bloque.GetComponent<Bloque>();
        Debug.Log("Bloque" + generador.contadorBloques);

        elevaciones[generador.contadorBloques] = bloque.transform.position.y;
        elevacionesX[generador.contadorBloques] = bloque.transform.position.x;
        NumMayor();

        transform.position = new Vector3 (iNumeroMayorX, iNumeroMayorY + subida, bloque.transform.position.z);
    }

    //Comprueba el numero mayor del array que almacena todas las alturas
    void NumMayor()
    {
        iNumeroMayorY = elevaciones[0];
        iPosicion = 0;
        for(int x=1; x < elevaciones.Length; x++)
        {
            if (elevaciones[x] > iNumeroMayorY)
            {
                iNumeroMayorY = elevaciones[x];
                iNumeroMayorX = elevacionesX[x];
                iPosicion = x;
            }
        }
    }
}
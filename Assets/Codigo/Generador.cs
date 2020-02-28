using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

    public GameObject[] figura;
    public float tiempo = 5f;

    //Contador que enumera los bloques
    public int contadorBloques = 0;

    int aleatorio;

    public GameObject[] barra;
    public Transform plataforma;

    // Use this for initialization
    void Start()
    {
        Generar();
    }

    public void Generar()
    {
        aleatorio = Random.Range(0, figura.Length);

        AnadirBloque();

        Instantiate(figura[aleatorio], transform.position, Quaternion.identity);

        Instantiate(barra[aleatorio], new Vector3(transform.position.x, plataforma.position.y, plataforma.position.z), Quaternion.identity);
  
    }

    public void AnadirBloque()
    {
        contadorBloques++;
    }

    public void QuitarBloque()
    {
        contadorBloques--;
    }
}
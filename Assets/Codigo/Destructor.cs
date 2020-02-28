using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

    public Generador generador;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.tag != "PlataformaC" && other.gameObject.tag != "PlataformaR")
        {
            generador.Generar();
            generador.QuitarBloque();
        }
        
    }
}

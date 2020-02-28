using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Vector3 posicion;

    GameObject MovPla;
    MovPlayer movpla;

    // Use this for initialization
    void Start () {
        MovPla = GameObject.FindGameObjectWithTag("MovPlayer");
        movpla = MovPla.GetComponent<MovPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = movpla.transform.position;
    }
}
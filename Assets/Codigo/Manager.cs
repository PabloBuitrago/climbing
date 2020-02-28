using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public void Restart()
    {
        SceneManager.LoadScene("Nivel 01");
    }
}

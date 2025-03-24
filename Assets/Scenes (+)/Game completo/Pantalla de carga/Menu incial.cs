using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuincial : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Escenario"); // Cambia "GameScene" por el nombre real de la escena del juego
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra el juego (funciona en una build, no en el editor)
    }
}

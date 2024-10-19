using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject Pause_button;
    [SerializeField] private GameObject Menu;

    public void Start()
    {
        //Time.timeScale = 0f;
        Pause_button.SetActive(true);
        Menu.SetActive(false);
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        Pause_button.SetActive(false);
        Menu.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        Pause_button.SetActive(true);
        Menu.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause_button.SetActive(true);
        Menu.SetActive(false);
    }

    public void Cerrar()
    {
        Time.timeScale = 1f;
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
}

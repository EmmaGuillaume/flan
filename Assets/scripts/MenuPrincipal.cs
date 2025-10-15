using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jouer()
    {
        Debug.Log("Bouton Jouer cliqué !");
        SceneManager.LoadScene("Niveau1"); // ⚠️ nom exact de la scène à charger
    }

    public void Quitter()
    {
        Debug.Log("Fermeture du jeu...");
        Application.Quit();
    }
}

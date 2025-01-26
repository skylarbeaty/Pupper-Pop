using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvas : MonoBehaviour
{
    public GameObject successScreen, failScreen;
    public bool gameOver = false;
    public void OnSuccess(){
        gameOver = true;
        successScreen.SetActive(true);
    }
    public void OnFail(){
        gameOver = true;
        failScreen.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

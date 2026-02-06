using UnityEngine;
using UnityEngine.SceneManagement;
public class YouWin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void EXIT()
    {
        Application.Quit();
    }
}

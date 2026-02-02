using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PLAY()
    {
        SceneManager.LoadScene(1);

    }

    public void EXIT()
    {
        Application.Quit();
    }
    

}

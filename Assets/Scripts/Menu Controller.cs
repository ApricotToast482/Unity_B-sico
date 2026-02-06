using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PLAY()
    {
        Controler.posicionParaElBoss = Vector3.zero;
        SceneManager.LoadScene(1);

    }

    public void EXIT()
    {
        Application.Quit();
    }
    

}

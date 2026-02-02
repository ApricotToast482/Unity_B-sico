using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void AGAIN()
    {
        SceneManager.LoadScene(1);
    }
    public void NotNow()
    {
        SceneManager.LoadScene(0);
    }
}

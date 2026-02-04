using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLVL : MonoBehaviour
{
    [Header("Cambio de nivel")]
    public int enemigosparaboss = 15;
    public int contadorElim = 0;
    public void ContadorEliminaciones()
    {
        contadorElim++;
        if (contadorElim >= enemigosparaboss)
        {
            Bossfight();
        }
    }
    void Bossfight()
    {
         Debug.Log("¡Meta alcanzada! Intentando cargar: BossScene");
        SceneManager.LoadScene("FinalBoss");
    }
}

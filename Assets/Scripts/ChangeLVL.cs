using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLVL : MonoBehaviour
{
    [Header("Cambio de nivel")]
    public float _Tiempo4Boss;
    private float _cronos =0f;
    private void Update()
    {
        _cronos += Time.deltaTime;

        if (_cronos >= _Tiempo4Boss)
        {
            Debug.Log ("Ya viene el boss");
            SceneManager.LoadScene (3);
        }
    }
}

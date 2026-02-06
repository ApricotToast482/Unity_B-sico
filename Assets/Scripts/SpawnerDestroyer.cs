using UnityEngine;

public class SpawnerDestroyer : MonoBehaviour
{
    public float tiempoDeVida; 

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }
}

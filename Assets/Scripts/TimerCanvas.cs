using UnityEngine;

public class TimerCanvas : MonoBehaviour
{
    public GameObject elCanvas;
    public float tiempoParaAparecer;
    private float cronos = 0f;
    private bool activado = false;

    void Update()
    {
        // Si ya se activó, dejamos de contar para no gastar memoria
        if (activado) return;

        cronos += Time.deltaTime;

        if (cronos >= tiempoParaAparecer)
        {
            elCanvas.SetActive(true);
            activado = true;
            Debug.Log("Temporizador: Canvas activado");
        }
    }
}
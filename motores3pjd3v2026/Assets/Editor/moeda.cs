using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField]
    private int valor = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObservadorMoedas.Instance.AdicionarMoedas(valor);

            Destroy(gameObject);
        }
    }
}
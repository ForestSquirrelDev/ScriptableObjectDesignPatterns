using UnityEngine;
using UnityEngine.Events;

public class CubeController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFallOccured;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnFallOccured.Invoke();
    }
}

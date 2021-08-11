using UnityEngine;
using UnityEngine.Events;

public class CubeController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFallOccured;
    [SerializeField] private CubesRuntimeSet cubesRuntimeSet;

    private void OnEnable()
    {
        if(cubesRuntimeSet != null)
            cubesRuntimeSet.AddItem(this);
        else
            Debug.LogWarning($"{nameof(cubesRuntimeSet)} is empty in {gameObject.name}.");
    }

    private void OnDisable()
    {
        if (cubesRuntimeSet != null)
            cubesRuntimeSet.RemoveItem(this);
        else
            Debug.LogWarning($"{nameof(cubesRuntimeSet)} is empty in {gameObject.name}.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnFallOccured.Invoke();
    }
}

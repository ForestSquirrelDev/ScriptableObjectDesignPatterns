using SOPatterns.RuntimeSets;
using SOPatterns.Events;
using UnityEngine;
using UnityEngine.Events;

namespace SOPatterns.Game
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnFallOccured;
        [SerializeField] private CubesRuntimeSet cubesRuntimeSet;
        [SerializeField] private CubesTouchedEvent cubesTouched;

        private void OnEnable()
        {
            if (cubesRuntimeSet != null)
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
            cubesTouched.RaiseEvent(new CubeTouchedEventData(gameObject, GetComponent<SpriteRenderer>(), GetComponent<BoxCollider2D>()));
        }
    }
}
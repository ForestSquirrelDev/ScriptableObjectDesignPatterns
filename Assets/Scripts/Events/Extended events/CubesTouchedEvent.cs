using UnityEngine;

namespace SOPatterns.Events
{
    [CreateAssetMenu]
    public class CubesTouchedEvent : ScriptableEvent<CubeTouchedEventData>
    { }

    public struct CubeTouchedEventData {
        public GameObject cube;
        public SpriteRenderer spriteRenderer;
        public BoxCollider2D boxCollider;

        public CubeTouchedEventData(GameObject obj, SpriteRenderer sprite, BoxCollider2D collider) {
            this.cube = obj;
            this.spriteRenderer = sprite;
            this.boxCollider = collider;
        }
    }
}

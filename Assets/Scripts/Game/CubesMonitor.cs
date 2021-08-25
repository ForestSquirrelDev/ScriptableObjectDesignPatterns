using SOPatterns.RuntimeSets;
using SOPatterns.Events;
using UnityEngine;
using UnityEngine.UI;

namespace SOPatterns.Game
{
    public class CubesMonitor : MonoBehaviour
    {
        [SerializeField] private CubesTouchedEvent cubesTouched;
        [SerializeField] private CubesRuntimeSet cubes;
        [SerializeField] private Text text;

        private int previousCount = -1;

        private void OnEnable() {
            cubesTouched.AddListener(Test);
        }

        private void Update()
        {
            UpdateText();
        }

        private void OnDisable() {
            cubesTouched.RemoveListener(Test);
        }

        /// <summary>
        /// Comparing previous items count to current list state to avoid excessive text updates every frame.
        /// </summary>
        private void UpdateText()
        {
            if (previousCount != cubes.Items.Count)
            {
                text.text = "There are " + cubes.Items.Count.ToString() + " cube(s)";
                previousCount = cubes.Items.Count;
            }
        }

        private void Test(CubeTouchedEventData eventData) {
            Debug.Log($"Gameobject is: {eventData.cube}, SpriteRenderer is: {eventData.spriteRenderer}, boxcollider is: {eventData.boxCollider}");
        }
    }
}
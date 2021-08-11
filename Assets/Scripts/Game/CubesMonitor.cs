using UnityEngine;
using UnityEngine.UI;

public class CubesMonitor : MonoBehaviour
{
    [SerializeField] private CubesRuntimeSet cubes;
    [SerializeField] private Text text;

    private int previousCount = -1;

    private void Update()
    {
        UpdateText();
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
}

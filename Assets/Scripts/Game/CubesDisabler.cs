using UnityEngine;
using Random = UnityEngine.Random;

public class CubesDisabler : MonoBehaviour
{
    [SerializeField] private CubesRuntimeSet cubes;

    public void DisableRandomCube()
    {
        int index = Random.Range(0, cubes.Items.Count);
        cubes.Items[index].gameObject.SetActive(false);
    }

    public void DisableAllCubes()
    {
        for (int i = cubes.Items.Count - 1; i >= 0; i--)
            cubes.Items[i].gameObject.SetActive(false);
    }
}

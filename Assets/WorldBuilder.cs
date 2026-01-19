using System;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private float horizontalSpacing = 3.0f;

    // Use Unity's built-in range support for floats
    [SerializeField] private Vector2 verticalRange = new Vector2(-2f, 2f);

    private static int counter = 0;

    private void Start()
    {
        GeneratePipe(1);
    }

    private void GeneratePipe(int times)
    {
        for (int i = 0; i < times; i++)
        {
            GeneratePipe();
        }
    }

    private void GeneratePipe()
    {
        GameObject newPipe = Instantiate(pipe);

        Transform newPipeTransform = newPipe.transform;

        float x = counter * horizontalSpacing;
        float y = GenerateRandomYOffset();

        newPipeTransform.position = new Vector3(
            x,
            newPipeTransform.position.y + y,
            newPipeTransform.position.z
        );

        counter++;
    }

    private float GenerateRandomYOffset()
    {
        return UnityEngine.Random.Range(verticalRange.x, verticalRange.y);
    }
}

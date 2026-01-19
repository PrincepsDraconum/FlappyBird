using System;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private GameObject enemy;

    [SerializeField] private float horizontalSpacing = 3.0f;

    [SerializeField] private Vector2 pipeVerticalOffsetRange = new Vector2(-2f, 2f);
    [SerializeField] private Vector2 enemyVerticalOffsetRange = new Vector2(-3f, 3f);


    private static int counter = 0;

    private void Start()
    {
        GeneratePipe(5);
    }

    public void GeneratePipe(int times)
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
        float y = GenerateRandomYOffset(pipeVerticalOffsetRange);

        newPipeTransform.position = new Vector3(
            x,
            newPipeTransform.position.y + y,
            newPipeTransform.position.z
        );

        bool hasEnemy = DoesHaveEnemy(counter);
        if (hasEnemy)
        {
            GenerateEnemy();
        }

        counter++;
    }

    private void GenerateEnemy()
    {
        GameObject newPipe = Instantiate(enemy);

        Transform newPipeTransform = newPipe.transform;

        float x = counter * horizontalSpacing;
        float y = GenerateRandomYOffset(enemyVerticalOffsetRange);

        newPipeTransform.position = new Vector3(
            x,
            newPipeTransform.position.y + y,
            newPipeTransform.position.z
        );
    }

    private bool DoesHaveEnemy(int c)
    {
        return true;
    }

    private float GenerateRandomYOffset(Vector2 v)
    {
        return UnityEngine.Random.Range(v.x, v.y);
    }
}

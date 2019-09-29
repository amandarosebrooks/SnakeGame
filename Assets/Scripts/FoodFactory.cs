using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFactory : MonoBehaviour
{
    public Vector2Int MapTopLeft = Vector2Int.zero;
    public Vector2Int MapBottomRight = Vector2Int.zero;
    public float FoodSpawnTime = 1;
    public Snake snake;
    
    private void Start()
    {
        ResetFood();
    }

    public GameObject foodPrefab;

    public void SpawnFood()
    {
        if (!snake.IsAlive)
        {
            return;
        }

        GameObject obj = GameObject.Instantiate(foodPrefab);

        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(MapTopLeft.x, MapBottomRight.x), UnityEngine.Random.Range(MapTopLeft.y, MapBottomRight.y), 0);
        obj.transform.position = spawnPosition;
    }

    public void ResetFood()
    {
        CancelInvoke();

        Food[] foodStuffs = FindObjectsOfType<Food>();
        foreach (Food food in foodStuffs)
        {
            GameObject.Destroy(food.gameObject);
        }

        InvokeRepeating("SpawnFood", 1f, FoodSpawnTime);
    }


}

    //GameObject.Spawn(gameObject.Food);
    //   if snake collides.food ++ Food;
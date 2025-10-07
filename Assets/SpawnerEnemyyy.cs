using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class SpawnerEnemyyy : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjecjtEnemy;
    [SerializeField] private Vector2 initialPositionEnemy = new Vector2(-5, 5);
    public Stack<GameObject> stack;
     private float timeSpawn = 5f;
     private float _nextSpawnTime = 0f;
    void Start()
    {
       if(stack.Peek()==null)
        {
            InstantiateEnemys();
        }
        else
        {
            GameObject enemy = stack.Pop();
        }
    }
    public void Push(GameObject enemy)
    {
        stack.Push(enemy);
    }
    public void Pop()
    {
        stack.Pop().SetActive(true);
    }
    public void Peek()
    {
        Debug.Log(stack.Peek());
    }
    void Update()
    {
        InstantiateEnemys();
    }
    public void InstantiateEnemys()
    {
        if(Time.time >= _nextSpawnTime)
        {
            Instantiate(_gameObjecjtEnemy, initialPositionEnemy, Quaternion.identity);
            _nextSpawnTime = Time.time + timeSpawn;
        }
    }
}

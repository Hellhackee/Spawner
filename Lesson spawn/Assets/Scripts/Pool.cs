using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Enemy[] _enemyTemplates;
    [SerializeField] private float _respawnTime;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _pool;

    private float _elapsedTime = 0;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy enemy = Instantiate(_enemyTemplates[Random.Range(0, _enemyTemplates.Length)], _pool);
            enemy.gameObject.SetActive(false);

            _enemies.Add(enemy);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _respawnTime)
        {
            Transform point = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            
            if (TryGetEnemy(out Enemy enemy))
            {
                enemy.transform.position = point.position;
                enemy.gameObject.SetActive(true);
                _elapsedTime = 0;
            }
        }
    }

    private bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _enemies.FirstOrDefault(p => p.gameObject.activeSelf == false);
        
        return enemy != null;
    }
}

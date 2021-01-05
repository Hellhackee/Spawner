using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}

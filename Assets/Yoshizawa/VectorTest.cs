using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class VectorTest : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _stop = 0.5f;
    [SerializeField] float _speed = 0.01f;
    Vector3 _playerPosition;
    Vector3 _enemyPosition;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyPosition = transform.position;
    }

    void Update()
    {
        _playerPosition = _player.transform.position;
        float dis = Vector3.Distance(transform.position, _playerPosition);

        if(dis <= _stop)
        {
            Vector3 dir = (_player.transform.position - transform.position).normalized * _speed;
            transform.Translate(dir);
        }
        else
        {
            Vector3 set = (_enemyPosition - transform.position).normalized * _speed;
            transform.Translate(set);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    GameObject _player;
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] GameObject _destroyEffect;
    GameObject _gameManager;
    Vector3 _playerPos;
    int _score = 1;
    float _timer;
    void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        _playerPos = _player.transform.position;
        Vector3 dir = (_playerPos - transform.position).normalized * _speed * Time.deltaTime;
        _timer += Time.deltaTime;
        if(_timer >= 30)
        {
            _speed = 5f;
        }
        transform.Translate(dir);
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(_destroyEffect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Bullet")
        //{
        //    _hp--;
        //}
        if(collision.tag == "Slash")
        {
            var GM = _gameManager.GetComponent<Timer>();
            GM.AddScore(_score);
            _hp -= 5;
        }
    }
}

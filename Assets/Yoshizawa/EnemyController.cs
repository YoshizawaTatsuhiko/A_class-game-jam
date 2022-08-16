using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    GameObject _player;
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] GameObject _destroyEffect;
    [SerializeField] CircleCollider2D _col;
    Rigidbody2D _rb;
    GameObject _gameManager;
    Vector3 _playerPos;
    int _score = 1;
    float _timer;
    void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("GameManager");
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _playerPos = _player.transform.position;
        //Vector3 dir = (_playerPos - transform.position).normalized * _speed * Time.deltaTime;
        //transform.Translate(dir);
        _rb.velocity = (_playerPos - transform.position).normalized * _speed;
        _timer += Time.deltaTime;
        if(_timer >= 30)
        {
            _speed = 5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Slash")
        {
            var GM = _gameManager.GetComponent<Timer>();
            GM.AddScore(_score);
            _col.enabled = false;
            StartCoroutine(EnemyDestroy());
        }
    }
    IEnumerator EnemyDestroy()
    {
        Instantiate(_destroyEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}

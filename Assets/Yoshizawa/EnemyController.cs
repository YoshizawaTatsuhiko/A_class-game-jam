using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _speed;
    Vector3 _playerPos;
    Vector3 _enemyPos;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyPos = transform.position;
    }

    void Update()
    {
        _playerPos = _player.transform.position;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 dir = (_playerPos - transform.position).normalized * _speed;
        //transform.up = dir;
        transform.Translate(dir);
        //_rb.AddForce(dir,ForceMode2D.Impulse);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //player‚ªŒ©‚¦‚È‚­‚È‚Á‚½‚çŒ³‚Ìƒ|ƒWƒVƒ‡ƒ“‚É–ß‚é
        Vector3 set = (_enemyPos - transform.position).normalized * _speed;
        transform.up = set;
    }
}

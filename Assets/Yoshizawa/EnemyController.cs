using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    GameObject _player;
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    Vector3 _playerPos;
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        _playerPos = _player.transform.position;
        Vector3 dir = (_playerPos - transform.position).normalized * _speed;
        transform.Translate(dir);
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            _hp--;
        }
    }
    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    Vector3 dir = (_playerPos - transform.position).normalized * _speed;
    //    transform.Translate(dir);
    //}

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    //player‚ªŒ©‚¦‚È‚­‚È‚Á‚½‚çŒ³‚Ìƒ|ƒWƒVƒ‡ƒ“‚É–ß‚é
    //    Vector3 set = (_enemyPos - transform.position).normalized * _speed;
    //    transform.Translate(set);
    //}
}

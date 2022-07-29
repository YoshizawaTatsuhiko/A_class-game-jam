using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] int _hp;
    //[SerializeField] BoxCollider2D _bc;
    //[SerializeField] GameObject[] _enemyPosition;
    [SerializeField] float _meleeattack;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzlPosition;
    [SerializeField] GameObject _cursorPosition;
   //GameObject closeEnemy;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Vector2 dir = _cursorPosition.transform.position - transform.position;
        transform.up = dir;
        _rb.velocity = new Vector2(X * _moveSpeed, Y * _moveSpeed);
        if(_hp <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
        //_enemyPosition = GameObject.FindGameObjectsWithTag("Enemy");

        //float closeDist = 1000;

        //foreach (GameObject t in _enemyPosition)
        //{
        //    print(Vector3.Distance(transform.position, t.transform.position));
        //    float tDist = Vector3.Distance(transform.position, t.transform.position);

        //    if (closeDist > tDist)
        //    {
        //        closeDist = tDist;
        //        closeEnemy = t;
        //    }
        //}

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bulletPrefab, _muzzlPosition.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            _hp--;
        }
    }
}

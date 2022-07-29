using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCreate : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    BoxCollider2D _boxc;
    [SerializeField] float _totaltime;
    public float _time;
    // Start is called before the first frame update
    void Start()
    {
        _boxc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        float _X = Random.Range((-_boxc.size.x) / 2,(_boxc.size.x)/2);
        float _y = Random.Range((-_boxc.size.y) / 2,(_boxc.size.y)/ 2);
        if(_totaltime <= _time)
        {
            GameObject _create = Instantiate(_enemy);
            _create.transform.position = new Vector2(_X+transform.position.x, _y+transform.position.y);
            _time = 0;
        }
       
    }
}

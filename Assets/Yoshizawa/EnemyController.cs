using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _speed;
    [SerializeField, Range(0f,180f)] float _searchAngle;
    CircleCollider2D _circleCol;
    Vector3 _playerPos;
    Vector3 _enemyPos;
    void Start()
    {
        _enemyPos = transform.position;
    }

    void Update()
    {
        _playerPos = _player.transform.position;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var angle = Vector3.Angle(transform.up, _playerPos);

        if(angle <= _searchAngle)
        {
            Debug.Log("!!!");
            //collider���������Ă�Ԃ̓v���C���[��ǔ�����
            Vector3 dir = (_playerPos - transform.position).normalized * _speed;
            transform.Translate(dir);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //player�������Ȃ��Ȃ����猳�̃|�W�V�����ɖ߂�
        Vector3 set = (_enemyPos - transform.position).normalized * _speed;
        transform.Translate(set);
    }
}

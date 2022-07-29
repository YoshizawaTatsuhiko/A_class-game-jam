using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAreaController : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    CircleCollider2D _cc;
    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

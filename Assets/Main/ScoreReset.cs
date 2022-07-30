using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    GameObject _gameManager;
    // Start is called before the first frame update
    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager");
        var GM = _gameManager.GetComponent<Timer>();
        GM._score = 0;
    }
}

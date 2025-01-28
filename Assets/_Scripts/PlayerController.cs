using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _rb;
    private Vector2 _playerDir;
    
    private int _bubbleLifeTime = 0;
    private float elapsedTime = 0;
    
    public event Action<int> OnBubbleLifeTimeChanged;

    [SerializeField] private GameObject panelGameOver;
    
    public int GetBubbleLifeTime()
    {
        return _bubbleLifeTime;
    }
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        _playerDir = new Vector2(dirX, 0).normalized;


        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1f)
        {
            elapsedTime = 0;
            _bubbleLifeTime++;
            OnBubbleLifeTimeChanged?.Invoke(_bubbleLifeTime);
        }

        if (_bubbleLifeTime >= 8)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_playerDir.x * moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            _bubbleLifeTime = 0;
            OnBubbleLifeTimeChanged?.Invoke(_bubbleLifeTime);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
        _bubbleLifeTime = 0;
    }
    
}

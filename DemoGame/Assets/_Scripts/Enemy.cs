using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [FormerlySerializedAs("_speed")] [SerializeField]
    private float speed = 1f;

    private Rigidbody2D _rb2d;

    [FormerlySerializedAs("_crabDead")] [SerializeField]
    private GameObject crabDead;

    private Transform _playerTransform;

    public bool Stopped { get; set; } = false;

    public Action OnDeath;


    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        var player = FindAnyObjectByType<Player>();
        if (player is not null)
        {
            _playerTransform = player.transform;
            return;
        }

        Stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stopped) return;
        Move();
    }

    private void Move()
    {
        if (Stopped || _playerTransform is null)
        {
            _rb2d.velocity = Vector2.zero;
            return;
        }

        Vector3 directionToPlayer = _playerTransform.position - transform.position;
        _rb2d.velocity = directionToPlayer.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Weapon"))
        {
            Instantiate(crabDead, transform.position, Quaternion.identity);
            Destroy(gameObject);

            if (OnDeath is not null) HandleOnDeath();
        }
    }

    private void HandleOnDeath()
    {
        OnDeath.Invoke();
    }
}
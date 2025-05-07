using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlapPlayer : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody2D = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager = null;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren <Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("NOT FOUNDED ANIMATOR");
        }

        if ( _rigidbody2D == null)
        {
            Debug.LogError("NOT FOUNDED RIGIDBODY");
        }
    }

    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody2D.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody2D.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        gameManager.GameOver();
    }
}

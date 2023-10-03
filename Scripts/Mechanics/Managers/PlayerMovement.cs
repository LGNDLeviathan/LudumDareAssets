using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject parryGO;
    [SerializeField] Animator parryAnimator;

    [SerializeField] float invincibilityDuration;
    [SerializeField] float invincibilityDeltaTime;

    [SerializeField] float parryDurationDelay = 0.5f;
    private float parryDurationTimer = 0.5f;

    [SerializeField] float parryCooldownDelay = 5f;
    private float parryCooldownTimer = 0f; 

    private Vector2 movement = Vector2.zero;

    private bool isInvincible = false;
    private void Start()
    {
        parryGO.SetActive(false);
    }
    private void Update()
    {
        Move();
        RotateParry();
        Parry();

        parryDurationTimer -= Time.deltaTime;
        parryCooldownTimer -= Time.deltaTime;

        if(parryDurationTimer < 0 )
        {
            parryGO.SetActive(false);
        }
    }

    public void setInvincibility(bool isInvincible)
    {
        if (isInvincible)
        {
            StartCoroutine(ActivateIFrames());
        }

        this.isInvincible = isInvincible;
    }

    public bool getInvincibility()
    {
        return this.isInvincible;
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    private void RotateParry()
    {
        // if it's enabled don't rotate
        if (parryGO.activeSelf)
            return;

        // when input is 0 don't change the rotation
        if (movement == Vector2.zero)
            return;

        parryGO.transform.up = movement;
    }

    private void Parry()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && parryCooldownTimer <= 0)
        {
            parryCooldownTimer = parryCooldownDelay;
            parryDurationTimer = parryDurationDelay;
            parryGO.SetActive(true);
            parryAnimator.Play("parry");
        }
    }

    private IEnumerator ActivateIFrames()
    {
        //Add I frame logic here
        isInvincible = true;

        for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
        {
            if (sr.color == Color.white)
            {
                sr.color = Color.clear;
            }
            else
            {
                sr.color = Color.white;
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        isInvincible = false;
        sr.color = Color.white;
    }
}


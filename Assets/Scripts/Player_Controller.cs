using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float maxJumpTime;
    public Transform GroundPosition;
    public Transform AttackPositionTL, AttackPostitionBR;
    public LayerMask WhatIsGround;
    public GameObject sprite;
    public GameObject LoadingScreen;

    [Header("Weapon")]
    public GameObject PProjectile;
    public GameObject Gun;
    public Transform ShotPoint;
    public bool WeaponEquipped;
    [Header("SFX")]
    public AudioClip jumpsound;
    public AudioClip shootsound, attacksound, blockHitSound, LevelUpSound;

    Rigidbody2D rb;
    bool ableToJump, jumping, playedJump;
    float Height;
    float move;
    float ShotTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ShotTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (!WeaponEquipped)
        {
            Attack();
        }
        else
        {
            Shooting();
        }
        Inputs();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundPosition.position, 0.4f, WhatIsGround);

        if(colliders.Length >= 1)
        {
            jumping = false;
            ableToJump = true;
            MushroomDeathCollider.Multiplyer = 1;
        }
    }
    void Inputs()
    {
        move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
        {
            sprite.transform.localScale = new Vector3(10, 10, 1);
        }
        if (move < 0)
        {
            sprite.transform.localScale = new Vector3(-10, 10, 1);
        }

        if (Input.GetButtonUp("Jump"))
        {
            ableToJump = false;
            jumping = false;
            playedJump = false;
            Height = 0;
        }
        if (rb.velocity.y <= 0 && jumping)
        {
            ableToJump = false;
            jumping = false;
            Height = maxJumpTime;
        }
        if (Input.GetButton("Jump") && ableToJump)
        {
            if(!playedJump)
            {
                AudioSource.PlayClipAtPoint(jumpsound, transform.position);
                playedJump = true;
            }
            Height += Time.deltaTime * 10;
            if (Height < maxJumpTime)
            {
                jumping = true;
            }
            else
            {
                jumping = false;
            }
        }
    }
    void Movement()
    {
        if(jumping)
        {
            rb.velocity = Vector3.up * jumpHeight;
        }

        rb.velocity = new Vector3(move * speed, rb.velocity.y);
        if(rb.velocity.x == 0)
        {
            sprite.GetComponent<Animator>().SetBool("Moving", false);
        }
        else
        {
            sprite.GetComponent<Animator>().SetBool("Moving", true);
        }
    }
    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            sprite.GetComponent<Animator>().SetTrigger("Attack");
            AudioSource.PlayClipAtPoint(attacksound, transform.position);

            Collider2D[] hitObjects = Physics2D.OverlapAreaAll(AttackPositionTL.position, AttackPostitionBR.position);
            foreach(Collider2D Object in hitObjects)
            {
                if (Object.CompareTag("Enemy"))
                {
                    LifeSystem.Score += 100;
                    Object.GetComponentInChildren<MushroomDeathCollider>().Die();
                }
                if(Object.CompareTag("Brick"))
                {
                    if(Object.GetComponent<Brick>() !=null)
                    {
                        AudioSource.PlayClipAtPoint(blockHitSound, transform.position);
                        Object.GetComponent<Brick>().GetHit();
                    }
                }
                if(Object.CompareTag("CoinBox"))
                {
                    AudioSource.PlayClipAtPoint(blockHitSound, transform.position);
                    Object.GetComponentInChildren<Coin_Box>().TriggerCoin();
                }
                if(Object.CompareTag("Door"))
                {
                    AudioSource.PlayClipAtPoint(blockHitSound, transform.position);
                    Object.GetComponent<Door>().HitDoor();
                }
                if(Object.CompareTag("Asteroid"))
                {
                    AudioSource.PlayClipAtPoint(blockHitSound, transform.position);
                    Object.GetComponent<Aestroid_Move>().Hit();
                }
            }
        }
    }
    void Shooting()
    {
        ShotTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && ShotTimer > 0.5f)
        {
            AudioSource.PlayClipAtPoint(shootsound, transform.position);
            Instantiate(PProjectile, ShotPoint.position, ShotPoint.rotation);
            ShotTimer = 0;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            AudioSource.PlayClipAtPoint(LevelUpSound, transform.position);
            WeaponEquipped = true;
            Gun.SetActive(true);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Ship"))
        {
            StartCoroutine("ShipEscape");
        }
        if(collision.gameObject.CompareTag("Barell"))
        {
            GetComponent<LifeSystem>().LoseLife();
        }
    }
    IEnumerator ShipEscape()
    {
        Gun.SetActive(false);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Player_Controller>().enabled = false;
        AudioSource.PlayClipAtPoint(blockHitSound, Camera.main.transform.position);
        sprite.SetActive(false);
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Ship").GetComponent<Animator>().enabled = true;
        GameObject.FindGameObjectWithTag("Ship").GetComponent<Animator>().SetTrigger("ShipEscape");
        yield return new WaitForSeconds(2f);
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Donkey Kong");
    }
}

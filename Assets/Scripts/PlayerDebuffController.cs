using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebuffController : MonoBehaviour
{
    EnemyController debuff;
    PlayerMovement move;
    [SerializeField] GameObject lantern;
    [SerializeField] Timer canvasTimer;
    [SerializeField] float endTime = 0, lostTime = 0, lostSpeed = 0;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject[] sprites;
    float timer = 0, temp;
    bool isOn = false;
    Animator animator;
    AudioSource audioSource;
    [SerializeField] private casesSO channel;

    void Start()
    {
        move = GetComponent<PlayerMovement>();
        temp = move.speed;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        TurningOff();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isOn = true;
            timer = 0;
            audioSource.Play();
            other.gameObject.SetActive(false);
            Instantiate(particles, this.transform.position, this.transform.rotation);
            TimeOut();
        }
    }

    private void OnEnable()
    {
        channel.OnJulianHit += StateMachine;
    }

    private void OnDisable()
    {
        channel.OnJulianHit -= StateMachine;
    }

    bool created = false;
    void Sprite(int number) {
        if (created == false)
        {
            Instantiate(sprites[number], this.transform.position, Quaternion.identity);
            created = true;
        }
    }

    void TurningOff()
    {
        if (isOn == true && timer <= endTime)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= endTime)
        {
            move.speed = temp;
            animator.SetBool("isDancing", false);
            isOn = false;
            created = false;
            lantern.SetActive(true);
            timer = 0;
        }
    }

    void StateMachine(int type)
    {
        switch (type)
        {
            case 1:
                Slow();
                break;
            case 2:
                TimeOut();
                break;
            case 3:
                Root();
                break;
            case 4:
                Drunk();
                break;
            case 5:
                Blind();
                break;

            default:
                break;
        }
    }

    void Slow()
    {
        move.speed = lostSpeed;
        Sprite(0);
    }

    void TimeOut()
    {
        canvasTimer.GetComponent<Timer>().pretime -= lostTime;
        Sprite(1);
    }

    void Root()
    {
        move.speed = 0;
        animator.SetBool("isDancing", true);
        Sprite(2);
    }

    void Drunk()
    {
        move.speed = -temp;
        Sprite(3);
    }

    void Blind()
    {
        lantern.SetActive(false);
        Sprite(4);
    }
}

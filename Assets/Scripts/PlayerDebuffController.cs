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
        TurningOn();
        Slow();
        Root();
        Drunk();
        Blind();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //debuff = other.gameObject.GetComponent<EnemyController>();
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

    void TurningOn()
    {
        if (isOn == true && timer <= endTime)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= endTime)
        {
            isOn = false;
            timer = 0;
        }
    }

    void StateMachine(int type)
    {

    }

    void Slow()
    {
        if (isOn == true && debuff.debuffType == 1)
        {
            move.speed = lostSpeed;
            Sprite(0);     
        }
        else if (isOn == false)
        {
            move.speed = temp;
            created = false;
        }
    }

    void TimeOut()
    {
        if (isOn == true && debuff.debuffType == 2)
        {
            canvasTimer.GetComponent<Timer>().pretime -= lostTime;
            Sprite(1);
        }
        else
            created = false;
    }

    void Root()
    {
        if (isOn == true && debuff.debuffType == 3)
        {
            move.speed = 0;
            animator.SetBool("isDancing", true);
            Sprite(2);

        }
        else if (isOn == false)
        {
            move.speed = temp;
            animator.SetBool("isDancing", false);
            created = false;
        }
    }

    void Drunk()
    {
        if (isOn == true && debuff.debuffType == 4)
        {
            move.speed = -temp;
            Sprite(3);

        }
        else if (isOn == false)
        {
            move.speed = temp;
            created = false;
        }
    }

    void Blind()
    {
        if (isOn == true && debuff.debuffType == 5)
        {
            lantern.SetActive(false);
            Sprite(4);

        }
        else if (isOn == false)
        {
            lantern.SetActive(true);
            created = false;
        }
    }
}

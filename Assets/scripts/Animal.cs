using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string animalName;
    public bool playerInRange;

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;

    [Header("Sounds")]
    [SerializeField] AudioSource soundChannel;
    [SerializeField] AudioClip rabbitHitAndScream;
    [SerializeField] AudioClip rabbitHitAndDie;
    [SerializeField] AudioClip horseHitAndScream;
    [SerializeField] AudioClip horseHitAndDie;
    [SerializeField] AudioClip tigerHitAndScream;
    [SerializeField] AudioClip tigerHitAndDie;
    [SerializeField] AudioClip deerHitAndScream;
    [SerializeField] AudioClip deerHitAndDie;

    private Animator animator;
    public bool isDead;

    [SerializeField] ParticleSystem bloodSplashParticles;
    [SerializeField] GameObject bloodPuddle;
    enum AnimalType
    {
        Rabbit,
        Horse,
        Tiger,
        Deer
    }
    [SerializeField] AnimalType thisAnimalType;


    private void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        if(isDead == false)
        {
        currentHealth -= damage;

        bloodSplashParticles.Play();

        if(currentHealth <=0)
        {
            PlayDyingSound();
            animator.SetTrigger("DIE");
            GetComponent<AI_Movement>().enabled = false;

            bloodPuddle.SetActive(true);
            isDead = true;
        }
        else
        {
            PlayHitSound();
            
        }
        }
    }

    private void PlayDyingSound()
    {
        switch(thisAnimalType)
        {
            case AnimalType.Rabbit:
                soundChannel.PlayOneShot(rabbitHitAndDie);
                break;
            case AnimalType.Horse:
                soundChannel.PlayOneShot(horseHitAndDie);
                break;
            case AnimalType.Tiger:
                soundChannel.PlayOneShot(tigerHitAndDie);
                break;
            case AnimalType.Deer:
                soundChannel.PlayOneShot(deerHitAndDie);
                break;

            default:
                break;
        }
    }


    private void PlayHitSound()
    {
        switch(thisAnimalType)
        {
            case AnimalType.Rabbit:
                soundChannel.PlayOneShot(rabbitHitAndScream);
                break;
            case AnimalType.Horse:
                soundChannel.PlayOneShot(horseHitAndScream);
                break;
            case AnimalType.Tiger:
                soundChannel.PlayOneShot(tigerHitAndScream);
                break;
            case AnimalType.Deer:
                soundChannel.PlayOneShot(deerHitAndScream);
                break;

            default:
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
    if(other.CompareTag("Player"))
    {

        playerInRange = true;

    }
    }

    private void OnTriggerExit(Collider other)
    {
    if(other.CompareTag("Player"))
    {
        
        playerInRange = false;
   
    }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyControls : MonoBehaviour
{
    private int speed = 4;
    [SerializeField]
    [HideInInspector] Score control;

    private AudioSource explosionSound;

    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
        control = GameObject.FindGameObjectsWithTag("TITAN")[0].GetComponent<Score>();
    } 


    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6.7f)
        {
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            Destroy(collision.gameObject);

            explosionSound.Play();
            Destroy(this.gameObject);
            control.UpdateScore();
        }
        else if (collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();
            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
              explosionSound.Play();
            Destroy(this.gameObject);
        }
    }
}

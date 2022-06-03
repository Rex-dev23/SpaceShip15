using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControls : MonoBehaviour
{

    public GameObject laserPrefab;
    public float fireRate;
    public float nextFire;
    private int playerLives = 3;
    [SerializeField]
    TextMeshProUGUI TextDeathCount; 
    [SerializeField]
    TextMeshProUGUI TextScore;
    [SerializeField] 
    TextMeshProUGUI TextHP;
    [SerializeField]
    public int speed = 6;
   

    private AudioSource laserShot;



    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        print(playerLives);
        TextHP.text = "HP: " + playerLives;
    }



    void Update()
    {
        SpaceMovement();
        if (Input.GetMouseButton(0))
         
        {
            if (Time.time > nextFire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.3f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
                
            }
  
        }

    }

    public void LifeSubstraction()
    {
        playerLives--;
        print (playerLives);
        TextHP.text = "HP: " + playerLives;
        if (playerLives < 1)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

    }

    private void SpaceMovement()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.left * Time.deltaTime * speed * horizonInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertInput);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -4.07f)
        {
            transform.position = new Vector3(transform.position.x, -4.07f, 0);
        }
        if (transform.position.x > 9.7f)
        {
            transform.position = new Vector3(-9.7f, transform.position.y, 0);

        }
        else if (transform.position.y < -9.7f)
        {
            transform.position = new Vector3(9.7f, transform.position.y, 0);
        }


    }
}


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody))]

public class Dino : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float speed = 0.5f;
    public bool isGrounded;
    Rigidbody rb;

    private bool isDead;

    public Button ResetButton;
    public GameObject sign;
    public GameObject explosionLight;
    public GameObject rip;
    public GameObject dino;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        isDead = false;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void Update()
    {
        if (!isDead)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cactus")
        {
            ResetButton.gameObject.SetActive(true);

            isDead = true;

            //SceneManager.LoadScene("DedDino");
        }

        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "MeteorShower")
        {
            explosionLight.gameObject.SetActive(true);
            dino.gameObject.SetActive(false);
            rip.gameObject.SetActive(true);
            //ResetButton.gameObject.SetActive(true);
            //isDead = true;
        }

        if (collision.gameObject.tag == "ShowSign")
        {
            sign.gameObject.SetActive(true);
          
        }
    }
}
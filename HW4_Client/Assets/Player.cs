using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private Rigidbody2D rb;
    private Vector2 CurrentMovement;
    private float horizotnalInput;
    private float verticalInput;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        horizotnalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(horizotnalInput, verticalInput);
        Vector2 movementNormalized = movement.normalized;
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        CurrentMovement = movementSpeed;

        Vector2 currentMovePosition = rb.position + CurrentMovement * Time.fixedDeltaTime;
        rb.MovePosition(currentMovePosition);
    }

    void TakeDamage(int damage) {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}

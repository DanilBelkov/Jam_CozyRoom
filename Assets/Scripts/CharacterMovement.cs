using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость перемещения персонажа
    public float jumpForce = 0f; // Сила прыжка
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canJump;
    private static PlayerMovement instance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Зафиксировать вращение
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Создаем вектор движения
        Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);

        // Перемещаем персонажа
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        // Проверка, на земле ли персонаж
        isGrounded = IsGrounded();

        // Прыжок
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        // Проверка контакта с полом с помощью Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликаты объекта
        }
    }
}
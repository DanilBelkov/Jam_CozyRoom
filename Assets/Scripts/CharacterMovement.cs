using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �������� ����������� ���������
    public float jumpForce = 0f; // ���� ������
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canJump;
    private static PlayerMovement instance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ������������� ��������
    }

    void Update()
    {
        // �������� ���� � ����������
        float moveHorizontal = Input.GetAxis("Horizontal");

        // ������� ������ ��������
        Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);

        // ���������� ���������
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        // ��������, �� ����� �� ��������
        isGrounded = IsGrounded();

        // ������
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        // �������� �������� � ����� � ������� Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ��� �������� ����� �����
        }
        else
        {
            Destroy(gameObject); // ���������� ��������� �������
        }
    }
}
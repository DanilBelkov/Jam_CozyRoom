using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �������� ����������� ���������
    private Rigidbody2D rb;
    private bool isGrounded;
    private static PlayerMovement instance;

    private bool _isMooving;
    private Vector2 _targetPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ������������� ��������
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            SetTargetPosition();

        if (_isMooving)
            Move();

       // �������� ���� � ����������
       // float moveHorizontal = Input.GetAxis("Horizontal");

       // ������� ������ ��������
       //Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);

       // ���������� ���������
       // rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

       // ��������, �� ����� �� ��������
       // isGrounded = IsGrounded();

    }
    private void Move()
    {
        var newPosition = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
        if (transform.position.x == _targetPosition.x)
        {
            _isMooving = false;
        }
    }
    private void SetTargetPosition()
    {
        _targetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);

        _isMooving = true;
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
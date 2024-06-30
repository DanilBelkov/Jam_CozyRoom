using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float speed = 5f; // �������� ����������� ���������
    private Rigidbody2D rb;
    private static PlayerMovement instance;

    private bool _isMooving;
    private Vector2 _targetPosition;


    void Start()
    {
        rb = _player.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ������������� ��������
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            SetTargetPosition();

        if (_isMooving)
            Move();
    }
    private void Move()
    {
        if (!MenuManager.GameAcvive)
        {
            _isMooving = false;
            return;
        }

        var newPosition = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
        if (transform.position.x == _targetPosition.x)
        {
            _isMooving = false;
        }
    }
    private void SetTargetPosition()
    {
        if (!MenuManager.GameAcvive)
            return;

        _targetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);

        _isMooving = true;
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
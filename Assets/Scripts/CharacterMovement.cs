using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // Скорость перемещения персонажа
    private Rigidbody2D rb;
    private static PlayerMovement instance;

    private bool _isMooving;
    private Vector2 _targetPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Зафиксировать вращение
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
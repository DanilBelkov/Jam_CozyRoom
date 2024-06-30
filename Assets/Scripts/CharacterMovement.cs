using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _players;

    private GameObject _activePlayer;

    [SerializeField]
    private float speed = 5f; // Скорость перемещения персонажа
    private Rigidbody2D rb;
    private static PlayerMovement instance;

    private bool _isMooving;
    private Vector2 _targetPosition;


    void Start()
    {
        ActivePlayer(0);

        rb = _activePlayer.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Зафиксировать вращение
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0)
                && CheckForMove())
                SetTargetPosition();

            if (_isMooving)
                Move();
        }
    }
    
    private bool CheckForMove()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        return hitInfo.collider != null && hitInfo.collider.tag != "Target" ? true : false;
    }
    private void Move()
    {
        if (!MenuManager.GameAcvive)
        {
            _isMooving = false;
            return;
        }

        var newPosition = Vector2.MoveTowards(_activePlayer.transform.position, _targetPosition, speed * Time.deltaTime);
        _activePlayer.transform.position = new Vector3(newPosition.x, _activePlayer.transform.position.y, _activePlayer.transform.position.z);
        if (_activePlayer.transform.position.x == _targetPosition.x)
        {
            _isMooving = false;
        }
    }
    private void SetTargetPosition()
    {
        if (!MenuManager.GameAcvive)
            return;

        _targetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _activePlayer.transform.position.y);

        _isMooving = true;
    }

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(_activePlayer); // Сохраняем объект при загрузке новой сцены
    //    }
    //    else
    //    {
    //        Destroy(_activePlayer); // Уничтожаем дубликаты объекта
    //    }
    //}

    public void ActivePlayer(int index)
    {
        if (_players != null && index < _players.Length)
            _activePlayer = _players[index];
    }
}
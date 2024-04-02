using UnityEngine;

/// <summary>
/// ����� ���������������� ���������� ������
/// </summary>
public class BirdMover : MonoBehaviour
{
    /// <summary>
    /// ������ �� �����
    /// </summary>
    [SerializeField] private GameObject bird;

    /// <summary>
    /// ������ �� ���������� ����
    /// </summary>
    [SerializeField] private GameController gameController;

    private Rigidbody2D birdRigidbody;

    /// <summary>
    /// ������ ��� ������� ���������� ������ ��� ����� � ��������
    /// </summary>
    private const float AnimJumpHeight = 0f;

    /// <summary>
    /// ���� ������ �����
    /// </summary>
    private const float JumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        gameController.OnDead += Dead;
        gameController.OnRestart += Restart;
        birdRigidbody = bird.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalParams.isDead)
            return;

        if (!GlobalParams.isStart)
        {
            MenuAnimation();
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // ��������� ���� ������ � �����
            Jump();
        }
    }

    /// <summary>
    /// �������� ����������� ������ � ����
    /// </summary>
    private void MenuAnimation()
    {
        // ��������, ������ �� ������ ������������ ������ ��� ������
        if (bird.transform.position.y <= AnimJumpHeight)
            Jump();
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    private void Restart()
    {
        birdRigidbody.velocity = Vector2.zero;
        Vector2 newPosition = new Vector2(-1.67f, 0.02f);
        bird.transform.position = newPosition; // ��������� ����� ������� � �������
        birdRigidbody.angularVelocity = 0;
        bird.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        bird.GetComponent<Animator>().enabled = true;
    }

    /// <summary>
    /// ������ �����
    /// </summary>
    public void Dead()
    {
        bird.GetComponent<Animator>().enabled = false;
    }

    /// <summary>
    /// ����� �����
    /// </summary>
    private void Jump()
    {
        birdRigidbody.velocity = Vector2.up * JumpForce;
    }
}

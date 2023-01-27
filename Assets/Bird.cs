using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
  private Vector3 _initialPosition;

  [SerializeField]
  private float _launchPower = 100;

  private void Awake()
  {
    _initialPosition = transform.position;
  }

  private void Update()
  {
    if (transform.position.y > 8 || transform.position.x > 15)
    {
      string currentSceneName = SceneManager.GetActiveScene().name;
      SceneManager.LoadScene(currentSceneName);
    }
  }

  private void OnMouseDown()
  {
    GetComponent<SpriteRenderer>().color = Color.red;
  }

  private void OnMouseUp()
  {
    GetComponent<SpriteRenderer>().color = Color.white;
    Vector2 directionToInitialPosition = _initialPosition - transform.position;
    GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
    GetComponent<Rigidbody2D>().gravityScale = 1;
  }

  private void OnMouseDrag()
  {

    Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = new Vector3(newPosition.x, newPosition.y);

  }
}

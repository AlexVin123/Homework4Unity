
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _entranceDetected;
    [SerializeField] private UnityEvent _exitDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player))
        {
            _entranceDetected.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player))
        {
            _exitDetected.Invoke();
        }
    }
}

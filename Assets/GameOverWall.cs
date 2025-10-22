using UnityEngine;

public class GameOverWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.Instance.ShowGameover();
    }
}

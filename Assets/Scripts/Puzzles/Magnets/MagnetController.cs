using UnityEngine;

public class MagnetController : MonoBehaviour
{
    public GameObject blocks;

    public string direction;

    private Vector2 _vector;
    private void OnMouseDown()
    {
        _vector = direction switch
        {
            "down" => Vector2.down,
            "up" => Vector2.up,
            "left" => Vector2.left,
            "right" => Vector2.right,
            _ => _vector
        };
        Debug.Log("Clicked");
        foreach (var rb in blocks.transform.GetComponentsInChildren<Rigidbody2D>())
        {
            rb.AddForce(_vector * 500f);
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}

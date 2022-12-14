using UnityEngine;

public class PCPlayerController : MonoBehaviour //should be called playerMovementController really...
{
    public float speed;
    public Texture2D cursorTexture;
    private Rigidbody2D player;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(16,16),CursorMode.Auto);
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        LookAtCursor();
    }

    void FixedUpdate()
    {
        player.velocity = speed * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void LookAtCursor()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        lookPos = lookPos - player.transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

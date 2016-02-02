using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public float xMargin = 1.5f;
    public float yMargin = 1.5f;

    public float xSmooth = 1.5f;
    public float ySmooth = 1.5f;

    private Vector2 maxXandY;
    private Vector2 minXandY;

    public Transform player;

	// Use this for initialization
	void Awake () {
	    if (player == null)
        {
            Debug.LogError("Player object not found");
        }

        var backgroundBounds = GameObject.Find("background").GetComponent<Renderer>();

        var camera = GetComponent<Camera>();

        var camTopLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var camBottomRight = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minXandY.x = backgroundBounds.bounds.min.x - camTopLeft.x;
        maxXandY.x = backgroundBounds.bounds.max.x - camBottomRight.x;
	}

    bool checkXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool checkYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (checkXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }

        if (checkYMargin())
        {
            targetY = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}

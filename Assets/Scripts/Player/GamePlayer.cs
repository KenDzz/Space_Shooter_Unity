using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    [System.Serializable]
    public class Borders
    {
        public float minXOffset = 0.5f, maxXOffset = 0.5f, minYOffset = 0.5f, maxYOffset = 0.5f;
        [HideInInspector] public float minX, maxX, minY, maxY;
    }

    public int moveSpeed = 100;
    private Rigidbody2D rb;
    public Borders borders;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        ResizeBorders();
    }

    void FixedUpdate()
    {
    }

    void ResizeBorders()
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.one).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.one).y - borders.maxYOffset;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            mousePosition.x = Mathf.Clamp(mousePosition.x, borders.minX, borders.maxX);
            mousePosition.y = Mathf.Clamp(mousePosition.y, borders.minY, borders.maxY);
            rb.MovePosition(Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime));
        }

        // if left-mouse-button is being held OR there is at least one touch
        /*if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            // get mouse position in screen space
            // (if touch, gets average of all touches)
            Vector3 screenPos = Input.mousePosition;
            // set a distance from the camera
            screenPos.z = 10.0f;
            // convert mouse position to world space
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            // get current position of this GameObject
            Vector3 newPos = transform.position;
            // set x position to mouse world-space x position
            newPos.x = worldPos.x;
            //newPos.y = worldPos.y;
            // apply new position
            //transform.position = newPos;
            rb.MovePosition(newPos);
            Debug.Log(string.Format("action: {0}", Input.touches[0].phase));

        }*/


        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPostion = Camera.main.ScreenToViewportPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:

                    Debug.Log(string.Format("x: {0}| y: {1}", touchPostion.x, touchPostion.y));
                    // Calculates the initial distance between the object's position and the touch position
                    deltaX = (touchPostion.x - transform.position.x);
                    deltaY = (touchPostion.y - transform.position.y);

                    // Get the size of the current frame
                    float minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x + paddingFrame;
                    float maxX = Camera.main.ViewportToWorldPoint(Vector3.one).x - paddingFrame;
                    float minY = Camera.main.ViewportToWorldPoint(Vector3.zero).y + paddingFrame;
                    float maxY = Camera.main.ViewportToWorldPoint(Vector3.one).y - paddingFrame;

                    // Limit newXpos and newYpos values to frame range
                    deltaX = Mathf.Clamp(deltaX, minX, maxX);
                    deltaY = Mathf.Clamp(deltaY, minY, maxY);

                    break;

                case TouchPhase.Moved:

                    Debug.Log(string.Format("x: {0}| y: {1} |deltaX:{2}|deltaY:{3} ", touchPostion.x, touchPostion.y, deltaX, deltaY));

                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(touchPostion.x - deltaX, touchPostion.y - deltaY), 2 * Time.deltaTime);

                    //rb.MovePosition(new Vector2(touchPostion.x - deltaX, touchPostion.y - deltaY));
                    break;

                default:
                    Debug.Log(string.Format("default"));
                    //rb.velocity = Vector2.zero;
                    break;
            }
        }*/

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPostion = Camera.main.ScreenToViewportPoint(touch.position);
            touchPostion.z = 0;
            dir = (touchPostion - transform.position);
            rb.velocity = new Vector2 (dir.x, dir.y) * this.timeSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }*/


        /*float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * this.timeSpeed;
        float deltaY = Input.GetAxis("Vertical");
        float newYpos = transform.position.y + deltaY;
        float newXpos = transform.position.x + deltaX;

        // Get the size of the current frame
        float minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x + paddingFrame;
        float maxX = Camera.main.ViewportToWorldPoint(Vector3.one).x - paddingFrame;
        float minY = Camera.main.ViewportToWorldPoint(Vector3.zero).y + paddingFrame;
        float maxY = Camera.main.ViewportToWorldPoint(Vector3.one).y - paddingFrame;

        // Limit newXpos and newYpos values ??to frame range
        newXpos = Mathf.Clamp(newXpos, minX, maxX);
        newYpos = Mathf.Clamp(newYpos, minY, maxY);

        transform.position = new Vector2(newXpos, newYpos);
        
        Debug.Log(string.Format("newXpos: {0}| newYpos: {1} | maxX:{2}| maxY: {3}", newXpos, newYpos, maxX, maxY));
        */

    }
}

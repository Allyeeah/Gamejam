using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;

    [SerializeField]
    float height;
    float width;

    public float cameraSpeed = 5.0f;
    private int currentDirection = 1;

    public GameObject player;

    private void Start()
    {
        playerTransform = GameObject.Find("Player (1)").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentDirection = 1;
        }

        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3((dir.x + 2.3f * currentDirection) * cameraSpeed * Time.deltaTime, 
                                     (dir.y + 9.8f) * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);

        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
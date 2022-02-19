using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public GameObject player;

    public Tilemap map;
    private Vector3 leftDownBotton;
    private Vector3 rightUpBotton;

    public float halfHeigh;
    public float halfWidth;


    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;

        halfHeigh = Camera.main.orthographicSize;
        halfWidth = halfHeigh * Camera.main.aspect;

        leftDownBotton = map.localBounds.min + new Vector3(halfWidth, halfHeigh, -10);
        rightUpBotton = map.localBounds.max + new Vector3(-halfWidth, -halfHeigh, -10);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftDownBotton.x, rightUpBotton.x),
            Mathf.Clamp(transform.position.y, leftDownBotton.y, rightUpBotton.y),
            Mathf.Clamp(transform.position.z, leftDownBotton.z, rightUpBotton.z));

    }
}

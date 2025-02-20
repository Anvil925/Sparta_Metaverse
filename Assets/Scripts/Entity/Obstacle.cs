using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObejct;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public void Start()
    {
        gameManager = GameManager.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObejct.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placeposition = lastPosition + new Vector3(widthPadding, 0);
        placeposition.y = Random.Range(lowPosY, highPosY);

        transform.position = placeposition;

        return placeposition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player player = other.GetComponent<Player>();
        // if (player != null)
        //     // gameManager.AddScore(1);
    }
}

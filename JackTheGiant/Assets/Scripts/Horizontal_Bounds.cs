using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Bounds : MonoBehaviour
{
    private float minBound;
    private float maxBound;
    // Start is called before the first frame update
    void Start()
    {
        ComputeBounds();

    }

    // Update is called once per frame
    void Update()
    {
        float clamped_x = Mathf.Clamp(transform.position.x,minBound,maxBound);
        if (clamped_x != transform.position.x)
        {
            Vector2 vector = transform.position;
            vector.x = clamped_x;
            transform.position = vector;
        }
    }
    private void ComputeBounds() {
        float x_extent = (Camera.main.orthographicSize / Screen.height) * Screen.width * Camera.main.rect.width;
        float player_ext = GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        float cam_x_pos = Camera.main.transform.position.x;
        minBound = cam_x_pos - x_extent + player_ext;
        maxBound = cam_x_pos + x_extent - player_ext;
        Debug.Log("REPORT : MIN=" + minBound + " | maxBound =" + maxBound);
    }
}

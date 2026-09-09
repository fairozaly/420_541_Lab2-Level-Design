using UnityEngine;

public class TrapCorridor : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float phaseOffset = 0f;

    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.PingPong((Time.time + phaseOffset) * moveSpeed, moveDistance);
        transform.position = startPosition + new Vector3(offset, 0f, 0f);
    }
}

using UnityEngine;

public class AutoGrowingObject : MonoBehaviour
{
    public float minSize = 1f;      // Minimum size
    public float maxSize = 10f;     // Maximum size
    public float growthRate = 1f;   // Growth rate per second

    private float currentSize;
    private float targetSize;
    private float growthStartTime;

    private void Start()
    {
        currentSize = minSize;
        targetSize = minSize;
        growthStartTime = Time.time;
    }

    private void Update()
    {
        // Calculate the target size based on growthRate and time
        float growthTime = Time.time - growthStartTime;
        targetSize = Mathf.Lerp(minSize, maxSize, growthTime * growthRate);

        // Update the size of the object
        currentSize = Mathf.Lerp(currentSize, targetSize, Time.deltaTime);
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }
}

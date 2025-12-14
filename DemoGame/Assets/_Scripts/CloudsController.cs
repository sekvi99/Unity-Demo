using UnityEngine;

public class CloudsController : MonoBehaviour
{
[SerializeField] private Transform[] clouds = new Transform[6];

[SerializeField] private float speed = 1f;
[SerializeField] private float xLimit = 12.5f;
    
    // Update is called once per frame
    void Update()
    {
        foreach (var cloud in clouds)
        {
            cloud.position = cloud.position + Vector3.right * (speed * Time.deltaTime);
            
            if (cloud.position.x > xLimit)
            {
                cloud.position = new Vector3(-xLimit, cloud.position.y, cloud.position.z);
            }
        }
    }
}
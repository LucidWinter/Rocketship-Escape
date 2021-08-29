using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You hit a friendly object");
                break;
            case "Fuel":
                Debug.Log("You hit a fuel refiller");
                break;
            case "Finish":
                Debug.Log("You finished the level");
                break;
            default:
                Debug.Log("You hit an obstacle and took damage");
                break;
        }
    }
    
}

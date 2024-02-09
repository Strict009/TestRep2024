using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    private KeywordRecognizer recognizer;
    public Transform[] waypoints;  // Define the waypoints or nodes
    public float speed = 5.0f;     // Speed of movement
    private int currentWaypointIndex = 0;  // Index of the current waypoint
    public float gravity = 20.0f;
    public Camera cameraToLock;
    public GameObject Textdisappear;
    void Start()
    {
        // Define keywords and corresponding actions
        string[] keywords = { "start","stop","jump", "left", "right" };
        recognizer = new KeywordRecognizer(keywords);
        recognizer.OnPhraseRecognized += OnPhraseRecognized;
        recognizer.Start();
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        string command = args.text;
        switch (command)
        {
            case "start":
                Starting();
                break;
            case "jump":
                // Trigger jump action
                Jump();
                break;
            case "left":
                // Turn left action
                TurnLeft();
                break;
            case "right":
                // Turn right action
                TurnRight();
                break;
            case "stop":
                Stop();
                break;
            default:
                break;
        }
    }

    void Starting()
    {
        Textdisappear.SetActive(false);
    }
    void Stop()
    {
        
    }
    void Jump()
    {
        // Implement jump action
        Debug.Log("Jump action triggered!");
    }

    void TurnLeft()
    {
        // Implement turn left action
        Debug.Log("Turn left action triggered!");
    }

    void TurnRight()
    {
        // Implement turn right action
        Debug.Log("Turn right action triggered!");
    }
     void Update()
    {
        if (cameraToLock != null)
        {
            Vector3 currentRotation = cameraToLock.transform.localEulerAngles;
            cameraToLock.transform.localEulerAngles = new Vector3(currentRotation.x, 0f, currentRotation.z);
        }

        if (waypoints.Length > 0)
        {
            // Move towards the current waypoint
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if reached the current waypoint
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;

                // Check if reached the end of the path
                if (currentWaypointIndex >= waypoints.Length)
                {
                    Debug.Log("Reached the end of the path.");
                    // Stop the movement or trigger other actions
                    enabled = false;  // Disable this script to stop further movement
                }
            }
        }
    }
}


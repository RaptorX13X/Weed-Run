# Weed Run

### About the project
Weed Run was my first project at university finished in January 2023. It's a simple 2d platformer about a dealer fighting off the police with the goal to find the victory weed.
The highlight of this project is the enemy patrol mechanic, which makes the enemy move from point A to B giving the player an opportunity to attack from the back and avoid damage.

### How does it work
```csharp
public class Patrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField]private Transform leftEdge;
    [SerializeField]private Transform rightEdge;
    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField]private float idleDuration;
    private float idleTimer;
    [Header("Animator")]
    [SerializeField]private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
            initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
```
Each enemy has its own patrol points set up on the map, during the game it moves between the left and right point of the patrol. 
- In the Direction change method the walking animation gets turned off, enemy enters an idle state for a set duration, and when the idle state ends the bool responsible for the moving direction gets reversed.
- In the Move in direction method, the idle timer gets reset and the walking animation gets turned on. Then the objects local scale gets flipped on the X axis by the given direction int and then starts moving toward the next patrol stop.
- In the Update method the bool responsible for the direction sets up the rest of the script. 
- When the bool is set to go left, script checks if the object reached the left edge position and calls the move in direction method with int equal to -1. When the left edge is reached the direction change method is called.
- The same sequence happens when the bool is set to go right, but the Move in direction method is called with an int equal to 1.

using UnityEngine;

public class GoGameover : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPlace;
    [SerializeField]
    private Vector2 targetPlace;
    private Vector2 now;

    private static GoGameover instance;

    public static GoGameover Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GoGameover)FindObjectOfType(typeof(GoGameover));

                if (instance == null)
                {
                    Debug.LogError(typeof(GoGameover) + "is nothing");
                }
            }
            
            return instance;
        }
    }

    public bool CanMove = false;

    [SerializeField]
    private float easing;

    //[SerializeField]
    //private new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        now = new Vector2(startPlace.x, startPlace.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove)
        {
            now.x += (targetPlace.x - now.x) * easing;
            now.y += (targetPlace.y - now.y) * easing;
            this.transform.position = now;
        }
    }
}

using UnityEngine;

public class MoveImage : MonoBehaviour
{
    private float timer = 0.0f;
    private RectTransform rectTransform;

    private Vector2 position;
    [SerializeField]
    private float spped;
    private MoveMode moveMode = MoveMode.Wait;
	[SerializeField]
	private GameObject Canvas;
	private float moveUntilY;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        position = new Vector2(0, 0);
		RectTransform rect = Canvas.GetComponent<RectTransform>();
		moveUntilY = rect.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveMode)
        {
            case MoveMode.Wait:
                timer += Time.deltaTime;
                if (timer >= 4.0f)
                {
                    moveMode = MoveMode.Move;
                }
                break;

            case MoveMode.Move:
                position.y += spped;
                rectTransform.anchoredPosition = position;
                if (position.y >= moveUntilY)
                {
                    moveMode = MoveMode.End;
                }
                break;
        }
        
    }

    enum MoveMode
    {
        Wait,Move,End
    }
}

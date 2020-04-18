using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    public Transform[] buttonPositions;
    private Button[] buttons;
    private int btnIndex;
    private Vector3 fixerPos;
    private float horizontal;
    private float vertical;
    private KeyCode first;
    private KeyCode second;
    private enum Direction { Up, Down, Left, Right};
    // Start is called before the first frame update
    void Start()
    {
        horizontal = vertical = 0f;
        fixerPos = new Vector3(3.028f, 0f, 0f);
        buttons = new Button[buttonPositions.Length];
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = buttonPositions[i].GetComponent<Button>();
            Debug.Log(buttons[i].name);
        }
        btnIndex = 0;
        transform.position = buttonPositions[btnIndex].position - fixerPos;
        first = KeyCode.S;
        second = KeyCode.DownArrow;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (btnIndex >= 0 && btnIndex < buttons.Length)
        {
            if (ValidateDirection(Direction.Right) && btnIndex < 2)
                btnIndex += 2;
            else if (ValidateDirection(Direction.Left) && btnIndex >= 2)
                btnIndex -= 2;
            if (ValidateDirection(Direction.Up) && btnIndex > 0)
                btnIndex--;
            else if (ValidateDirection(Direction.Down) && btnIndex < buttons.LongLength - 1)
                btnIndex++;
        }
        transform.position = buttonPositions[btnIndex].position - fixerPos;
        if (Input.GetKeyDown(KeyCode.Return))
            buttons[btnIndex].onClick.Invoke();
    }
    private bool ValidateDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                first = KeyCode.W;
                second = KeyCode.UpArrow;
                break;
            case Direction.Down:
                first = KeyCode.S;
                second = KeyCode.DownArrow;
                break;
            case Direction.Left:
                first = KeyCode.A;
                second = KeyCode.LeftArrow;
                break;
            case Direction.Right:
                first = KeyCode.D;
                second = KeyCode.RightArrow;
                break;
        }
        if (Input.GetKeyDown(first) || Input.GetKeyDown(second))
            return true;
        return false;
    }
}

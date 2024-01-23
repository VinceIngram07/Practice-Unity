using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    public GameObject xPrefab; // Prefab for the X
    public GameObject oPrefab; // Prefab for the O

    private GameObject currentPlayerObject; // The current player's game object
    private int currentPlayer = 1; // 1 for Player X, -1 for Player O

    private int currentRow = 0; // Current row index in the grid
    private int currentCol = 0; // Current column index in the grid

    private GameObject[,] grid = new GameObject[3, 3]; // 3x3 grid

    private float cellSize = 2.0f; // Size of each cell
    private Vector3 gridOffset = new Vector3(37.8f, 21.5f, 38.5f); // Offset for the grid

    void Start()
    {
        SpawnPlayerObject();
    }

    void Update()
    {
        if (currentPlayer == -1)
        {
            // AI player's turn
            MakeAIMove();
            CheckForWinner();
            SwitchPlayer();
            SpawnPlayerObject();
        }
        else
        {
            HandleInput();
        }
    }

    void SpawnPlayerObject()
    {
        if (currentPlayer == 1)
        {
            currentPlayerObject = Instantiate(xPrefab);
        }
        else
        {
            currentPlayerObject = Instantiate(oPrefab);
        }

        currentPlayerObject.transform.position = GetCellPosition(currentRow, currentCol);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(1, 0); // Move left
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(-1, 0); // Move right
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(0, 1); // Move up
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(0, -1); // Move down
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            PlacePlayerObject();
            CheckForWinner();
            SwitchPlayer();
            SpawnPlayerObject();
        }
    }

    void Move(int rowChange, int colChange)
    {
        currentRow = Mathf.Clamp(currentRow + rowChange, 0, 2);
        currentCol = Mathf.Clamp(currentCol + colChange, 0, 2);

        currentPlayerObject.transform.position = GetCellPosition(currentRow, currentCol);
    }

    void PlacePlayerObject()
    {
        if (grid[currentRow, currentCol] == null)
        {
            grid[currentRow, currentCol] = currentPlayerObject;
        }
    }

    void SwitchPlayer()
    {
        currentPlayer = -currentPlayer; // Switch player (1 to -1 or -1 to 1)
    }

    Vector3 GetCellPosition(int row, int col)
    {
        float x = col * cellSize + gridOffset.x;
        float y = gridOffset.y - row * cellSize;
        return new Vector3(x, y, 0);
    }

    void CheckForWinner()
    {
        if (CheckForWinInRow() || CheckForWinInColumn() || CheckForWinInDiagonal())
        {
            Debug.Log("Player " + (currentPlayer == 1 ? "X" : "O") + " wins!");
            // You can add additional logic here, such as resetting the game
        }
    }

    bool CheckForWinInRow()
    {
        for (int row = 0; row < 3; row++)
        {
            if (AreEqual(grid[row, 0], grid[row, 1], grid[row, 2]))
            {
                return true;
            }
        }
        return false;
    }

    bool CheckForWinInColumn()
    {
        for (int col = 0; col < 3; col++)
        {
            if (AreEqual(grid[0, col], grid[1, col], grid[2, col]))
            {
                return true;
            }
        }
        return false;
    }

    bool CheckForWinInDiagonal()
    {
        if (AreEqual(grid[0, 0], grid[1, 1], grid[2, 2]) || AreEqual(grid[0, 2], grid[1, 1], grid[2, 0]))
        {
            return true;
        }
        return false;
    }

    bool AreEqual(GameObject a, GameObject b, GameObject c)
    {
        if (a == null || b == null || c == null)
        {
            return false;
        }

        return a.tag == b.tag && b.tag == c.tag;
    }

        void MakeAIMove()
    {
        // Simple AI: Make a random move
        int emptyCells = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (grid[row, col] == null)
                {
                    emptyCells++;
                }
            }
        }

        if (emptyCells > 0)
        {
            int randomIndex = Random.Range(0, emptyCells);
            int currentIndex = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (grid[row, col] == null)
                    {
                        if (currentIndex == randomIndex)
                        {
                            // Use a new GameObject for the AI player's move
                            GameObject aiMoveObject = Instantiate(oPrefab);
                            aiMoveObject.transform.position = GetCellPosition(row, col);

                            grid[row, col] = aiMoveObject;

                            return;
                        }

                        currentIndex++;
                    }
                }
            }
        }
    }

}

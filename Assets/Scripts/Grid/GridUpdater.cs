using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GridUpdater : MonoBehaviour
{
    public GridManager gridManager;
    public float updateDelay;

    public Text livesDisplay;
    public Text generationDisplay;
    public Text stateDisplay;

    private int poblation;
    private bool isRunning;
    private WaitForSeconds wait;

    private void Start()
    {
        isRunning = false;
        wait = new WaitForSeconds(updateDelay);
    }

    public void StartSequence()
    {
        stateDisplay.text = "State: Running";
        StartCoroutine(UpdateGrid());
    }

    public void StopSequence()
    {
        stateDisplay.text = "State: Stopped";
        StopAllCoroutines();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = !isRunning;

            if (isRunning)
            {
                StartSequence();
            }
            else
            {
                StopSequence();
            }
        }
    }

    private void LateUpdate()
    {
        poblation = CalculateLiveCells();
        livesDisplay.text = "Poblation: " + poblation;
    }

    private IEnumerator UpdateGrid()
    {
        int generation = 0;

        while (poblation > 0)
        {
            gridManager.CalculateNextGrid();
            gridManager.DisplayNextGrid();

            generation++;

            generationDisplay.text = "Generation: " + generation.ToString();
            yield return wait;
        }

        isRunning = false;
        stateDisplay.text = "State: Stopped - Extinction";
    }

    private int CalculateLiveCells()
    {
        int lives = 0;

        for (int i = 0; i < gridManager.CurrentGrid.GetLength(0); i++)
        {
            for (int j = 0; j < gridManager.CurrentGrid.GetLength(1); j++)
            {
                lives += gridManager.CurrentGrid[i, j];
            }
        }

        return lives;
    }
}
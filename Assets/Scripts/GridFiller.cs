using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFiller : MonoBehaviour
{
    [SerializeField] private GridConfiguration _gridConfiguration;
    [SerializeField] private Cell _cellPrefab;

    private List<Cell> cells;

    public event Action OnChangeState;

    private void Awake()
    {
        cells = new List<Cell>();
        for (var i = 0; i < _gridConfiguration.CountColumn * _gridConfiguration.CountRow; i++)
        {
            AddCell();
        }
    }

    private void AddCell()
    {
        var cell = Instantiate(_cellPrefab, transform);
        cells.Add(cell);
    }

    private void RemoveCell()
    {
        var cell = cells[0];
        cells.RemoveAt(0);
        Destroy(cell.gameObject);
    }

    public void Regenerate()
    {
        while (cells.Count < _gridConfiguration.CountColumn * _gridConfiguration.CountRow)
        {
            AddCell();
        }
        while(cells.Count > _gridConfiguration.CountColumn * _gridConfiguration.CountRow)
        {
            RemoveCell();
        }
        for (var i=0; i< cells.Count; i++)
        {
            cells[i].ChangeLetter();
        }
    }

    public void Shuffle()
    {
        var positions = new List<int>();
        for (var i = 0; i < cells.Count; i++)
        {
            positions.Add(i);
        }

        Shuffle(positions);

        StartCoroutine(ShuffleCells(positions));
    }

    public IEnumerator ShuffleCells(List<int> positions)
    {
        for (var i = 0; i < cells.Count; i++)
        {
            cells[i].StartMove(cells[positions[i]].TextPosition);
        }

        yield return new WaitForSeconds(2);
        
        var newCells = new List<Cell>();
        for (var i = 0; i < positions.Count; i++)
        {
            cells[positions.IndexOf(i)].transform.SetAsLastSibling();
            newCells.Add(cells[positions.IndexOf(i)]);
        }
        cells = newCells;
        if (OnChangeState != null)
        {
            OnChangeState.Invoke();
        }
    }

    public static void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i >= 1; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            var temp = list[j];
            list[j] = list[i];
            list[i] = temp;
        }
    }
}

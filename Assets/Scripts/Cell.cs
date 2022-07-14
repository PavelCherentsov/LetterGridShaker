using System.Collections;
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private readonly static string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string letter;

    public string Letter => letter;
    public Vector3 TextPosition => _textMeshPro.transform.position;

    private void Start()
    {
        ChangeLetter();
    }

    public void ChangeLetter()
    {
        letter = _alphabet[Random.Range(0, _alphabet.Length)].ToString();
        _textMeshPro.text = letter;
    }

    public void ChangeLetter(string letter)
    {
        this.letter = letter;
        _textMeshPro.text = letter;
    }

    public void StartMove(Vector3 endPosition)
    {
        StartCoroutine(Move(endPosition));
    }

    private IEnumerator Move(Vector3 endPosition)
    {
        var startposition = _textMeshPro.transform.position;
        for (float i=0; i <1; i+= Time.deltaTime / 2)
        {
            _textMeshPro.transform.position = Vector3.Lerp(startposition, endPosition, i);
            yield return null;
        }
        _textMeshPro.transform.position = startposition;
    }
         
}

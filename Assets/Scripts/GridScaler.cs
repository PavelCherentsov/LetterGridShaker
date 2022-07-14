using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridScaler : MonoBehaviour
{
    [SerializeField] private GridConfiguration _gridConfiguration;

    private GridLayoutGroup _gridLayoutGroup;
    private RectTransform _rectTransform;
    private float _width;
    private float _height;
    private Vector2 _spacing;

    private void Awake()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _width = _rectTransform.rect.width;
        _height = _rectTransform.rect.height;
        _spacing = _gridLayoutGroup.spacing;
    }

    public void Rescale()
    {
        var cellSize = (_width - _spacing.x * (_gridConfiguration.CountColumn + 1)) / _gridConfiguration.CountColumn;

        _gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
    }

}

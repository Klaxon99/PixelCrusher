using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellContainer : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material _unselectedMaterial;
    [SerializeField] private CubeGroupItemView _prefab;

    private Dictionary<int, Cell> _items;
    private UndoDrawing _undoDrawing;
    private DrawingSelect _drawingSelect;
    private ICellSelectHandler _currentDrawingMode;
    private bool _isContain;

    public void OnDrag(PointerEventData eventData)
    {
        _isContain = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isContain = false;
    }

    private void Awake()
    {
        _items = new Dictionary<int, Cell>();
        Cell[] childs = GetComponentsInChildren<Cell>();
        _undoDrawing = new UndoDrawing(_unselectedMaterial, _items);
        _drawingSelect = new DrawingSelect(_selectedMaterial, _items);
        _currentDrawingMode = _drawingSelect;

        for (int i = 0; i < childs.Length; i++)
        {
            Cell cell = childs[i];

            cell.Init(i + 1, this);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _currentDrawingMode = _undoDrawing;
        }

        if (Input.GetKey(KeyCode.F))
        {
            _currentDrawingMode = _drawingSelect;
        }
    }

    public void HandleSelection(Cell cell)
    {
        if (_isContain)
        {
            _currentDrawingMode.HandleSelection(cell);
        }
    }

    private void OnValidate()
    {
        _drawingSelect?.SetMaterial(_selectedMaterial);
    }

    [ContextMenu("CreateForm")]
    private void CreateForm()
    {
        CubesForm form = new GameObject("CubeForm").AddComponent<CubesForm>();
        Transform transform = form.transform;

        foreach (Cell cell in _items.Values)
        {
            Vector3 position = new Vector3(cell.Id % 30, cell.Id / 30, 0f);
            CubeGroupItemView cubeGroupItemView = Instantiate(_prefab, position, Quaternion.identity, transform);
            cubeGroupItemView.GetComponent<MeshRenderer>().material = cell.Material;
        }
    }
}

public interface ICellSelectHandler
{
    void HandleSelection(Cell cell);
}

public class DrawingSelect : ICellSelectHandler
{
    private Material _targetMaterial;
    private readonly Dictionary<int, Cell> _cells;

    public DrawingSelect(Material targetMaterial, Dictionary<int, Cell> cells)
    {
        _targetMaterial = targetMaterial;
        _cells = cells;
    }

    public void HandleSelection(Cell cell)
    {
        _cells[cell.Id] = cell;
        cell.SetMaterial(_targetMaterial);
    }

    public void SetMaterial(Material material)
    {
        _targetMaterial = material;
    }
}

public class UndoDrawing : ICellSelectHandler
{
    private readonly Dictionary<int, Cell> _cells;
    private Material _targetMaterial;

    public UndoDrawing(Material targerColor, Dictionary<int, Cell> cells)
    {
        _targetMaterial = targerColor;
        _cells = cells;
    }

    public void HandleSelection(Cell cell)
    {
        if (_cells.ContainsKey(cell.Id))
        {
            cell.SetMaterial(_targetMaterial);
            _cells.Remove(cell.Id);
        }
    }
}
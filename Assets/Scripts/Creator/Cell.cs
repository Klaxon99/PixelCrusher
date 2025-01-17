using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour, IPointerMoveHandler
{
    private CellContainer Container;
    private Image _image;
    
    public Material Material {  get; private set; }

    public int Id { get; private set; }

    public void Init(int id, CellContainer container)
    {
        _image = GetComponent<Image>();
        Id = id;
        Container = container;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Container.HandleSelection(this);
    }

    public void SetMaterial(Material material)
    {
        Material = material;
        _image.color = material.color;
    }
}
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _rightWall;
    [SerializeField] private Transform _upperWall;
    [SerializeField] private Transform _scoreZone;
    [SerializeField] private Transform _gunSpawnPoint;

    public void Init()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Vector3 maxPoint = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Vector3 minPoint = _camera.ScreenToWorldPoint(new Vector3());
        
        _leftWall.position = new Vector3(minPoint.x, 0);
        _rightWall.position = new Vector3(maxPoint.x, 0);
        _upperWall.position = new Vector3(0f, maxPoint.y);
        _scoreZone.position = new Vector3(0f, minPoint.y);

        float bottomPadding = 1.5f;

        _gunSpawnPoint.position = new Vector3(0f, minPoint.y + bottomPadding, _gunSpawnPoint.position.z);
    }
}
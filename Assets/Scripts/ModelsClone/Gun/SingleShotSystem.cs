using System;

public class SingleShotSystem : IShootControlSystem
{
    private readonly Timers _timers;
    private readonly float _reloadTime;

    private bool _canShoot = true;

    public SingleShotSystem(Timers timers, float reloadTime)
    {
        _timers = timers;
        _reloadTime = reloadTime;
    }

    public void TryShoot(Action shootAction)
    {
        if (_canShoot)
        {
            _canShoot = false;

            shootAction?.Invoke();
            _timers.AddItem(_reloadTime, () => _canShoot = true);
        }
    }
}

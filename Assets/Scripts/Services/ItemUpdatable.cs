using Assets.Scripts.Services;
using System;

public abstract class ItemUpdatable : IEventService
{
    private IUpdateService _updateService;

    protected ItemUpdatable(IUpdateService updateService)
    {
        _updateService = updateService ?? throw new ArgumentNullException();
    }

    public void Start()
    {
        _updateService.Updated += OnUpdate;
    }

    public void Stop()
    {
        _updateService.Updated -= OnUpdate;
    }

    protected abstract void OnUpdate(float deltaTime);
}
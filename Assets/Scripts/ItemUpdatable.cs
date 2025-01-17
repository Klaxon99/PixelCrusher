using System;

public abstract class ItemUpdatable
{
    private IUpdateService _updateService;

    protected ItemUpdatable(IUpdateService updateService)
    {
        _updateService = updateService ?? throw new ArgumentNullException();

        _updateService.Updated += OnUpdate;
        _updateService.Disabled += Disable;
    }

    private void Disable()
    {
        _updateService.Updated -= OnUpdate;
        _updateService.Disabled -= Disable;
    }

    protected abstract void OnUpdate(float deltaTime);
}
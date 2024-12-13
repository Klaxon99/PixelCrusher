using System;

public abstract class Update
{
    private IUpdateService _updateService;

    protected Update(IUpdateService updateService)
    {
        _updateService = updateService ?? throw new ArgumentNullException();
    }

    public virtual void Enable()
    {
        _updateService.Updated += OnUpdate;
    }

    public virtual void Disable()
    {
        _updateService.Updated -= OnUpdate;
    }

    protected abstract void OnUpdate(float deltaTime);
}
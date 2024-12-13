using Assets.Scripts.ModelsClone;

public interface IGunTransform
{
    public SpaceOrientation Transform(SpaceOrientation spaceOrientation, ITransformActions transformActions, float deltaTime);
}
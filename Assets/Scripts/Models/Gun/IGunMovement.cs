namespace Assets.Scripts.Models
{
    public interface IGunMovement
    {
        public SpaceOrientation Transform(SpaceOrientation spaceOrientation, ITransformActions transformActions, float deltaTime);
    }
}
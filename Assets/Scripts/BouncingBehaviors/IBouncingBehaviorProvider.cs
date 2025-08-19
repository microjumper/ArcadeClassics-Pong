namespace BouncingBehaviors
{
    public interface IBouncingBehaviorProvider
    {
        public IBounceBehavior BounceBehavior { get; }
    }
}
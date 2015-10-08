namespace Balloons.Memory
{
    using Balloons.FieldFactory.Field;

    public interface IFieldMemoryManager
    {
        void Save(IMemorable gameField);

        void Undo(IMemorable gameField);
    }
}

namespace Balloons.FieldFactory.Field
{
    using Balloons.Memory;

    public interface IMemorable
    {
        FieldMemory SaveField();

        void RestoreField(FieldMemory memento);
    }
}

public abstract class CharacterState : State
{
    protected Character character;

    public CharacterState(Character character)
    {
        this.character = character;
    }
}

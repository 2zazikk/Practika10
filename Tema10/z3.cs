using System;

// ================== COMMAND ==================
public interface ICommand
{
    void Execute();
}

// ================== RECEIVER ==================
public class GameCharacter
{
    public void Jump()
    {
        Console.WriteLine("Персонаж прыгает 🦘");
    }

    public void Attack()
    {
        Console.WriteLine("Персонаж атакует ⚔");
    }

    public void Defend()
    {
        Console.WriteLine("Персонаж защищается 🛡");
    }
}

// ================== CONCRETE COMMANDS ==================
public class JumpCommand : ICommand
{
    private GameCharacter _character;

    public JumpCommand(GameCharacter character)
    {
        _character = character;
    }

    public void Execute()
    {
        _character.Jump();
    }
}

public class AttackCommand : ICommand
{
    private GameCharacter _character;

    public AttackCommand(GameCharacter character)
    {
        _character = character;
    }

    public void Execute()
    {
        _character.Attack();
    }
}

public class DefendCommand : ICommand
{
    private GameCharacter _character;

    public DefendCommand(GameCharacter character)
    {
        _character = character;
    }

    public void Execute()
    {
        _character.Defend();
    }
}

// ================== INVOKER ==================
public class GameController
{
    public void RunCommand(ICommand command)
    {
        command.Execute();
    }
}

// ================== CLIENT ==================
class Program
{
    static void Main()
    {
        GameCharacter hero = new GameCharacter();

        ICommand jump = new JumpCommand(hero);
        ICommand attack = new AttackCommand(hero);
        ICommand defend = new DefendCommand(hero);

        GameController controller = new GameController();

        controller.RunCommand(jump);
        controller.RunCommand(attack);
        controller.RunCommand(defend);
    }
}
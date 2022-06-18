Robot bobby = new Robot();
string? commandEntry;




for (int i = 0; i < bobby.Commands.Length; i++)
{
    Console.WriteLine("Enter command: (O)n, of(F), (N)orth, (S)outh, (E)ast, or (W)est.");
    commandEntry = Console.ReadLine();

    RobotCommand newCommand = commandEntry switch
    {
        "O" => new OnCommand(),
        "F" => new OffCommand(),
        "N" => new NorthCommand(),
        "S" => new SouthCommand(),
        "E" => new EastCommand(),
        "W" => new WestCommand(),

    };
    bobby.Commands[i] = newCommand;
}
bobby.Run();
Console.ReadKey();



public class Robot
{
    public int x { get; set; }
    public int y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{x} {y} {IsPowered}]");
        }
    }


}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);

}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
        
    }

}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
        
    }

}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.y += 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.y -= 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.x -= 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.x += 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}
using System;

internal interface ICommand
{
    void Execute();
    void Undo();
}

internal sealed class Light
{
    private readonly string _location;

    public Light(string location) => _location = location;

    public void TurnOn() => Console.WriteLine($"{_location} light is ON");
    public void TurnOff() => Console.WriteLine($"{_location} light is OFF");
}

internal sealed class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light) => _light = light;

    public void Execute() => _light.TurnOn();
    public void Undo() => _light.TurnOff();
}

internal sealed class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light) => _light = light;

    public void Execute() => _light.TurnOff();
    public void Undo() => _light.TurnOn();
}

internal sealed class RemoteControl
{
    private ICommand? _command;
    private ICommand? _lastCommand;

    // Set which command the remote will run
    public void SetCommand(ICommand command) => _command = command;

    // Execute the current command
    public void PressExecute()
    {
        if (_command is null) { Console.WriteLine("No command assigned."); return; }
        _command.Execute();
        _lastCommand = _command;
    }

    // Undo the last executed command
    public void PressUndo()
    {
        if (_lastCommand is null) { Console.WriteLine("Nothing to undo."); return; }
        _lastCommand.Undo();
        _lastCommand = null;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Command pattern demo:");

        var livingRoomLight = new Light("Living Room");
        var kitchenLight = new Light("Kitchen");

        var livingRoomOn = new LightOnCommand(livingRoomLight);
        var livingRoomOff = new LightOffCommand(livingRoomLight);
        var kitchenOn = new LightOnCommand(kitchenLight);

        var remote = new RemoteControl();

        // Turn living room light on
        remote.SetCommand(livingRoomOn);
        remote.PressExecute();

        // Undo the last action (turn it off)
        remote.PressUndo();

        // Turn living room light off explicitly
        remote.SetCommand(livingRoomOff);
        remote.PressExecute();

        // Switch to kitchen light on
        remote.SetCommand(kitchenOn);
        remote.PressExecute();

        // Undo kitchen on
        remote.PressUndo();
    }
}
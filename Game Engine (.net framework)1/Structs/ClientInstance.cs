internal class ClientInstance
{
    public static ClientInstance Instance { get; private set; } = new ClientInstance();

    public Level Level = new Level();
    public FontRepository FontRepos = new FontRepository();
    public GuiData GuiData = new GuiData();
}
public class EngineInstance
{
    public static EngineInstance Instance { get; private set; } = new EngineInstance();

    public Level Level = new Level();
    public FontRepository FontRepos = new FontRepository();
    public GuiData GuiData = new GuiData();
}
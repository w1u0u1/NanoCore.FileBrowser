namespace FileBrowserClient
{
    public enum CommandTypes : byte
	{
		MachineName,
		Drives,
		Files,
		GetCurrentDirectory,
		SetCurrentDirectory,
		Download,
		Upload,
		Open,
		Delete,
		CreateDirectory,
		Rename
	}
}
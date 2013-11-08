
namespace UndoRedoBuddy
{
	/// <summary>
	/// this class wraps a command for the undo/redo stack
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// run this command!
		/// </summary>
		/// <returns>bool: whether or not the command executed successfully</returns>
		bool Execute();

		/// <summary>
		/// undo a command!
		/// </summary>
		/// <returns>bool: whether or not the command was undone successfully</returns>
		bool Undo();
	}
}
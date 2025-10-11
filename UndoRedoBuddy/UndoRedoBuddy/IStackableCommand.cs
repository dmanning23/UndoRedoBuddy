using System;
using System.Collections.Generic;
using System.Text;

namespace UndoRedoBuddy
{
	/// <summary>
	/// This is a type of command that is stackable.
	/// If added to the stack on top of a stackablecommand of the same type, they are put together.
	/// When the "undo" method is called, the whole thing is undone at once.
	/// </summary>
    public interface IStackableCommand : ICommand
    {
		/// <summary>
		/// Given the next command, compare with this one to see if they can be stacked.
		/// </summary>
		/// <param name="nextCommand">The new command to be compared with.</param>
		/// <returns>if true, the next command is not executed.</returns>
		bool CompareWithNextCommand(IStackableCommand nextCommand);

		/// <summary>
		/// Given the next command, stack it on top of this one.
		/// </summary>
		/// <param name="nextCommand"></param>
		/// <returns></returns>
		void StackWithNextCommand(IStackableCommand nextCommand);
	}
}

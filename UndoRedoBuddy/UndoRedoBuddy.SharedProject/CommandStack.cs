using System.Collections.Generic;

namespace UndoRedoBuddy
{
	/// <summary>
	/// This command is a collection of several commands to execute at the same time.
	/// </summary>
	public class CommandStack : ICommand
	{
		#region Members

		/// <summary>
		/// all the commands that will be run by this macro
		/// </summary>
		public List<ICommand> CommandList { get; private set; }

		#endregion //Methods 

		#region Methods

		/// <summary>
		/// hello, standard constructor!
		/// </summary>
		public CommandStack()
		{
			CommandList = new List<ICommand>();
		}

		/// <summary>
		/// run this command!
		/// </summary>
		/// <returns>bool: whether or not the command executed successfully</returns>
		public bool Execute()
		{
			//Execute all those actions!
			for (int i = 0; i < CommandList.Count; i++)
			{
				if (!CommandList[i].Execute())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// undo a command!
		/// </summary>
		/// <returns>bool: whether or not the command was undone successfully</returns>
		public bool Undo()
		{
			//undo that whole list of actions
			for (int i = 0; i < CommandList.Count; i++)
			{
				if (!CommandList[i].Undo())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Add an action to the list to be executed
		/// </summary>
		/// <param name="command">action to add to the list</param>
		public void Add(ICommand command)
		{
			CommandList.Add(command);
		}

		#endregion //Methods
	}
}
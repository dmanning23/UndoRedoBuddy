using System.Collections.Generic;

namespace UndoRedoBuddy
{
	/// <summary>
	/// This class does all teh undo/redo functionality of this tool.
	/// </summary>
	public class UndoRedoStack
	{
		#region Properties

		/// <summary>
		/// the list of actions that can be undone
		/// </summary>
		public LinkedList<ICommand> UndoStack { get; private set; }

		/// <summary>
		/// the list of actions that can be redone
		/// </summary>
		public LinkedList<ICommand> RedoStack { get; private set; }

		/// <summary>
		/// maximum number of actions to store in the action stack
		/// </summary>
		public uint MaxStackSize { get; set; }

		#endregion //Properties

		#region Methods

		/// <summary>
		/// hello, standard constructor!
		/// </summary>
		public UndoRedoStack()
		{
			UndoStack = new LinkedList<ICommand>();
			RedoStack = new LinkedList<ICommand>();
			MaxStackSize = 100;
		}

		/// <summary>
		/// execute and store a command
		/// </summary>
		/// <param name="myAction">the command to be executed</param>
		/// <returns>bool: whether or not it was able to execute the command</returns>
		private bool Execute(ICommand myAction)
		{
			if (myAction.Execute())
			{
				UndoStack.AddLast(myAction);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Execute and add a command to the undo stack
		/// this also clears out the redo list, and checks if the undo list is greater than max size.
		/// </summary>
		/// <param name="myAction">The command to execute and add to the undo list</param>
		/// <returns>bool: whether or not it was able to execute the command</returns>
		public bool Add(ICommand myAction)
		{
			//execute the action
			if (!Execute(myAction))
			{
				return false;
			}

			//clear out redo list
			RedoStack.Clear();

			//check if the undo list is too long
			while (MaxStackSize <= UndoStack.Count)
			{
				UndoStack.RemoveFirst();
			}
			return true;
		}

		/// <summary>
		/// Pop the most recent action off the undo stack, undo it, and add it to the redo list
		/// </summary>
		public void Undo()
		{
			//make sure there is an action to undo
			if (UndoStack.Count > 0)
			{
				//remove the most recent action from the undo list
				ICommand lastAction = UndoStack.Last.Value;
				UndoStack.RemoveLast();
				if (lastAction.Undo())
				{
					//add to the end of the redo
					RedoStack.AddLast(lastAction);
				}
			}
		}

		/// <summary>
		/// pop the most recent action off the redo stack, execute it, and add it to the undo stack
		/// </summary>
		/// <returns>bool: whether or not it was able to redo the action</returns>
		public bool Redo()
		{
			//make sure there is an action to redo
			if (RedoStack.Count > 0)
			{
				//pop the most recent action off the redo list, do it
				ICommand lastAction = RedoStack.Last.Value;
				RedoStack.RemoveLast();
				return Execute(lastAction);
			}
			return true;
		}

		/// <summary>
		/// clean out both lists of actions
		/// </summary>
		public void Flush()
		{
			UndoStack.Clear();
			RedoStack.Clear();
		}

		#endregion //Methods
	}
}
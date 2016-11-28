using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoRedoBuddy.Tests
{
	[TestFixture]
	public class UndoRedoTests
	{
		UndoRedoStack _stack;

		[SetUp]
		public void Setup()
		{
			_stack = new UndoRedoStack();
		}
	}
}

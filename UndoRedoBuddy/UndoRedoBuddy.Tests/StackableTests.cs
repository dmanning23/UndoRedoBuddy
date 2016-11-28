using NUnit.Framework;

namespace UndoRedoBuddy.Tests
{
	[TestFixture]
	public class StackableTests
	{
		#region Fields

		UndoRedoStack _stack;

		#endregion //Fields

		#region Setup

		[SetUp]
		public void Setup()
		{
			_stack = new UndoRedoStack();
		}

		#endregion //Setup

		#region Tests

		[Test]
		public void DoOne()
		{
			var num = new Class2()
			{
				Name = "test",
				Num = 10
			};

			var num1 = new Class1(num)
			{
				NextNum = 20
			};

			_stack.Add(num1);

			Assert.AreEqual(20, num.Num);
			Assert.AreEqual(1, _stack.UndoStack.Count);
		}

		[Test]
		public void UndoOne()
		{
			var num = new Class2()
			{
				Name = "test",
				Num = 10
			};

			var num1 = new Class1(num)
			{
				NextNum = 20
			};

			_stack.Add(num1);
			_stack.Undo();

			Assert.AreEqual(10, num.Num);
			Assert.AreEqual(0, _stack.UndoStack.Count);
		}

		[Test]
		public void DoTwo()
		{
			var num = new Class2()
			{
				Name = "test",
				Num = 10
			};

			var num1 = new Class1(num)
			{
				NextNum = 20
			};

			var num2 = new Class1(num)
			{
				NextNum = 30
			};

			_stack.Add(num1);
			_stack.Add(num2);

			Assert.AreEqual(30, num.Num);
			Assert.AreEqual(1, _stack.UndoStack.Count);
		}

		[Test]
		public void UndoTwo()
		{
			var num = new Class2()
			{
				Name = "test",
				Num = 10
			};

			var num1 = new Class1(num)
			{
				NextNum = 20
			};

			var num2 = new Class1(num)
			{
				NextNum = 30
			};

			_stack.Add(num1);
			_stack.Add(num2);
			_stack.Undo();

			Assert.AreEqual(10, num.Num);
			Assert.AreEqual(0, _stack.UndoStack.Count);
		}

		#endregion //Tests

		#region Test Classes

		private class Class2
		{
			public string Name { get; set; }
			public int Num { get; set; }
		}

		private class Class1 : IStackableCommand
		{
			Class2 _num;
			int _prev;
			public int NextNum;

			public Class1(Class2 num)
			{
				_num = num;
				_prev = num.Num;
			}

			public bool CompareWithNextCommand(IStackableCommand nextCommand)
			{
				var next = nextCommand as Class1;
				return (next != null && next._num.Name == _num.Name);
			}

			public bool Execute()
			{
				_num.Num = NextNum;
				return true;
			}

			public void StackWithNextCommand(IStackableCommand nextCommand)
			{
				var next = nextCommand as Class1;
				if (next != null)
				{
					NextNum = next.NextNum;
				}
			}

			public bool Undo()
			{
				_num.Num = _prev;
				return true;
			}
		}

		#endregion //Test Classes
	}
}

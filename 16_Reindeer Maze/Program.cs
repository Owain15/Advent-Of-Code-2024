

// Hint:
//		Dijkstra;s Algorithem.




using System.Xml.Linq;

RunPartOne();


void RunPartOne()
{
	char[,] validInput = InputTo2DCharArray(InputData.Test);
	Print2DCharArray(validInput);
	Console.ReadKey();
	List<NodeData> nodeList = GetNodeList(validInput);
	PrintNodes(validInput, nodeList);
	Console.ReadKey();
	PrintNodeConections(validInput, nodeList);
	Console.ReadKey();

}




//convert input to 2D array
char[,] InputTo2DCharArray(string InputSource)
{
	string[] tempInputData = File.ReadAllLines(InputSource);

	////test
	//foreach (var line in tempInputData)
	//{ Console.WriteLine(line); }
	////passed.

	int arrayLength = tempInputData[0].Length;
	int arrayHeight = tempInputData.Length;

	char[,] input = new char[arrayHeight, arrayLength];

	for (int row = 0; row < arrayHeight; row++)
	{
		for (int col = 0; col < arrayLength; col++)
		{
			input[col, row] = tempInputData[row][col];
		}
	}

	////test
	//Print2DCharArray(input);
	//// passed
	///

	return input;
}

//find a List Of Junction(node) coordernates.
List<NodeData> GetNodeList(char[,] cellData)
{
	List<NodeData> nodeList = new List<NodeData>();
	char[] activeCell = new char[] { '.', 'S', 'E' };


	for (int row = 0; row < cellData.GetLength(1); row++)
	{
		for (int col = 0; col < cellData.GetLength(0); col++)
		{

			if (activeCell.Contains(cellData[row, col]))
			{
				bool up = false;
				bool down = false;
				bool left = false;
				bool right = false;

				if (activeCell.Contains(cellData[col, row - 1])) { up = true; }
				if (activeCell.Contains(cellData[col, row + 1])) { down = true; }
				if (activeCell.Contains(cellData[col - 1, row])) { left = true; }
				if (activeCell.Contains(cellData[col + 1, row])) { right = true; }

				int validMoves = 0;

				if (up) { validMoves++; }
				if (down) { validMoves++; }
				if (left) { validMoves++; }
				if (right) { validMoves++; }

				if (validMoves > 2 || validMoves == 2 && up != down && left != right)
				{
					NodeData node = new NodeData(col, row, up, down, left, right);
					nodeList.Add(node);

					////test
					//Console.SetCursorPosition(node.x, node.y);
					//Console.WriteLine("O");
					//Console.ReadKey();
					////passed
				}





				//valid moves < 2 = dead end

			}



		}
	}

	return nodeList;
}



//create List storing Paths to Exit


//compair paths to return lowest score




void Print2DCharArray(char[,] input)
{
	for (int row = 0; row < input.GetLength(1); row++)
	{
		string wholeRow = "";

		for (int col = 0; col < input.GetLength(0); col++)
		{
			wholeRow = wholeRow + input[col, row];
		}

		Console.WriteLine(wholeRow);
	}
}
void PrintNodes(char[,] validData, List<NodeData> nodeList)
{
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.BackgroundColor = ConsoleColor.Cyan;

	foreach (var node in nodeList)
	{
		Console.SetCursorPosition(node.x, node.y);
		Console.WriteLine(validData[node.x, node.y]);
	}

	Console.ResetColor();

}
void PrintNodeConections(char[,] validData, List<NodeData> nodeList)
{
	foreach (var node in nodeList)
	{
		Console.BackgroundColor = ConsoleColor.Red;

		//path up. check if value has been set
		if (node.validMoves[0] && node.upRange < 0)
		{
			//Console.SetCursorPosition(node.x, node.y);
			//Console.WriteLine(validData[node.x, node.y]);
			//Console.ReadKey();

			int pathLength = validData.GetLength(0);
			int pathCheck = 1;

			//check path Length
			for (int i = 1; i < validData.GetLength(0) - node.x; i--)
			{
				if (validData[node.x, node.y - i] == '#') { pathCheck = i + 1; }
			}

			// check distence to next node
			foreach (var nextNode in nodeList)
			{
				if (nextNode.x == node.x && nextNode.y < node.y && node.y - nextNode.y < pathLength)
				{ pathLength = node.y - nextNode.y; }
			}

			//Console.SetCursorPosition(node.x, node.y-pathLength);
			//Console.WriteLine(validData[node.x, node.y-pathLength]);
			//Console.ReadKey();

			//identify and remove dead ends.
			if (pathLength > pathCheck) { node.validMoves[0] = false; }

			// set node range
			if (node.validMoves[0])
			{
				node.SetUpRange(pathLength - 1);
				//nextnode?
			}
			for (int row = node.y - 1; row > node.y - pathLength - 1; row--)
			{
				Console.SetCursorPosition(node.x, row);
				Console.WriteLine(validData[node.x, row]);
			}
		}

		////path down
		//if (node.validMoves[1])
		//{
		//	//Console.SetCursorPosition(node.x, node.y);
		//	//Console.WriteLine(validData[node.x, node.y]);
		//	//Console.ReadKey();

		//	int pathLength = validData.GetLength(0);
		//	int pathCheck = 1;

		//	//check path Length
		//	for (int i = 1; i < validData.GetLength(0) - node.x; i++)
		//	{
		//		if (validData[node.x, node.y + i] == '#') { pathCheck = i - 1; }
		//	}

		//	// check distence to next node
		//	foreach (var nextNode in nodeList)
		//	{
		//		if (nextNode.x == node.x && nextNode.y > node.y && nextNode.y - node.y < pathLength)
		//		{ pathLength = nextNode.y - node.y; }
		//	}

		//	//identify and remove dead ends.
		//	if (pathLength > pathCheck) { node.validMoves[1] = false; }

		//	//Console.SetCursorPosition(node.x, node.y-pathLength);
		//	//Console.WriteLine(validData[node.x, node.y-pathLength]);
		//	//Console.ReadKey();

		//	//update valid node range for both nodes 
		//	if (node.validMoves[1])
		//	{
		//		node.SetDownRange(pathLength + 1);
		//		//for (int row = node.y + 1; row < node.y + pathLength + 1; row++)
		//		//{
		//		//	Console.SetCursorPosition(node.x, row);
		//		//	Console.WriteLine(validData[node.x, row]);
		//		//	Console.ReadKey();
		//		//}
		//	}

		}

		Console.ResetColor();
	}

}


public static class InputData
{
	public static string Test = "testInput.txt";
	public static string PuzzleInput = "puzzleInput.txt";
}

public static class Directions
{
	public static Char Up = '^';
	public static Char Down = 'v';
	public static Char Left = '<';
	public static Char Right = '>';

}

public struct NodeData
{
	public int x, y;

	public bool[] validMoves;

	public int upRange, downRange, leftRange, rightRange;

	public NodeData(int xCoordinate, int yCoordinate, bool up, bool down, bool left, bool right)
	{
		x = xCoordinate;
		y = yCoordinate;

		validMoves = new bool[4]
			{up,down,left,right };
		upRange = 0;
		downRange = 0;
		leftRange = 0;
		rightRange = 0;


	}
	public void SetUpRange(int range)
	{ upRange = range; }
	public void SetDownRange(int range)
	{ downRange = range; }




}




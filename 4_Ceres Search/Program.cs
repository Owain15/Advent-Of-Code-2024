

int[,] ActiveCells = new int[8, 2]
{
	{ 0,-1 },
	{ 1,-1 },
	{ 1,0  },
	{ 1,1  },
	{ 0,1  },
	{ -1,1 },
	{ -1,0 },
	{-1,-1 }
};
int finalResult = 0;

// Inputs.
string testInputLocation = "TestInputData.txt";
string inputLocation = "InputData.txt";

//Run Inputs In PArt One.
//finalResult = RunPartOne(testInputLocation);
//finalResult = RunPartOne(inputLocation);

//Run Inputs In Part Two.
finalResult = RunPartTwo(testInputLocation);
//finalResult = RunPartTwo(inputLocation);









//char[,] testInput = Initalize2DArray(testInputLocation);

//string inputLocation = "InputData.txt";
//char[,] InputData = Initalize2DArray(inputLocation);

//Print2dCharArray(testInput);
//HighlightAllXmas(testInput);

//result = GetXmasCount(testInput);


// Console To Small To Wright Input Data.

//Print2dCharArray(InputData);
//HighlightAllXmas(InputData);

//result = GetXmasCount(InputData);

Console.WriteLine("\r\n\r\n" + finalResult);

int RunPartOne(string InputLocation)
{
	int result = 0;
	char[,] InputData = Initalize2DArray(InputLocation);
	result = GetXmasCount(InputData);
	return result;
}

int RunPartTwo(string InputLocation)
{
	int result = 0;

	return result;
}



















int GetXmasCount(char[,] input)
{
	int XmasCount = 0;

	for (int y = 0; y < input.GetLength(1); y++)
	{
		for (int x = 0; x < input.GetLength(0); x++)
		{
			if (input[y,x] == 'X')
			{
				XmasCount = XmasCount + GetXmasCountFromCell(input, y, x);
			}
		}
	}


	return XmasCount;
}

int GetXmasCountFromCell(char[,] input, int y, int x)
{
	int result = 0;

	int minX = 0;
	int maxX = input.GetLength(0)-1;

	int minY = 0;
	int maxY = input.GetLength(1)-1;

	string Xmas = "XMAS";

	for ( int direction = 0; direction < ActiveCells.GetLength(0); direction++ )
	{ 
		for( int letter = 1; letter < Xmas.Length; letter++ )
		{
			int xCheck = x + (ActiveCells[direction, 1] * letter);
			int yCheck = y + (ActiveCells[direction, 0] * letter);

			// check new cell is out of bounds. 
			if( xCheck < minX || xCheck > maxX || yCheck < minY || yCheck > maxY)
			{ break; }

			// Check if new cell does not matches input 
			if (input[yCheck,xCheck] != Xmas[letter ])
			{ break; }


			var foo = input[yCheck, xCheck];
			var bar = Xmas[letter];
			// increment result when whole input found
			if (letter == Xmas.Length - 1)
			{ result++;}
		
		}

	}


	return result; 
}

void HighlightAllXmas(char[,] input)
{
	Console.ForegroundColor = ConsoleColor.Green;

	for (int y = 0; y < input.GetLength(1); y++)
	{
		for (int x = 0; x < input.GetLength(0); x++)
		{
			if (input[y, x] == 'X')
			{
				Console.SetCursorPosition(x, y);
				Console.Write(input[y, x]);

			}
		}
	}

	Console.ResetColor();

}

void Print2dCharArray(char[,] input)
{
	for (int y = 0; y < input.GetLength(1); y++)
	{ 
		for (int x = 0; x < input.GetLength(0); x++)
		{
			Console.Write(input[y, x]);
		}
		Console.WriteLine();
	}
}

char[,] Initalize2DArray(string inputLocation)
{
	string[] dataByLine = File.ReadAllLines(inputLocation);

	int length = dataByLine[0].Length;
	int height = dataByLine.Length;

	char[,] returnData = new char[height,length];

	for (int y = 0; y < height; y++)
	{
		string line = dataByLine[y];

		for (int x = 0; x < length; x++)
		{
			returnData[y,x] = line[x];
		}
	}

	

	return returnData;
}











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
string testInputLocation2 = "TestInput2.txt";
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
	char[,] InputData = Initalize2DArray(InputLocation);
	//Print2dCharArray(InputData);
	List<(int y, int x)> positions = new List<(int, int)>();

	for (int y = 0; y < InputData.GetLength(1); y++)
	{
		for (int x = 0; x < InputData.GetLength(0); x++)
		{
			if (InputData[x,y] == 'M')
			{
				int minX = 0;
				int maxX = InputData.GetLength(0) - 1;

				int minY = 0;
				int maxY = InputData.GetLength(1) - 1;

				string mas = "MAS";

				for (int direction = 0; direction < ActiveCells.GetLength(0);direction++)
				{
					for(int letter = 1; letter < mas.Length; letter++)
					{
						int nextY = y + (ActiveCells[direction,1]*letter);
						int nextX = x + (ActiveCells[direction,0]*letter);

						if( nextX < minX || nextX > maxX || nextY < minY || nextY > maxY)
						{ break; }

						if(InputData[nextX,nextY] != mas[letter])
						{ break; }

						//var foo = InputData[nextY, nextX];
						//var bar = mas[letter];

						if (letter == mas.Length - 1)
						{
							int aY = y + ActiveCells[direction, 1];
							int aX = x + ActiveCells[direction, 0];

							//Isolating cell for debuging
							//if (aY == 5 && aX == 7 && true)
							//{ 
							//var foo = InputData[aY, aX];
							//}

							if (aY - 1 < minY || aY + 1 > maxY || aX - 1 < minX || aX + 1 > maxX)
							{ break; }

							int reversDirection = 0;

							switch (direction)
							{
								case 0: { reversDirection = 6; break; }
								case 1: { reversDirection = 3; break; }
								case 2: { reversDirection = 4; break; }
								case 3: { reversDirection = 1; break; }
								case 4: { reversDirection = 6; break; }
								case 5: { reversDirection = 7; break; }
								case 6: { reversDirection = 0; break; }
								case 7: { reversDirection = 5; break; }
							}
	//in  dir   x, y  out	
	//	
	//0  _,u  { 0,-1 } 6
	//1  r,u  { 1,-1 } 3
	//2  r,_  { 1, 0 } 4
	//3  r,d  { 1, 1 } 1
	//4  _,d  { 0, 1 } 6
	//5  l,d  { -1,1 } 7
	//6  l,_  { -1,0 } 0
	//7  l,u  { -1,-1} 5

							int firstLetterY = aY - ActiveCells[reversDirection, 1];
							int firstLetterX = aX - ActiveCells[reversDirection, 0];

							int lastLetterY = aY + ActiveCells[reversDirection, 1];
							int lastLetterX = aX + ActiveCells[reversDirection, 0];

							char firstLetter = InputData[firstLetterX, firstLetterY];
							char lastLetter = InputData[lastLetterX, lastLetterY];

							if (firstLetter == 'M' && lastLetter == 'S' || firstLetter == 'S' && lastLetter == 'M')
							{
								if (!positions.Contains((aX, aY)))
								{ positions.Add((aX, aY)); }
							}

						
						}

						}
					
				}
			}
		}
	}

	//Print2dCharArray(InputData);
	//Console.ForegroundColor = ConsoleColor.Red;
	//Console.Read();
	//foreach (var a in positions)
	//{
	//	Console.SetCursorPosition(a.x, a.y);
	//	Console.Write(InputData[a.y, a.x]);
	//}

	//Console.ResetColor();

	//Console.SetCursorPosition(0, 10);

	return positions.Count;
}



















int GetXmasCount(char[,] input)
{
	int XmasCount = 0;

	for (int y = 0; y < input.GetLength(0); y++)
	{
		for (int x = 0; x < input.GetLength(1); x++)
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









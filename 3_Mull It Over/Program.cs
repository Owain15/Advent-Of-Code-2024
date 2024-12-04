
using System.Data;

int resultP1 = 0;
int resultP2 = 0;
string inputData = File.ReadAllText(@"inputData.txt");
List<List<int>> dataValid = new List<List<int>>();

//int testResult = 0;
//string testData = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))hen()";
//string testResultExpected = "Expected Test Result\r\nData Count: 4\r\nResult: 161 (2*4 + 5*5 + 11*8 + 8*5)";
////testResult = RunPartOne(testData);

//int testResult2 = 0;
//string testData2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

//string testResultExpected2 = "Expected Test Result\r\nResult: 48 (2*4 + 8*5)";
//testResult2 = RunPartTwo(testData2);

resultP1 = RunPartOne(inputData);
resultP2 = RunPartTwo(inputData);

PrintReadout();

void PrintReadout()
{

	Console.WriteLine("\r\n------------------------------\r\n  Part One\r\n------------------------------");
	
	//Console.WriteLine("\r\n" + testResultExpected + "\r\n\r\nTest Results\r\nData Count: "+"\r\nResult:" + testResult);

	Console.WriteLine("\r\n     result: " + resultP1);
	Console.WriteLine("\r\n------------------------------\n------------------------------\r\n  Part Two\r\n------------------------------");
	//Console.WriteLine("\r\n" + testResultExpected2 + "\r\n\r\nTest\r\nResult:" + testResult2);
	Console.WriteLine("\r\n     result: " + resultP2);
	Console.WriteLine("\r\n------------------------------\r\n------------------------------");
}

int RunPartOne(string input) 
{
	List<string> dataListRaw = input.Split("mul").ToList();

	dataValid = ValidateData(dataListRaw);

	return CalculateResult(dataValid);
}

int RunPartTwo(string inputData)
{	
	string data = inputData;
	int dontCount = 0;
	int doCount = 0;

	for(int x = 0; x < data.Length - 7; x++)
	{
		if      (data[x]   == 'd' 
			&& data[x + 1] == 'o' 
			&& data[x + 2] == 'n' 
			&& data[x + 3] == '\'' 
			&& data[x + 4] == 't' 
			&& data[x + 5] == '(' 
			&& data[x + 6] == ')')

		{
			dontCount++;

			for(int y = x; y < data.Length - 7; y++)
			{
				if (data[y]    == 'd'
				&& data[y + 1] == 'o'
				&& data[y + 2] == '('
				&& data[y + 3] == ')')
				{
					doCount++;
					data = data.Remove(x,y-x+4);
					x = -1;
					break;
				}
			}
		}
		

	}


	return RunPartOne(data);
}

List<List<int>> ValidateData(List<string> dataListRaw)
{
	List<List<int>> returnData = new List<List<int>>();


	foreach (var input in dataListRaw)
	{
		bool validOpen = input[0] == '(';

		int commaIndex = 0;
		bool validCommaPosition = false;
		
		if(validOpen)
		{
			commaIndex = input.IndexOf(",");
			validCommaPosition = commaIndex > 1 && commaIndex < 5;
		}

		int closeIndex = 0;
		bool validClosePosition =false;

		if(validCommaPosition)
		{
			closeIndex = input.IndexOf(")");
			validClosePosition = closeIndex > commaIndex + 1 && closeIndex < commaIndex + 5;
		}

		bool validInput1 = false;
		int input1 = 0;

		if (validOpen && validCommaPosition && validClosePosition)
		{ validInput1 = int.TryParse(input.Substring(1, commaIndex - 1), out input1); }

		bool validInput2 = false;
		int input2 = 0;

		if (validOpen && validCommaPosition && validClosePosition)
		{ validInput2 = int.TryParse(input.Substring(commaIndex + 1, closeIndex - commaIndex - 1), out input2); }

		if (validInput1 && validInput2)
		{
			List<int> vi = new List<int>() { input1, input2 };
			returnData.Add(vi);
		}

	}

	return returnData;
}

int CalculateResult(List<List<int>> data)
{
	int result = 0;

	foreach (List<int> pair in data)
	{ result = result + (pair[0] * pair[1]);}
	
	return result;
}

//p2 88599353 X

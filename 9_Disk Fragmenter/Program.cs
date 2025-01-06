
using System.Text;

string inputTest = File.ReadAllText("TestInput.txt");
string inputFile = File.ReadAllText("InputData.txt");

var testResult = -1; 
long result = -1;

//testResult= RunPartOne(inputTest);

////result Not Found.
//result = RunPartOne(inputFile);

//testResult= RunPartOne_Two(inputTest);
result = RunPartOne_Two(inputFile);

//TestReadouts();
Readouts();





int RunPartOne(string input)
{
	//List<string> list1 = new List<string>();
	//List<string> list2 = new List<string>();

	//int split = 0;

	//for (int i = 0; i <input.Length; i++)
	//{
	//	if (split == 0)
	//	{ 
	//		list1.Add(input[i].ToString());
	//		split++;
	//	}
	//	else
	//	{
	//		list2.Add(input[i].ToString());
	//		split = 0;
	//	}
	//}

	string inProgress = "";

	int indexValue = 0;
	for (int i = 0; i < (input.Length); i++)
	{
		int dataCount = int.Parse(input[i].ToString());

		if (i % 2 != 1)
		{

			for (int data = 0; data < dataCount; data++)
			{
				inProgress = inProgress + indexValue;
			}
			indexValue++;
		}
		else
		{
			for (int data = 0; data < dataCount; data++)
			{
				inProgress = inProgress + ".";
			}
		}

	}

	//////test readout
	////Console.WriteLine("\r\nTest Expected String:\r\n00...111...2...333.44.5555.6666.777.888899");
	////Console.WriteLine("\r\nTest String Result:\r\n" + inProgress);
	////// Test Passed.
	///

	// Loop over String, Swaping Values Until All Empy Values Are At The End.
	int dotIndex = 0;
	int dataMoveIndex = 1;
	int loopCount = 0;

	while (dotIndex < dataMoveIndex)
	{

		//Get Index Of Values To Swap
		dotIndex = inProgress.IndexOf('.');
		dataMoveIndex = inProgress.Select((item, index) => (item, index)).Last(x => x.item != '.').index;
		//int dataMoveIndex = inProgress.Reverse().ToList().Find(x => x != ".");

		// check Current Index's Are Still Valid
		if (dotIndex > dataMoveIndex)
		{ break; }

		// Swap Values in string
		inProgress = StringHelper.ReplaceAt(inProgress, dotIndex, inProgress[dataMoveIndex]);
		inProgress = StringHelper.ReplaceAt(inProgress, dataMoveIndex, '.');
		//(inProgress[dataMoveIndex] , inProgress[dotIndex] ) = (inProgress[dotIndex] , inProgress[dataMoveIndex] );
		Console.WriteLine(loopCount);
		loopCount++;
	}
	//////test readout
	//Console.WriteLine("\r\nTest Expected String:\r\n0099811188827773336446555566..............");
	//Console.WriteLine("\r\nTest String Result:\r\n" + inProgress);
	////// Test Passed
	///
	
	

	int result = 0;

	for (int i = 0; i < inProgress.Length; i++)
	{
		if (inProgress[i] == '.') 
		{ break; }
		
		result = result + (int.Parse(inProgress[i].ToString())*i);
	}

	//////test readout
	//Console.WriteLine("\r\nTest Expected Result:\r\n1928");
	//Console.WriteLine("\r\nTest Result:\r\n" + result);
	////// Test Passed
	///

	return result;
}

long RunPartOne_Two(string input)
{
	List<DataStruct> dataList = new List<DataStruct>();

	int indexValue = 0;

	for (int i = 0; i < (input.Length); i++)
	{
		int dataCount = int.Parse(input[i].ToString());

		if (i % 2 != 1)
		{

			for (int data = 0; data < dataCount; data++)
			{
				DataStruct dataStruct = new DataStruct(i, indexValue);
				
				//dataStruct.index = i;
				//dataStruct.value = indexValue;
				
				dataList.Add(dataStruct);
				//inProgress = inProgress + indexValue;
			}
			indexValue++;
		}
		else
		{
			for (int data = 0; data < dataCount; data++)
			{
				DataStruct dataStruct = new DataStruct(i,-1);

				//dataStruct.index = i;
				//dataStruct.value = -1;

				dataList.Add(dataStruct);
				//inProgress = inProgress + ".";
			}
		}

	}

	////////test readout
	//Console.WriteLine("\r\nTest Expected String:\r\n00...111...2...333.44.5555.6666.777.888899");
	//string testOutput = "";
	//foreach (var data in dataList)
	//{
	//	if (data.value != -1)
	//	{ testOutput = testOutput + data.value.ToString(); }
	//	else { testOutput = testOutput + "."; }
	//}
	//Console.WriteLine("\r\nTest String Result:\r\n" + testOutput);
	//////// Test Passed.
	/////

	// Loop over dataList, Swaping Values Until All Empty Values Are At The End.

	int dotIndex = 0;
	int dataMoveIndex = 1;

	//int loopCount = 0;

	while (dotIndex < dataMoveIndex)
	{

		////Get Index Of Values To Swap
		//dotIndex = dataList.Find(x=>x.value == -1).index;
		//dataMoveIndex = dataList.Last(x => x.value != -1).index;
		for (int i = 0; i < dataList.Count-1; i++)
		{ 
			if (dataList[i].value == -1) 
			{ dotIndex = i; break; } 
		}
		for(int i = dataList.Count-1; i > -1; i--)
		{ 
			if (dataList[i].value != -1) 
			{ dataMoveIndex = i; break; } 
		}

		// check Current Index's Are Still Valid
		if (dotIndex > dataMoveIndex)
		{ break; }

		// Swap Values in List
		dataList[dotIndex].value = dataList[dataMoveIndex].value;
		dataList[dataMoveIndex].value = -1;
		
		//string to = "";
		//foreach (var data in dataList)
		//{
		//	if (data.value != -1)
		//	{ to = to + data.value.ToString(); }
		//	else { to = to + "."; }
		//}
		//Console.WriteLine("\r\nTest String Result:\r\n" + to);
		
	}

	//////test readout
	//Console.WriteLine("\r\nTest Expected String:\r\n0099811188827773336446555566..............");
	//string testOutput1 = "";
	//foreach (var data in dataList)
	//{
	//	if (data.value != -1)
	//	{ testOutput1 = testOutput1 + data.value.ToString(); }
	//	else { testOutput1 = testOutput1 + "."; }
	//}
	//Console.WriteLine("\r\nTest String Result:\r\n" + testOutput1);
	////// Test Passed
	///

	long result = 0;

	for (int i = 0; i < dataList.Count; i++)
	{
		if (dataList[i].value == -1)
		{ break; }
		
		Console.WriteLine(dataList[i].value + " x " + i);
		Console.WriteLine("result: " + result );

		result = result + (dataList[i].value * i);
	}

	return result;
}

void TestReadouts()
{
	Console.WriteLine("\r\nTest Data:\r\n" + inputTest);
	Console.WriteLine("\r\nTest Expected Result:\r\n1928");
	Console.WriteLine("\r\nTest Result:\r\n" + testResult);
}

void Readouts()
{
	//Console.WriteLine("Input Data:\r\n" + inputFile);

	Console.WriteLine("\r\nResult:\r\n" + result);
}


//// 686772060 to low
//// 6330095022244





class DataStruct
{
	public long index { get; set; }

	public long value { get; set; }

	public DataStruct(int index, int value)
	{
		this.index = index;
		this.value = value;
	}
	public void SetIndex(long newIndex)
	{ this.index = newIndex; }

	public void SetValue(long newValue)
	{  this.value = newValue; }
}
static class StringHelper
{
	public static string ReplaceAt(this string input, int index, char newChar)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		StringBuilder builder = new StringBuilder(input);
		builder[index] = newChar;
		return builder.ToString();
	}

}



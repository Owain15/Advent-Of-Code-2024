// import data

// separate rules from problems
//		parse problems
//		parse rules

// for each problem
//	  filter the rules to the problem -> "relevantRules" 
//    foreach number
//	      for each rule
//            if relevant,
//				find the number later in the list, or fail.



// Get middle number 
// sum middle numbers
// print answer 

//////////////////////////////////////////////////

//data sorces



using System.Linq;

string inputLocation = "InputData.txt";
string testInputLocation = "TestInput.txt";

//RunPartOne(testInputLocation);
//RunPartOne(inputLocation);

//RunPartTwo(testInputLocation);
RunPartTwo(inputLocation);

void RunPartOne(string inputLocation)
{
//parse data to Ienumerables
//var (rulesAll, problemsAll) = ParseData(testInputLocation);
var (rulesAll, problemsAll) = ParseData(inputLocation);

//parse problemsAll to ValidProblems
var validProblems = problemsAll.Where(problem => isValid(problem, rulesAll));

//Get Values at Mid Index
var midValues = validProblems.Select(problem => problem[(problem.Count-1)/ 2]);

// sum mid values and print to console.
Console.WriteLine(midValues.Sum());



Console.Read();
}

void RunPartTwo(string inputLocation)
{
	//parse input 
	var (rulesAll, problemsAll) = ParseData(inputLocation);

	//parse problemsAll.reorder invalid problems
	var invalidProblems = problemsAll.Where(problem => !isValid(problem, rulesAll));

	IEnumerable<List<int>> reorderdProblems = invalidProblems.Where(problem =>
	{
		while (!isValid(problem, rulesAll))
		{
			foreach (var currentRule in rulesAll)
			{
				(int x, int y) rule = currentRule;
				
				if (problem.Contains(rule.x) && problem.Contains(rule.y) && problem.IndexOf(rule.x) > problem.IndexOf(rule.y))
				{ 
					(problem[problem.IndexOf(rule.x)], problem[problem.IndexOf(rule.y)]) = (problem[problem.IndexOf(rule.y)], problem[problem.IndexOf(rule.x)]);
				}
			}
		}

		//rewight return?
		return true;
	}) ;

	//Get Values at Mid Index
	var midValues = reorderdProblems.Select(problem => problem[(problem.Count() - 1) / 2]);

	// sum mid values and print to console.
	Console.WriteLine(midValues.Sum());

	Console.Read();
}





//////////////////////////////////////////////////


// import data
(IEnumerable<(int, int)>, IEnumerable<List<int>>) ParseData(string inputLocation)
{
	var strings = File.ReadAllText(inputLocation).Split("\r\n\r\n");
	var rules = strings[0];
	var problems = strings[1].Split("\r\n")
		.Select(line => line.Split(',').Select(item => int.Parse(item)).ToList());

	var parsedRules = rules.Split("\r\n").Select(line =>
	{
		var splitLine = line.Split("|");
		var x = int.Parse(splitLine[0]);
		var y = int.Parse(splitLine[1]);
		return (x, y);
	});

	return (parsedRules, problems);
}

bool isValid(List<int> problem, IEnumerable<(int x, int y)> rulesAll)
{
	return !problem.Any(currentNumber => rulesAll
	.Where(rule =>
			{
				return rule.x == currentNumber;
			})
				.Any(rule =>
			{
				return problem.IndexOf(rule.x) > problem.IndexOf(rule.y ) && problem.IndexOf(rule.y)!= -1;
			}));
}

List<int> ReorderdProblems(List<int> invalidProblem, IEnumerable<(int x, int y)> rulesAll)
{


	while(!isValid(invalidProblem,rulesAll))
	{
		foreach (var rule in rulesAll) 
		{
	//		while (!isValid(problems, rulesAll))
	//		{
	//			foreach (var rule in rulesAll)
	//			{
					if (invalidProblem.Contains(rule.x) && invalidProblem.Contains(rule.y) && invalidProblem.IndexOf(rule.x) < invalidProblem.IndexOf(rule.y)
						)
					{
						
	//					var xIndex = problems.IndexOf(rule.x);
	//					var yIndex = problems.IndexOf(rule.y);
						
	//					if(xIndex>yIndex)
	//					{
							(invalidProblem[invalidProblem.IndexOf(rule.x)], invalidProblem[invalidProblem.IndexOf(rule.y)]) = 
							(invalidProblem[invalidProblem.IndexOf(rule.y)], invalidProblem[invalidProblem.IndexOf(rule.x)]);
	//					}
						
					}
	//			}
	//		}
		}
	}
	

	return invalidProblem;
}

// for each problem
//	  filter the rules to the problem -> "relevantRules" 

//    foreach number
//	      for each rule
//            if relevant,
//				find the number later in the list, or fail.



// Get middle number 
// sum middle numbers
// print answer 
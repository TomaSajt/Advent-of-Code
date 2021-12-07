Imports System
Imports System.IO


Module Program
	Sub Main(args As String())
		'Dim asd = New StreamReader("input.txt").ReadToEnd().Split(vbCrLf).Where(
		'	Function(line)
		'		Dim splitLine = line.Split()
		'		Dim splitBounds = splitLine(0).Split("-")
		'		Dim num1 = Integer.Parse(splitBounds(0))
		'		Dim num2 = Integer.Parse(splitBounds(1))
		'		Dim ch = splitLine(1)(0)
		'		Dim password = splitLine(2)
		'		Dim chCount = password.ToCharArray().Where(Function(x) x = ch).Count()
		'		Return chCount <= num2 And chCount >= num1
		'	End Function
		').Count()
		'Console.WriteLine(asd)
		'Console.ReadKey()

		'Console.WriteLine(New StreamReader("input.txt").ReadToEnd().Split(vbCrLf).Where(Function(line) line.Split()(2).ToCharArray().Where(Function(x) x = line.Split()(1)(0)).Count() <= Integer.Parse(line.Split()(0).Split("-")(1)) And line.Split()(2).ToCharArray().Where(Function(x) x = line.Split()(1)(0)).Count() >= Integer.Parse(line.Split()(0).Split("-")(0))).Count())

		Console.ReadKey()

	End Sub
End Module

package day2;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Day2 {

	public static void main(String[] args) throws FileNotFoundException {
		int _2_1 = 0;
		int _2_2 = 0;
		List<String> input = new ArrayList<>();
		Scanner sc = new Scanner(new File("input.txt"));
		while(sc.hasNext()) {
			input.add(sc.nextLine());
		}
		String[][] arr = input.stream().map((str) -> str.replaceAll(":", "").split("[- ]")).toArray(String[][]::new);
		for (String[] strings : arr) {
			long numOfChars = strings[3].chars().filter(ch -> ch == strings[2].charAt(0)).count();
			if (numOfChars <= Integer.parseInt(strings[1]) && numOfChars >= Integer.parseInt(strings[0])) _2_1++;
			
			char ch = strings[2].charAt(0);
			if(strings[3].toCharArray()[Integer.parseInt(strings[0])-1] == ch ^ strings[3].toCharArray()[Integer.parseInt(strings[1])-1] == ch) _2_2++;
		}
		System.out.println(_2_1);
		System.out.println(_2_2);
	}

}

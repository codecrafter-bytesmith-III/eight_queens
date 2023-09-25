namespace eight_queens;

internal class Program
{
    private const int BoardSize = 8;

    static void Main(string[] args)
    {
        List<int[]> solutions = SolveEightQueens();

        Console.WriteLine("Found " + solutions.Count + " solutions");

        foreach (int[] solution in solutions)
            PrintBoard(solution);

        Console.WriteLine("Found " + solutions.Count + " solutions");
    }

    private static List<int[]> SolveEightQueens()
    {
        var solutions = new List<int[]>();

        int[] rows = new int[BoardSize]; // Position of queen in each row

        for (int i = 0; i < BoardSize; ++i)
        {
            rows[0] = i;
            for (int j = 0; j < BoardSize; ++j)
            {
                rows[1] = j;
                if (!IsValid(1, rows)) continue;

                for (int k = 0; k < BoardSize; ++k)
                {
                    rows[2] = k;
                    if (!IsValid(2, rows)) continue;

                    for (int l = 0; l < BoardSize; ++l)
                    {
                        rows[3] = l;
                        if (!IsValid(3, rows)) continue;

                        for (int m = 0; m < BoardSize; ++m)
                        {
                            rows[4] = m;
                            if (!IsValid(4, rows)) continue;

                            for (int n = 0; n < BoardSize; ++n)
                            {
                                rows[5] = n;
                                if (!IsValid(5, rows)) continue;

                                for (int o = 0; o < BoardSize; ++o)
                                {
                                    rows[6] = o;
                                    if (!IsValid(6, rows)) continue;

                                    for (int p = 0; p < BoardSize; ++p)
                                    {
                                        rows[7] = p;
                                        if (IsValid(7, rows))
                                        {
                                            int[] solution = new int[BoardSize];
                                            Array.Copy(rows, solution, BoardSize);
                                            solutions.Add(solution);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return solutions;
    }

    private static bool IsValid(int rowIndex, int[] rows)
    {
        int queenOnThisRowColumnIndex = rows[rowIndex];
        for (int i = rowIndex - 1; i >= 0; --i)
        {
            // Any other queen on the same column above?
            int queenOnOtherRowColumnIndex = rows[i];
            if (queenOnOtherRowColumnIndex == queenOnThisRowColumnIndex)
                return false;

            // Any other queen on the same up-right diagonal?
            int upRightDiagonalColumnIndex = queenOnThisRowColumnIndex + (rowIndex - i);
            if (queenOnOtherRowColumnIndex == upRightDiagonalColumnIndex)
                return false;

            // Any other queen on the same up-left diagonal?
            int upLeftDiagonalColumnIndex = queenOnThisRowColumnIndex - (rowIndex - i);
            if (queenOnOtherRowColumnIndex == upLeftDiagonalColumnIndex)
                return false;
        }

        return true;
    }

    private static void PrintBoard(int[] solution)
    {
        // Print the first row. Each row is the left character '|', then a space if the queen is not in that column or a 'Q' if the queen is in that column.
        // Separate each column by another '|' character
        Console.WriteLine();

        Console.WriteLine("-----------------");
        for (int rowNum = 0; rowNum < BoardSize; rowNum++)
        {
            Console.Write("|");
            for (int columnNum = 0; columnNum < BoardSize; columnNum++)
                Console.Write(solution[rowNum] == columnNum ? "Q|" : " |");
            Console.WriteLine();

            Console.WriteLine("-----------------");
        }
    }
}

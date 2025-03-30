using Solution.BracketValidation;
using Solution.BrowserHistory;
using Solution.Palindrome;
using static Solution.BrowserHistory.HistoryStack;

namespace Solution;

internal class Program
{
    static void Main(string[] args)
    {
        // Browser history
        HistoryManager manager = new HistoryManager();

        manager.KunjungiHalaman("google.com");
        manager.KunjungiHalaman("example.com");
        manager.KunjungiHalaman("stackoverflow.com");

        manager.LihatHalamanSaatIni();

        manager.Kembali();
        manager.LihatHalamanSaatIni();

        manager.TampilkanHistory();

        // Bracket validator
        BracketValidator validator = new BracketValidator();
        string ekspresiValid = "[{}](){}";
        string ekspresiInvalid = "(]";

        Console.WriteLine($"Ekspresi '{ekspresiValid}' valid? {validator.ValidasiEkspresi(ekspresiValid)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid}' valid? {validator.ValidasiEkspresi(ekspresiInvalid)}");

        // Palindrome Checker
        string palindrom1 = "Kasur ini rusak";
        string palindrom2 = "Ibu Ratna antar ubi";
        string notPalindrom = "Hello World";

        Console.WriteLine($"'{palindrom1}' palindrom? {PalindromeChecker.CekPalindrom(palindrom1)}");
        Console.WriteLine($"'{palindrom2}' palindrom? {PalindromeChecker.CekPalindrom(palindrom2)}");
        Console.WriteLine($"'{notPalindrom}' palindrom? {PalindromeChecker.CekPalindrom(notPalindrom)}");
    }
}

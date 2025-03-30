using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BrowserHistory
{
    public class Halaman
    {
        public string URL { get; }
        public Halaman(string url)
        {
            URL = url;
        }
    }

    public class Node
    {
        public Halaman Data { get; set; }
        public Node? Next { get; set; }
        public Node(Halaman data)
        {
            Data = data;
            Next = null;
        }
    }

    public class HistoryStack
    {
        private Node? top;
        public HistoryStack()
        {
            top = null;
        }
        public void Push(Halaman halaman)
        {
            Node newNode = new Node(halaman);
            newNode.Next = top;
            top = newNode;
        }
        public Halaman? Pop()
        {
            if (top == null)
            {
                return null;
            }
            Halaman halaman = top.Data;
            top = top.Next;
            return halaman;
        }
        public Halaman? Peek()
        {
            return top?.Data;
        }
        public void DisplayHistory()
        {
            Node? current = top;
            int index = 1;
            while (current != null)
            {
                Console.WriteLine($"{index}. {current.Data.URL}");
                current = current.Next;
                index++;
            }
        }

        public IEnumerable<Halaman> GetHistory()
        {
            List<Halaman> history = new List<Halaman>();
            Node? current = top;
            while (current != null)
            {
                history.Add(current.Data);
                current = current.Next;
            }
            return history;
        }
    }

    public class HistoryManager
    {
        private HistoryStack historyStack;

        public HistoryManager()
        {
            historyStack = new HistoryStack();
        }

        public void KunjungiHalaman(string url)
        {
            Halaman halaman = new Halaman(url);
            historyStack.Push(halaman);
            Console.WriteLine($"Mengunjungi halaman: {url}");
        }
        public string Kembali()
        {
            historyStack.Pop();
            Halaman? halaman = historyStack.Peek();
            if (halaman == null)
            {
                return "Tidak ada halaman sebelumnya.";
            }
            else
            {
                return halaman.URL;
            }
        }

        public string LihatHalamanSaatIni()
        {
            Halaman? halaman = historyStack.Peek();
            if (halaman == null)
            {
                return "Tidak ada halaman saat ini.";
            }
            else
            {
                return halaman.URL;
            }
        }
        public void TampilkanHistory()
        {
            foreach (var halaman in historyStack.GetHistory().Reverse())
            {
                Console.WriteLine(halaman.URL);
            }
        }

    }
}

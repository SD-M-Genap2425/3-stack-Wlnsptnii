using System;

namespace Solution.BracketValidation
{
    public class BracketValidator
    {
        private class Node
        {
            public char Data;
            public Node Next;

            public Node(char data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node top;

        public BracketValidator()
        {
            top = null;
        }

        public void Push(char data)
        {
            Node newNode = new Node(data);
            newNode.Next = top;
            top = newNode;
        }

        public char Pop()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty");

            char data = top.Data;
            top = top.Next;
            return data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public bool ValidasiEkspresi(string ekspresi)
        {
            foreach (char ch in ekspresi)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (IsEmpty())
                        return false;

                    char topChar = Pop();
                    if ((ch == ')' && topChar != '(') ||
                        (ch == '}' && topChar != '{') ||
                        (ch == ']' && topChar != '['))
                    {
                        return false;
                    }
                }
            }

            return IsEmpty();
        }
    }
}

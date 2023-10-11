using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020
{
    public class Solution
    {
        private enum Token
        {
            OpenParen = '(',
            ClosedParen = ')',
            OpenCurly = '{',
            ClosedCurly = '}',
            OpenBrace = '[',
            ClosedBrace = ']',
            FinishedBracketPair
        }

        private Stack<Token> tokenStack = new Stack<Token>();

        private int CurrentIndex = 0;
        private string S;

        private char CurrentChar => S[CurrentIndex];

        public bool IsValid(string s)
        {
            S = s;
            ParseStart();

            return tokenStack.Count == 0;
        }

        private void ParseStart()
        {
            if (CurrentIndex > S.Length - 1)
            {
                return;
            }

            switch(CurrentChar)
            {
                case (char)Token.OpenParen:
                    ParseOpenParen();
                    break;
                case (char)Token.ClosedParen:
                    ParseClosedParen(); 
                    break;
                case (char)Token.OpenCurly:
                    ParseOpenCurly();
                    break;
                case (char)Token.ClosedCurly:
                    ParseClosedCurly();
                    break;
                default:
                    break;
            }

            // else if ((char)Token.OpenBrace == CurrentChar)
            // {
            //     parseOpenBrace();
            // }
            //  else if((char)Token.OpenCurly == currentChar) {
            //     tokenStack.Push(Token.OpenCurly);
            // } else if((char)Token.OpenBrace == currentChar) {
            //     tokenStack.Push(Token.OpenBrace);
            // }
        }

        private void ParseOpenParen()
        {
            tokenStack.Push(Token.OpenParen);
            CurrentIndex++;

            if (CurrentIndex > S.Length - 1)
            {
                return;
            }

            if ((char)Token.ClosedParen == CurrentChar)
            {
                ParseClosedParen();
            }

            ParseStart();
        }

        private void ParseClosedParen()
        {
            CurrentIndex++;

            if (tokenStack.Peek() == Token.OpenParen)
            {
                tokenStack.Pop();
            }

            ParseStart();
        }

        private void ParseOpenCurly()
        {
            tokenStack.Push(Token.OpenCurly);
            CurrentIndex++;

            if (CurrentIndex > S.Length - 1)
            {
                return;
            }

            if ((char)Token.ClosedParen == CurrentChar)
            {
                ParseClosedCurly();
            }

            ParseStart();
        }

        private void ParseClosedCurly()
        {
            CurrentIndex++;

            if (tokenStack.Peek() == Token.OpenCurly)
            {
                tokenStack.Pop();
            }

            ParseStart();
        }

        // private void parseOpenBrace()
        // {
        //     tokenStack.Push(Token.OpenBrace);

        //     CurrentIndex++;

        //     if (CurrentIndex > S.Length - 1) 
        //     {
        //         return;
        //     }

        //     if ((char)Token.ClosedBrace == CurrentChar) 
        //     {
        //         if (tokenStack.Peek() == Token.OpenBrace) 
        //         {
        //             tokenStack.Pop();
        //         }
        //     }

        //     parseStart(s);
        // }

        // private bool parseOpenParen(string s, int index) =>index < s.Length - 1 && s[index] switch
        // {

        // }
    }
}

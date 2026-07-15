public static class ComplexStack {
    //This  method checks if the brackets in a string are balanced. It uses a stack to keep track of opening brackets and ensures that each closing bracket matches the most recent opening bracket.
    //the stack is used to store the opening brackets, and when a closing bracket is encountered, it checks if it matches the top of the stack. If it does, the opening bracket is popped from the stack. If not, or if there are unmatched brackets left in the stack at the end, the method returns false.
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
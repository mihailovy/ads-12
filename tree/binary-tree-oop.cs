using System;

class Node
{
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
    public int Data { get; set; }
}

class BinaryTree
{
    public Node Root { get; set; }
    
    // Добавяне на възел
    public bool Add(int value)
    {
		
        Node before = null, after = this.Root;
 
        while (after != null)
        {
            before = after;
            if (value < after.Data) {
				        // Дали възелът трябва да е в ляво? 
                after = after.LeftNode; 
            } else if (value > after.Data) {
			        	// Дали възелът трябва да е в дясно? 
                after = after.RightNode;
            } else {
                // Възелът е вече в дървото, връщаме false
                return false;
            }
        }
 
        // Нова променлива от тип клас Node
        Node newNode = new Node();
        newNode.Data = value; // Присвояваме на новия възел стойност value
 
        if (this.Root == null) {
			      // Дървото е празно
            this.Root = newNode; // Създаваме дърво с един елемент - новия.
        } else {
            if (value < before.Data)
                before.LeftNode = newNode;
            else
                before.RightNode = newNode;
        }
        return true; // Възелът е добавен
    }
 
    // Намиране на възел
    public Node Find(int value)
    {
        return this.Find(value, this.Root); // Рекурсия       
    }
    
    private Node Find(int value, Node parent)
    {
      if (parent != null) {
        if (value == parent.Data) {
            // Намерили сме правилния възел и го връщаме.
            return parent;
        } else if (value < parent.Data) {
            // Рекурсия, като втори параметър подаваме възела, който е в ляво.
            return Find(value, parent.LeftNode); 
        } else if (value > parent.Data) {
            // Рекурсия, като втори параметър подаваме възела, който е в дясно.
            return Find(value, parent.RightNode);
        }
      }
      return null;
    }
 
    // Премахване - само за първоначално пускане
    public void Remove(int value)
    {
        this.Root = Remove(this.Root, value); 
    }
 
    // Премахване
    private Node Remove(Node parent, int key)
    {
        if (parent == null)
            return parent;
 
        if (key < parent.Data) {
			      // Пускаме Remove, като подаваме левия крак на родителя
            parent.LeftNode = Remove(parent.LeftNode, key); 
        } else if (key > parent.Data) {
			      // Пускаме Remove, като подаваме десния крак на родителя
            parent.RightNode = Remove(parent.RightNode, key);
        } else { // key ==  parent.Data, следователно този връх трябва да се изтрие  
			
            // Възелът има ляво дете или дясно дете, или няма дете 
            if (parent.LeftNode == null) {
				        // Няма ляво дете, връщаме дясното
                return parent.RightNode;
            } else if (parent.RightNode == null) {
				        // Няма дясно дете, връщаме лявото
                return parent.LeftNode;
            } else {
                // възелът има две деца - ляво и дясно под-дърво, следователно
                // взимаме най-малкия възел от дясното под-дърво
                parent.Data = MinValue(parent.RightNode);
                
                // изтриваме най-малкия възел от дясното под-дърво
                parent.RightNode = Remove(parent.RightNode, parent.Data); // Рекурсия
            }
        }
 
        return parent;
    }
 
    private int MinValue(Node node)
    {
        // Първоначално взимаме стойността на подадения възел
        int minv = node.Data;
        
        // Циклим по левия крак, докато не достигнем null
        while (node.LeftNode != null)
        {
            // Взимаме стойността на левя крак 
            minv = node.LeftNode.Data;
            
            // Преход към следващия ляв крак
            node = node.LeftNode;
        }
        // Връщаме стойността
        return minv;
    }
 
    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.Root);
    }
 
    private int GetTreeDepth(Node parent)
    {
        return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }
 
    public void TraversePreOrder(Node parent)
    {
        if (parent != null)
        {   
            // Печатаме текущия ключ
            Console.Write(parent.Data + " ");
            
            // Пускаме рекурсивно функцията за левия крак
            TraversePreOrder(parent.LeftNode);
            
            // Пускаме рекурсивно фунцкията за десния крак
            TraversePreOrder(parent.RightNode);
        }
    }
 
 
    // Обхождане от най-малката (най-лявата) стойност към най-голямата (най-дясната)
    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            // Пускаме рекурсивно функцията за левия крак
            TraverseInOrder(parent.LeftNode);
            
            // Печатаме ключа 
            Console.Write(parent.Data + " ");
            
            // Пускаме рекурсивно фунцкията за десния крак
            TraverseInOrder(parent.RightNode);
        }
    }
 
    public void TraversePostOrder(Node parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.LeftNode);
            TraversePostOrder(parent.RightNode);
            Console.Write(parent.Data + " ");
        }
    }
    
    static void Main()
    {
      BinaryTree binaryTree = new BinaryTree();
      
      binaryTree.Add(1);
      binaryTree.Add(2);
      binaryTree.Add(7);
      binaryTree.Add(3);
      binaryTree.Add(10);
      binaryTree.Add(5);
      binaryTree.Add(8);
       
      Node node = binaryTree.Find(5);
      int depth = binaryTree.GetTreeDepth();
       
      Console.WriteLine("PreOrder Traversal:");
      binaryTree.TraversePreOrder(binaryTree.Root);
      Console.WriteLine();
       
      Console.WriteLine("InOrder Traversal:");
      binaryTree.TraverseInOrder(binaryTree.Root);
      Console.WriteLine();
       
      Console.WriteLine("PostOrder Traversal:");
      binaryTree.TraversePostOrder(binaryTree.Root);
      Console.WriteLine();
       
      binaryTree.Remove(7);
      binaryTree.Remove(8);
       
      Console.WriteLine("PreOrder Traversal After Removing Operation:");
      binaryTree.TraversePreOrder(binaryTree.Root);
      Console.WriteLine();
       
      Console.ReadLine();
    
    }
}

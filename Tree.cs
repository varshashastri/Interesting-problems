using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace tree
{
    class Node
    {
        public int data;
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int data, Node right=null, Node left=null)
        {
            this.data = data;
            this.right = right;
            this.left = left;
        }
    }

    class Tree
    {
        public Node root;

        public void AddNodeToBinarySearchTree(int num)
        {
            Node curr;
            Node newnode = new Node(num);
            if (root == null)
            {
                root = newnode;
            }
            else
            {
                curr = root;
                while (curr != null)
                {
                    if (num < curr.data)
                    {
                        if (curr.left != null)
                            curr = curr.left;
                        else
                        {
                            curr.left = newnode; 
                            return;
                        }
                    }
                    else if (num >= curr.data)
                    {
                        if (curr.right != null)
                        {
                            curr = curr.right;
                        }
                        else
                        {
                            curr.right = newnode; 
                            return;
                        }
                    }
                }
            }
        }

        public void CreateBinarySearchTree(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                AddNodeToBinarySearchTree(array[i]);
            }
        }

        public void InsertToMakeCompleteBinaryTree(int num)
        {
            if (root == null)
            {
                root = new Node(num); 
                return;
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node n = q.Dequeue();
                if (n.left == null)
                {
                    n.left = new Node(num);
                    return;
                }
                else if (n.right == null)
                {
                    n.right = new Node(num);
                    return;
                }
                else
                {
                    q.Enqueue(n.left);
                    q.Enqueue(n.right);
                }
            }
        }

        public void CreateBinaryTree(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                InsertToMakeCompleteBinaryTree(array[i]);
            }
        }

        public void Print()
        {
            Console.WriteLine("Inorder recursive traversal");
            InorderPrintRecursive(root);

            Console.WriteLine("\n\nPostOrder recursive traversal");
            PostOrderPrintRecursive(root);

            Console.WriteLine("\n\nPreOrder recursive traversal");
            PreOrderPrintRecursive(root, 0);

            Console.WriteLine("\n\nLevelOrder iterative traversal");
            LevelOrderIterativeTraversal(root);

            Console.WriteLine("\n\nLevelOrder recursive traversal");
            LevelOrderRecursiveTraversal(root);

            Console.WriteLine("\n\nReverse LevelOrder recursive traversal");
            ReverseLevelOrderTraversal(root);

            Console.WriteLine("\n\nZigZag recursive traversal");
            ZigZagTraversal(root);

            Node ClonedTree = null;
            Console.WriteLine("\nCloning the tree\n");

            ClonedTree = CloneTree(root, ClonedTree);
            Console.WriteLine("\nInorder recursive traversal of cloned tree");    
            InorderPrintRecursive(ClonedTree);

            Console.WriteLine("\nHeight of the tree is"+getHeight());
            Console.WriteLine("\nSize of the tree is" + getSize(root));
            Console.WriteLine("\nLevel with max sum " + LevelWithMaxSum());
        }

        public void ReverseLevelOrderTraversal(Node root)
        {
            for (int i = getHeight(); i >=0; i--)
            {
                PrintThisLevel(i, root, 0, false);
                Console.WriteLine();
            }
        }

        public void ZigZagTraversal(Node root)
        {
            bool printLeftToRight=true;
            if (root == null)
                return;
            else
            {
                for (int i = 0; i < getHeight(); i++)
                {
                    PrintThisLevel(i, root, 0, printLeftToRight);
                    printLeftToRight = !printLeftToRight;
                }
            }
        }

        public static bool IsEquivalentClone(Node OriginalRoot, Node CopyRoot)
        {
            if (OriginalRoot == null)
            {
                if (CopyRoot == null)
                { return true; }
                else return false;
            }
            else if (CopyRoot == null)
            {
                if (OriginalRoot == null)
                { return true; }
                else return false;
            }
            else if (OriginalRoot.data == CopyRoot.data)
            {
                bool ret = IsEquivalentClone(OriginalRoot.left, CopyRoot.left);
                ret &= IsEquivalentClone(OriginalRoot.right, CopyRoot.right);
                return ret;
            }
            else return false;
        }

        public static bool IsMirrorCopy(Node OriginalRoot, Node CopyRoot)
        {
            if (OriginalRoot == null && CopyRoot == null)
            {
                return true;
            }
            else if ((OriginalRoot == null && CopyRoot != null) || (OriginalRoot != null && CopyRoot == null))
            {
                return false;
            }
            else if (OriginalRoot.data == CopyRoot.data)
            {
                bool ret;
                ret = IsMirrorCopy(OriginalRoot.left, CopyRoot.right);
                ret &= IsMirrorCopy(OriginalRoot.right, CopyRoot.left);
                return ret;
            }
            else return false;
        }

        private Node MakeMirrorCopyTree(Node OriginalRoot, Node MirrorRoot)
        {
            if (OriginalRoot == null) return null;
            else 
            {
                MirrorRoot = new Node(OriginalRoot.data);
            }
            if (OriginalRoot.left != null)
            {
                MirrorRoot.right = MakeMirrorCopyTree(OriginalRoot.left, MirrorRoot.right);
            }
            if (OriginalRoot.right != null)
            {
                MirrorRoot.left = MakeMirrorCopyTree(OriginalRoot.right, MirrorRoot.left);
            }
            return MirrorRoot;
        }

        public Node MakeMirrorCopyTree()
        {
            Node mirrorCopy=null;
            mirrorCopy=MakeMirrorCopyTree(this.root, mirrorCopy);
            return mirrorCopy;
        }

        public Node CloneTree(Node OriginalRoot, Node ClonedRoot)
        {
            if (OriginalRoot == null)
            {
                ClonedRoot = null;
            }
            else
            {
                ClonedRoot = new Node(OriginalRoot.data);
            }
            if (OriginalRoot.left != null)
            {
                ClonedRoot.left = CloneTree(OriginalRoot.left, ClonedRoot.left);
            }
            if (OriginalRoot.right != null)
            {
                ClonedRoot.right = CloneTree(OriginalRoot.right, ClonedRoot.right);
            }
            return ClonedRoot;
        }

        public void LevelOrderRecursiveTraversal(Node node)
        {
            for (int i = 0; i <= getHeight(); i++)
            {
                PrintThisLevel(i, node, 0,true);
                Console.WriteLine();
            }
        }

        public void PrintThisLevel(int levelToPrint, Node node, int currLevel,bool printLeftToRight)
        {
            if (levelToPrint == 0 && currLevel == 0)
            {
                Console.Write(node.data + " ");
                return;
            }
            if (node == null)
                return;
            if (currLevel == levelToPrint - 1)
            {
                if (printLeftToRight)
                {
                    if (node.left != null)
                    {
                        Console.Write(node.left.data + " ");
                    }
                    if (node.right != null)
                    {
                        Console.Write(node.right.data + " ");
                    }
                    return;
                }
                else
                {
                    if (node.right != null)
                    {
                        Console.Write(node.right.data + " ");
                    }
                    if (node.left != null)
                    {
                        Console.Write(node.left.data + " ");
                    }
                    return;
                }

            }
            else
            {
                if (printLeftToRight)
                {
                    PrintThisLevel(levelToPrint, node.left, currLevel + 1, printLeftToRight);
                    PrintThisLevel(levelToPrint, node.right, currLevel + 1, printLeftToRight);
                }
                else
                {
                    PrintThisLevel(levelToPrint, node.right, currLevel + 1, printLeftToRight);
                    PrintThisLevel(levelToPrint, node.left, currLevel + 1, printLeftToRight);
                }
            }
        }

        public void LevelOrderIterativeTraversal(Node node)
        {
            Queue<Tuple<Node, int>> qn = new Queue<Tuple<Node, int>>();
            int level = 0;
            int prevlevel = -1;
            qn.Enqueue(new Tuple<Node, int>(node, level));
            while (qn.Count > 0)
            {
                Tuple<Node, int> temp = qn.Dequeue();
                Node curr = temp.Item1;
                prevlevel = level;
                level = temp.Item2;
                if (curr.left != null)
                {
                    qn.Enqueue(new Tuple<Node, int>(curr.left, level + 1));
                }
                if (curr.right != null)
                {
                    qn.Enqueue(new Tuple<Node, int>(curr.right, level + 1));
                }
                if (level != prevlevel)
                    Console.WriteLine();
                Console.Write("  " + curr.data);
            }
        }

        public void InorderPrintRecursive(Node node)
        {
            if (node == null)
                return;
            InorderPrintRecursive(node.left);
            Console.Write(node.data + " ");
            InorderPrintRecursive(node.right);
        }

        public void PostOrderPrintRecursive(Node node)
        {
            if (node == null)
                return;
            PostOrderPrintRecursive(node.left);
            PostOrderPrintRecursive(node.right);
            Console.Write(node.data + " ");
        }

        public void PreOrderPrintRecursive(Node node, int level)
        {
            if (node != null)
            {
                for (int i = 0; i < level; i++)
                    Console.Write("|");
                Console.Write(node.data);
            }
            else return;
            PreOrderPrintRecursive(node.left, level + 1);
            PreOrderPrintRecursive(node.right, level + 1);
        }

        private int HeightOfNode(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.right == null && root.left == null)
            {
                return 1;
            }
            else
            {
                return Max(HeightOfNode(root.left), HeightOfNode(root.right)) + 1;
            }
        }

        public int getHeight()
        {
            return HeightOfNode(root);
        }

        int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public int getSize(Node root)
        {
            if (root == null)
                return 0;
            else
                return getSize(root.left) + getSize(root.right) + 1;
        }

        public int LevelWithMaxSum()
        {
            int sum = -999;
            int levelwithmaxsum=0;
            for (int i = 0; i < getHeight(); i++)
            {
                int newsum=SumOfThisLevel(i, root,0) ;
                if (newsum> sum)
                {
                    sum = newsum;
                    levelwithmaxsum = i;
                }
            }
            return levelwithmaxsum;
        }

        private int SumOfThisLevel(int levelToSum, Node node, int currLevel)
        {
            if (node == null)
            {
                return 0;
            }
            else if (currLevel == levelToSum)
            {
                return node.data;
            }
            else
            {
                return SumOfThisLevel(levelToSum, node.right, currLevel + 1) + SumOfThisLevel(levelToSum, node.left, currLevel + 1);
            }   
        }

        public void PrintAllPaths(Node Root, Stack<Node> s)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            int[] arr = { 5, 3, 7, 2, 4, 6, 8 };
            //{ 1,2,3,4,5,6,7,8};
            tree.CreateBinarySearchTree(arr);
            tree.Print();
            Tree tree2=new Tree();
            tree2.CreateBinarySearchTree(arr);
            Console.WriteLine("\nComparing 2 trees one cloned from the other. Are they equal?");
            Console.WriteLine(Tree.IsEquivalentClone(tree.root, tree2.root) + "\n");
            Tree mirrortree=new Tree();
            mirrortree.root= tree.MakeMirrorCopyTree();
            mirrortree.InorderPrintRecursive(mirrortree.root);
            Console.WriteLine("\nComparing 2 trees one cloned from the other. Are they mirror copies of each other?");
            Console.WriteLine(Tree.IsMirrorCopy(tree.root, tree2.root)+"\n");
            Console.WriteLine("\nComparing 2 trees one mirror copy of the other. Are they mirror copies of each other?");
            Console.WriteLine(Tree.IsMirrorCopy(tree.root, mirrortree.root)+"\n");
            Tree CompleteBinaryTree = new Tree();
            CompleteBinaryTree.CreateBinaryTree(arr);
            CompleteBinaryTree.LevelOrderRecursiveTraversal(CompleteBinaryTree.root);
            
            //non recursive everything
            //find lca of two nodes
            //searching in tree
            //deleting nodes
            //convert to binary search tree
            Console.ReadLine();
        }
    }
}

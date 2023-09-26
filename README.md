# Data Structures & Algorithms
Implementation of Data structures and algorithm in C#.

I will be doing these in my free time. 

# Current list of contents:
## Data Sructures:
### Stack
#### Stack Mehods:
* Push(object item): Add item to the top of the stack.
* Pop: Remove the item at the top of the stack.
* Clear: Clear the stack.
* PrintStack: Print the current items in the stack.
* StackImplementation: Just an implementation of the stacks methods. 
### CustomHashTable using Chaining for collision handling:
#### HashTable Methods:
* Add(int key, string value): Add a key value set to the table.
* Get(int key): Get the Entry object of the requested key.
* GetValue(int key): Get the value of the requested key.
* Remove(int key): Remove the Entry object with the given key from the table.
* ImplementHashTable: Just an implementation of the tables methods. 
### Binary Tree & Binary Search Tree:
The main difference between the two classes is the Insert() method. 
#### Binary Tree Properties
* Root: The root node of the Binary Tree.
* PreOrder: a Depth-first pre-order traversal of the Binary Tree represented in a string format. (Root, Left, Right)
* InOrder:  a Depth-first in-order traversal of the Binary Tree represented in a string format. (Left, Root, Right)
* PostOrder:  a Depth-first post-order traversal of the Binary Tree represented in a string format. (Left, Right, Root)
* LevelOrder:  a Breadth-first (level-order) traversal of the Binary Tree represented in a string format.
* Height: The height of the Binary Tree object. Each time we read this property it is updated based on the current status of the tree object.
* Min: Gets the current minimum value in the tree.
* IsBinarySearchTree: Returns true if the current tree object is a binary search tree.

#### Binary Tree Methods
* Find(int value): Returns true if the value argument exists in the tree.
* BinarySearchTree.Insert(int value): Adds the value in the correct node in the tree which means: The root node is ***Always*** bigger than its left child and smaller than its right child.
* BinaryTree.Insert(int value): Traverses the tree in level order and inserts the value in the first empty child from left children to right.
* GetNodesAtDistance(int distance): Gets the nodes at the requested distance from the root node.
* Equals: Overrides the Equals method in Object class. Checks if the two binary trees have the same values in the same locations.

## Algorithms
* Sorts: Insertion sort,  Selection sort, Merge sort
* Inversion Counter using merge sort
    (i,j) => j < i

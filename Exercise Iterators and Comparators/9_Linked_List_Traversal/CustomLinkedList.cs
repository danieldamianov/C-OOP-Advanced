using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _9_Linked_List_Traversal
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        private int count;

        public CustomLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count => this.count;

        public void Add(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (this.count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.pervious = this.tail;
                newNode.next = null;
                this.tail.next = newNode;
                this.tail = this.tail.next;
            }
            this.count++;
        }
        public bool Remove(T element)
        {
            if (this.head == null)
            {
                return false;
            }


            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                this.count--;
                return true;
            }

            if (this.head.element.Equals(element))
            {
                Node<T> oldHead = this.head;
                this.head = this.head.next;
                this.head.pervious = null;
                oldHead = null;
                this.count--;
                return true;
            }

            Node<T> currentElement = this.head.next;
            while (currentElement != null)
            {
                if (currentElement.element.Equals(element))
                {
                    Node<T> oldElement = currentElement;
                    currentElement.pervious.next = currentElement.next;
                    if (currentElement != this.tail)
                    {
                        currentElement.next.pervious = currentElement.pervious;
                    }
                    else
                    {
                        this.tail = this.tail.pervious;
                    }
                    oldElement = null;
                    this.count--;
                    return true;
                }
                currentElement = currentElement.next;
            }

            return false;
        }


        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.element;
                currentNode = currentNode.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<T>
        {
            public T element { get; set; }
            public Node<T> next { get; set; }
            public Node<T> pervious { get; set; }

            public Node(T element)
            {
                this.element = element;
                this.next = null;
                this.pervious = null;
            }
        }

    }
}

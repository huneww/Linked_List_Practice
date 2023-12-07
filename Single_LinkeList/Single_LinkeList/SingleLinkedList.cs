using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_LinkeList
{
    internal class SingleLinkedList
    {
        // 맨 앞 노드
        Node? frontNode = null;
        // 현재 노드
        Node? curNode = null;
        // 리스트 크기
        int length = 0;

        /// <summary>
        /// 리스트 맨 앞에 생성
        /// </summary>
        /// <param name="value"></param>
        public void Add_Front(int value)
        {
            // 리스트에 아무것도 없다면
            if (curNode == null)
            {
                // 새로운 노드 생성
                curNode = new Node();
                // 저장값 저장
                curNode.value = value;
                // 다음 노드 초기화
                curNode.next = null;
            }
            else
            {
                // 새로운 노드 생성
                Node node = new Node();
                // 저장값 저장
                node.value = value;
                // 다음 노드 현재 노드로 변경
                node.next = curNode;
                // 현재 노드를 새로 만든 노드로 변경
                curNode = node;
            }
            // 변경된 맨 앞 노드 저장
            frontNode = curNode;
            // 크기 증가
            length++;
        }

        /// <summary>
        /// 리스트 맨 앞에서 부터 확인해서 값 제거
        /// </summary>
        /// <param name="value"></param>
        public void Remove_Front(int value)
        {
            if (length <= 0)
            {
                throw new Exception("length is Less than 0");
            }

            if (frontNode.value == value)
            {
                curNode = frontNode.next;
                frontNode = frontNode.next;
                length--;
                return;
            }

            // 현재 노드를 맨 앞으로 이동
            Node? cur = frontNode.next;
            Node prev = frontNode;

            while (cur != null)
            {
                if (cur.value == value)
                {
                    prev.next = cur.next;
                    cur = null;
                    length--;
                    return;
                }
                else
                {
                    prev = cur;
                    cur = cur.next;
                }
            }

            Console.WriteLine("List is not have this " + value);
        }

        /// <summary>
        /// 리스트에 값이 있는지 확인
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Find(int value)
        {
            Node? cur = frontNode;

            while (cur != null)
            {
                if (cur.value == value)
                {
                    return true;
                }
                else
                {
                    cur = cur.next;
                }
            }

            return false;
        }

        /// <summary>
        /// 리스트 맨 앞의 값을 반환
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (length <= 0)
            {
                throw new Exception("length is Less than 0");
            }

            return frontNode.value;
        }

        /// <summary>
        /// 맨 앞의 값을 반환하면서 리스트에서 제거
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            if (length <= 0)
            {
                throw new Exception("length is Less than 0");
            }

            Node cur = frontNode;
            frontNode = frontNode.next;
            length--;

            return cur.value;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_LinkedList
{
    public class DoubleLinkedList
    {
        Node? frontNode = null;
        int length = 0;

        /// <summary>
        /// 맨 앞쪽에 저장
        /// </summary>
        /// <param name="value"></param>
        public void Add_Front(int value)
        {
            // 새로운 노드 생성
            Node node = new Node();
            node.value = value;
            node.next = null;
            node.prev = null;

            // 리스트에 아무것도 없디면
            // 맨 앞 노드에 새로운 노드 저장
            if (frontNode == null)
            {
                frontNode = node;
            }
            else
            {
                // 변경 전 맨 앞 노드를 저장
                Node curNode = frontNode;
                // 맨 앞 노드를 새로운 노드로 변경
                frontNode = node;
                // 새로운 노드의 다음을 현재 노드로 변경
                node.next = curNode;
                // 현재 노드의 이전을 새로운 노드로 변경
                curNode.prev = node;
            }
            // 리스트 길이 증가
            length++;
        }

        /// <summary>
        /// 맨 뒤에 값 추가
        /// </summary>
        /// <param name="value"></param>
        public void Add_Back(int value)
        {
            // 새로운 노드 생성
            Node node = new Node();
            node.value = value;
            node.next = null;
            node.prev = null;

            // 리스트에 값이 없다면
            // 맨 앞 노드에 새로운 노드 저장
            if (frontNode == null)
            {
                frontNode = node;
            }
            else
            {
                // 맨 앞 노드 값 획득
                Node curNode = frontNode;
                // 현재 노드의 다음 노드가 없을때 까지 이동
                while (curNode.next != null)
                {
                    curNode = curNode.next;
                }
                // 현재 노드의 다음을 새로 생성한 노드로 저장
                curNode.next = node;
                // 새로운 노드의 이전을 현재 노드로 변경
                node.prev = curNode;
            }
            // 리스트 길이 증가
            length++;
        }

        /// <summary>
        /// 맨 앞 값을 획득
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int Peek()
        {
            // 리스트에 아무것도 없다면
            // 오류 메시지 출력
            if (frontNode == null || length == 0)
            {
                throw new Exception("List is Empty");
            }
            // 맨 앞 노드의 값 반환
            return frontNode.value;
        }

        /// <summary>
        /// 맨 앞 값을 획득 하면서 노드에서 제거
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int Dequeue()
        {
            // 리스트에 아무것도 없다면
            // 오류 메시지 출력
            if (frontNode == null || length == 0)
            {
                throw new Exception("List is Empty");
            }

            // 맨 앞 노드 저장
            Node returnnode = frontNode;
            // 맨 앞 노드 다음 노드로 변경
            frontNode = frontNode.next;
            // 맨 앞 노드의 이전 노드 제거
            frontNode.prev = null;
            // 리스트 길이 감소
            length--;
            // 노드 값 반환
            return returnnode.value;
        }

        /// <summary>
        /// value와 동일한 값을 찾아 노드 제거
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int value)
        {
            Node? curNode = frontNode;
            if (length == 0)
            {
                Console.WriteLine("List is Empty");
                return;
            }

            while (curNode != null)
            {
                // 현재 노드의 값과 비교
                if (curNode.value == value)
                {
                    // 제거할 노드가 맨 앞 노드라면
                    if (curNode == frontNode)
                    {
                        // 현재 노드의 앞 노드로 변경
                        curNode = curNode.next;
                        // 원래 맨 앞 노드를 제거
                        curNode.prev = null;
                        // frontNode의 값을 변경한 노드로 변경
                        frontNode = curNode;
                    }
                    // 제거할 노드가 맨 뒷 노드라면
                    else if (curNode.next == null)
                    {
                        // 맨 뒷 노드의 이전 노드의 다음 노드를 제거
                        curNode.prev.next = null;
                    }
                    // 중간 부분
                    else
                    {
                        // 현재 노드의 앞, 뒤 노드들을 연결
                        curNode.next.prev = curNode.prev;
                        curNode.prev.next = curNode.next;
                    }
                    // 리스트 길이 변경
                    length--;
                    // 반복문 정지
                    break;
                }
                else
                {
                    // 현재 노드를 다음 노드로 변경
                    curNode = curNode.next;
                }
            }

            // 값을 찾지 못했다면
            if (curNode == null)
            {
                Console.WriteLine("List does not have " + value);
            }
        }

        /// <summary>
        /// 값을 찾아 반환
        /// </summary>
        /// <param name="value"></param>
        /// <returns>값을 찾으면 현재 값이 저장된 노드를 반환, 찾지 못하면 null이 저장된 노드 반환</returns>
        public Node FindandReturn(int value)
        {
            Node? curNode = frontNode;

            while (curNode != null)
            {
                // 현재 노드의 값이 같다면
                if (curNode.value == value)
                {
                    // 값 반환
                    return curNode;
                }
                else
                {
                    // 다음 노드로 이동
                    curNode = curNode.next;
                }
            }

            // 값이 없다면 null노드를 반환
            Console.WriteLine("List does not have " + value);
            return curNode;
        }

    }
}

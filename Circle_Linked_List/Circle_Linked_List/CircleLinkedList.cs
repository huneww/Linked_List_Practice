using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_Linked_List
{
    public class CircleLinkedList
    {
        Node? frontNode;
        Node? backNode;
        int length;

        public void Add_Front(int value)
        {
            // 새로운 노드 생성
            Node? node = new Node();
            node.value = value;

            // 리스트에 아무것도 없다면
            if (frontNode == null)
            {
                // 맨 앞 노드에 노드 저장
                frontNode = node;
                // 맨 앞, 뒷 노드의 다음 노드를 자기 자신으로 저장
                frontNode.next = backNode;
                backNode.next = frontNode;
            }
            else
            {
                // 새로운 노드의 다음을 맨 앞 노드로 저장
                node.next = frontNode;
                // 리스트의 맨 끝 노드로 이동
                Node? curNode = frontNode;
                while (curNode.next != frontNode)
                {
                    curNode = curNode.next;
                }
                // 맨 끝 노드의 다음을 새로운 노드로 지정
                curNode.next = node;
                // 맨 앞 노드를 새로운 노드로 변경
                frontNode = node;
            }
            // 리스트 크기 증가
            length++;
        }

        public void Add_Back(int value)
        {
            // 새로운 노드 생성
            Node? node = new Node();
            node.value = value;

            // 리스트에 아무것도 없다면
            if (frontNode == null)
            {
                // 맨 앞 노드에 새로운 노드 저장
                frontNode = node;
                // 맨 앞, 뒷 노드의 다음 노드가 자기 자신을 가리키도록 변경
                frontNode.next = backNode;
                backNode.next = frontNode;
            }
            else
            {
                // 새로운 노드의 다음을 맨 앞 노드로 변경
                node.next = frontNode;
                // 리스트의 맨 끝 노드로 이동
                Node? curNode = frontNode;
                while (curNode.next != frontNode)
                {
                    curNode = curNode.next;
                }
                // 맨 끝 노드의 다음을 새로운 노드로 변경
                curNode.next = node;
                // 맨 뒷 노드에 새로운 노드 저장
                backNode = node;
            }
            // 리스트 크기 증가
            length++;
        }

        public void Remove(int value)
        {
            // 리스트에 아무것도 없다면
            // 오류 메시지 출력
            if (length <= 0)
            {
                throw new Exception("List is Empty");
            }

            // 맨 앞 노드 획득
            Node? node = frontNode;
            
            // 맨 앞 노드의 값이 제거 값과 같다면
            if (node.value == value)
            {
                // 맨 뒷 노드의 다음을 맨 앞 노드의 다음으로 변경
                backNode.next = node.next;
                // 맨 앞 노드값 변경
                frontNode = node.next;
                // 리스트 길이 감소
                length--;
                // 메서드 종료
                return;
            }

            // 리스트를 한바뀌 돌때까지
            while (node.next != frontNode)
            {
                // 다음 노드의 값이 제거 값이라면
                if (node.next.value == value)
                {
                    // 제거 노드 임시 저장
                    Node remove = node.next;
                    // 현재 노드의 다음을 제거 노드의 다음으로 변경
                    node.next = node.next.next;
                    // 제거 노드 메모리 해제
                    remove = null;
                    // 리스트 크기 감소
                    length--;
                    // 메서드 종료
                    return;
                }
                else
                {
                    node = node.next;
                }
            }
        }

        public Node Find(int value)
        {
            if (length <= 0)
            {
                throw new Exception("List is Empty");
            }

            Node? curNode = frontNode;

            // 맨 앞 노드가 찾는 값이라면
            // 맨 앞 노드를 반환
            if (frontNode.value == value)
            {
                return frontNode;
            }

            // 리스트를 한바뀌 돌때까지
            while (curNode.next != frontNode)
            {
                // 다음 노드의 값이 찾는 값이라면
                // 반복문 종료
                if (curNode.next.value == value)
                {
                    break;
                }
                // 다음 노드로 현재 노드 변경
                else
                {
                    curNode = curNode.next;
                }
            }

            // 현재 노드의 다음 노드를 반환
            return curNode.next;
        }

    }
}

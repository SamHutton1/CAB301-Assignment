using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Assignment
{
    public class MemberCollection : iMemberCollection
    {
        BSTree allUsers = new BSTree();
        private Member[] membersAsArray = new Member[100];
        private int totalMembers = 0;

        public int Number { get { return totalMembers; }  }

        public void add(Member aMember)
        {
            totalMembers++;
            allUsers.Insert(aMember);
        }

        public void delete(Member aMember)
        {
            if (allUsers.Delete(aMember)) totalMembers--;
        }

        public bool search(Member aMember)
        {
            return allUsers.Search(aMember);
        }

        public Member[] toArray()
        {
            allUsers.InOrderTraverse1111111111();
            List<Member> thing = allUsers.memberList();

            for (int i = 0; i < thing.Count; i++)
            {
                membersAsArray[i] = thing[i];
            }
            return membersAsArray;
        }
    }
}

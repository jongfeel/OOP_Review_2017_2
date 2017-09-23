using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_2_1
{
    class Test
    {
        public int value { get; set; }
        public string Name { get; set; }
        // 여기서 계속 뭔가 추가되면
        // Test type의 객체가 같다고 판단하기 귀찮아짐
        // 그래서 우리에게 필요한건 Equals override

        public override bool Equals(object obj)
        {
            if (obj is Test t)  // C# 6.0
            {
                if (value == t.value && Name == t.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator == (Test left, Test right)
        {
            if (left.Equals(right))
                return true;
            else
            {
                return false;
            }
        }

        public static bool operator !=(Test left, Test right)
        {
            return !(left == right);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Equals: value, object
                Equals and ReferenceEquals
                object.Equals method override
             */

            // value vs object
            int a = 1;
            int b = 2;

            bool result1 = Object.Equals(a, b); // false

            // Equals and ReferenceEquals
            Test t1 = new Test();
            t1.value = 1;
            Test t2 = new Test();
            t2.value = 1;

            Test t3 = t1;

            bool result2 = object.Equals(t1, t2);   // false

            bool result3 = object.Equals(t1, t3);   // true

            object.ReferenceEquals(t1, t3); // true

            // object.Equals override
            if (t1 == t2)   // reference equals, but operator == 있다면?
            {
                Console.WriteLine("만약 이게 찍히면 operator == 정의 된거임");
            }

            // 객알못, 왜 객알못인가요? Equals의 존재를 모르는자이기 때문
            if (t1.value == t2.value && t1.Name == t2.Name)   // value equals
            {
                Console.WriteLine("t1, t2 객체 같음");
            }

            if (t1.Equals(t2))   // values in object equals
            {
                Console.WriteLine("t1, t2 객체 같음");
            }
            
            // 질문
            // 1. 이직을 많이 하는게 새로운 기술을 위해서 나가는건지?
            // -> 아님, 대체로 연봉 조건이나, 사람 사이의 트러블 떄문에 나감
            // 2. 새로운 기술에 대한 압박감
            // -> 새로운 기술을 주시하고 배우는 걸 좋아함
            // 3. 모르는 것에 대한 검색
            // -> 영어를 잘하면 됨 (read, write 위주로)
            // 4. 알고리즘을 알아야 하는지? 
            // -> 알고리즘이라는게 있는 건 알아야 함, 실제로 쓰는건 ??
            // -> 학부때는 많이 하면 좋음, 실무에서는 정해져 있는걸 씀
            // 5. WPF로 뭘 했나요?
            // -> 여러 프로젝트를 했죠. 그 당시 (2007~2010) 윈도우 프로그램에서 GUI가 포인트인 프로젝트에 많이 씀
            // -> 윈도우 그래픽 렌더링떄문에 많이 씀
            // 6. 대학원 진학률
            // -> 생각보다 높음. 그리고 기술력을 요구하는 회사들이 많아지는 추세여서 석박사급 인재가 필요로 함.
            // 7. 야근?
            // -> 회사마다 다름

            // 다음 리뷰 주제
            // 1. interface
            // 2. inheritance -> 어떻게 써먹는지

            // 다음 시간은 저녁 약속으로 오후 2시 진행
        }
    }
}
